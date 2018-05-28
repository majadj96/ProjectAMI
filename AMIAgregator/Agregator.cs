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
                state = State.on;
                Console.WriteLine("----Creating new Agregator----");
                Random r = new Random();
                port = "50"+r.Next(0,9) + r.Next(0, 9);
                agregatorCode = port;


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
                            port = "50" + r.Next(0, 9) + r.Next(0, 9);
                            agregatorCode = port;
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

            /* string path = @"..\"+codeAgr+"_"+code+".xml"; // primer : 5001_274623.xml

             string xmlString = $@"<Measure>
                 <Timestamp>{timestamp.ToString()}</Timestamp> 
                 <Voltage>{measurements[MeasureType.voltage]}</Voltage>
                 <Electricity>{measurements[MeasureType.electricity]}</Electricity>
                 <Activepower>{measurements[MeasureType.activePower]}</Activepower>
                 <Reactivepower>{measurements[MeasureType.reactivePower]}</Reactivepower>
                 </Measure>
                 ";

             // Add text to the file.
             if (!File.Exists(path))
                 File.WriteAllText(path, xmlString);
             else
             {
                 File.AppendAllText(path, xmlString); // OVDE SAMO BACA EXCEPTION JER NE MOZE DA PISE U ISTO VREME
                 Console.WriteLine("Upisano je");
             }*/

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
