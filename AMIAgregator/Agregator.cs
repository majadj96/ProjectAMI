using AMISystemManagement;
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Common.Enums;

namespace AMIAgregator
{
    public class Agregator : IAMIAgregator
    {
        public string agregatorCode { get; set; }
        public State state { get ; set; }
        public static string port;

        public Agregator() { }
        public Agregator(State state) { this.state = state; }

        public Agregator(int e)
        {
            if (e < 0)
            {
                throw new OutOfMemoryException("Minus");
            }
            Console.WriteLine("--------Creating new Agregator--------");
            Random r = new Random();
            agregatorCode = "50"+r.Next(0,9) + r.Next(0, 9);
            state = State.on;

            agregatorCode = addAgregator(agregatorCode);
            port = agregatorCode;

            Console.WriteLine("Agregator is created with code [{0}].",agregatorCode);
            Console.WriteLine("--------------------------------------");

        }

        public string addAgregator(string agregatorCode)
        {
            if (agregatorCode.Length != 4 )
            {
                throw new ArgumentException("Invalid code");
            }

            try
            {
                int.Parse(agregatorCode);
            }
            catch
            {
                throw new ArgumentOutOfRangeException("It must be number.");
            }


            using (var data = new AgregatorBaseDBContex())
            {
                bool exists = false;
                do
                {
                    exists = false;
                    foreach (var a in data.AgregatorBaseData)
                    {
                        if (a.AgregatorCode == agregatorCode)
                        {
                            Random r = new Random();
                            Console.WriteLine("Agregator with that code already exist-> changing code..");
                            agregatorCode = "50" + r.Next(0, 9) + r.Next(0, 9);
                            Console.WriteLine("New code is : {0}", agregatorCode);
                            exists = true;
                            break;

                        }
                    }
                } while (exists);

                var AgregatorBase = new AgregatorBase
                {
                    AgregatorCode = agregatorCode,
                    Time = DateTime.Now.ToString()
                };

                data.AgregatorBaseData.Add(AgregatorBase);
                data.SaveChanges();

            }

            return agregatorCode;
        }

        public void Send(string code, long timestamp, Dictionary<Enums.MeasureType, double> measurements,string codeAgr)
        {
            if(code.Length!=4 || codeAgr.Length != 4)
            {
                throw new ArgumentException("Invalid code");
            }

            try{
                int.Parse(code);
                int.Parse(codeAgr);
            }
            catch
            {
                throw new ArgumentOutOfRangeException("It must be number.");
            }
           


            if (measurements.Count <=0)
            {
                try { }
                catch (Exception e)
                {
                    throw new ArgumentException("Dictionary is empty.");
                }
            }

            if(timestamp < 1528236934 || timestamp> 1546300800)
            {
               
                    throw new ArgumentOutOfRangeException("Timestamp is out of range.");
                
            }

            using (var data = new LocalBaseDBContex())
            {
                LocalBase lb = new LocalBase()
                {
                    AgregatorCode = codeAgr,
                    DeviceCode = code,
                    TimeStamp = (Datas.UnixTimeToDateTime(timestamp)).ToString(),
                    Voltage = measurements[MeasureType.voltage],
                    Eletricity = measurements[MeasureType.electricity],
                    ActivePower = measurements[MeasureType.activePower],
                    ReactivePower = measurements[MeasureType.reactivePower]
                };
                
                data.LocalBaseData.Add(lb);
                data.SaveChanges();
            }

            Console.WriteLine("Message from [{0}] added in LocalDataBase at {1}.", code, Datas.UnixTimeToDateTime(timestamp));
        }

        public bool turnOff()
        {
            if(state == State.on)
            {
                state = State.off;
                return true;
            }
            else
            {
               
                    throw new ArgumentException("State is up to date.");
                
            }
        }

        public bool turnOn()
        {
            if (state == State.off)
            {
                state = State.on;
                return true;
            }
            else
            {
                
                    throw new ArgumentException("State is up to date.");
                
            }
        }
    }
}
