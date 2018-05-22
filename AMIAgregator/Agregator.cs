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

        public Agregator()
        {
            
            state = State.on;
            Random r1 = new Random();
            bool postoji = false;
            Console.WriteLine("----Creating new Agregator----");
              Random r = new Random();
            port = "500" + r.Next(0, 9);
            agregatorCode = port;

        string path = @"..\nameOfAgregators.xml";

        

            foreach (KeyValuePair<string,Dictionary<string,Dictionary<MeasureType,double>>> c in Datas.agregators) { 
                    if (c.Key.Equals(agregatorCode))
                    {
                        postoji = true;
                        break;
                    }
                }

            if (!postoji)
            {
                Datas.agregators.Add(agregatorCode,new Dictionary<string, Dictionary<MeasureType, double>>());
            }
            Console.WriteLine("+New Agregator with "+agregatorCode+" is created");

            string xmlString = $@"
	            <Code>{agregatorCode}</Code>
                ";

            if (!File.Exists(path))
            {

                File.WriteAllText(path, xmlString);

            }
            else
                File.AppendAllText(path, xmlString);


            // Add text to the file.

          
        }

        public void Send(string code, DateTime timestamp, Dictionary<Enums.MeasureType, double> measurements)
        {

            string path = @"..\Measurement.xml";

            string xmlString = $@"<Measure> 
	            <Code>{code}</Code> 
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
                File.AppendAllText(path, xmlString);

            // Open the file to read from.
            // string readText = File.ReadAllText(path);
            // Console.WriteLine(readText);
            Console.WriteLine("Upisano je");
    
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
