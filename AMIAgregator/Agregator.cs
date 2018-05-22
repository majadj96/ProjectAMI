using Common;
using System;
using System.Collections.Generic;
using System.Linq;
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

        
    
        public Agregator()
        {
            state = State.on;
            agregatorCode = GetHashCode().ToString();
            bool postoji = false;
            Console.WriteLine("----Creating new Agregator----");
                foreach(KeyValuePair<string, Dictionary<MeasureType,double>> c in Datas.agregators)
                {
                    if (c.Key.Equals(agregatorCode))
                    {
                        postoji = true;
                        break;
                    }
                }

            if (!postoji)
            {
                Datas.agregators.Add(agregatorCode, new Dictionary<MeasureType, double>());
            }
            Console.WriteLine("+New Agregator with "+agregatorCode+" is created");

        }

        public void Send(string code, DateTime timestamp, Dictionary<Enums.MeasureType, double> measurements)
        {

            string path = @"..\Measurement.xml";

            string xmlString = $@"<Measure> 
	            <Code>{code}</Code> 
	            <Timestamp>{timestamp.ToString()}</Timestamp> 
            	<Voltage>{employee.PersonalIdentityNumber}</Voltage>
                </Measure>
                ";

            // Add text to the file.
            if (!File.Exists(path))
                File.WriteAllText(path, xmlString);
            else
                File.AppendAllText(path, xmlString);

            // Open the file to read from.
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);


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
