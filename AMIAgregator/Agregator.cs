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
    class Agregator : IAMIAgregator
    {
        public string agregatorCode { get; set; }
        public State state { get ; set; }
        public static string port;

        public Agregator() { }
        public Agregator(int e)
        {
            Console.WriteLine("--------Creating new Agregator--------");
            Random r = new Random();
            agregatorCode = "50"+r.Next(0,9) + r.Next(0, 9);
            state = State.on;

            bool exists = false;

            using(var data = new AgregatorBaseDBContex())
            {
                do
                {
                    exists = false;
                    foreach (var a in data.AgregatorBaseData)
                    {
                        if (a.AgregatorCode == agregatorCode)
                        {
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
                    AgregatorCode = agregatorCode
                };

                data.AgregatorBaseData.Add(AgregatorBase);
                data.SaveChanges();

            }

            port = agregatorCode;

            Console.WriteLine("Agregator is created with code [{0}].",agregatorCode);
            Console.WriteLine("--------------------------------------");

        }

        public void Send(string code, DateTime timestamp, Dictionary<Enums.MeasureType, double> measurements,string codeAgr)
        {
            using (var data = new LocalBaseDBContex())
            {
                LocalBase lb = new LocalBase()
                {
                    AgregatorCode = codeAgr,
                    DeviceCode = code,
                    TimeStamp = timestamp.ToString(),
                    Voltage = measurements[MeasureType.voltage],
                    Eletricity = measurements[MeasureType.electricity],
                    ActivePower = measurements[MeasureType.activePower],
                    ReactivePower = measurements[MeasureType.reactivePower]
                };
                
                data.LocalBaseData.Add(lb);
                data.SaveChanges();
            }

            Console.WriteLine("Message from [{0}] added in LocalDataBase at {1}.", code, timestamp);
        }

        public void turnOff()
        {
            if(state == State.on)
            {
                state = State.off;
            }
        }

        public void turnOn()
        {
            if (state == State.off)
            {
                state = State.on;
            }
        }
    }
}
