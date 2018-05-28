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
using System.Xml.Linq;
using static Common.Enums;

namespace AMIAgregator
{
    class Agregator : IAMIAgregator
    {
        public string agregatorCode { get; set; }
        public State state { get; set; }

        public static string port;

        public Agregator() { }
        public Agregator(int e)
        {
            state = State.on;
            Random r1 = new Random();
            bool postoji = false;
            Console.WriteLine("----Creating new Agregator----");
            Random r = new Random();
            port = "50" + r.Next(0, 9) + r.Next(0, 9);
            agregatorCode = port;


            using (var db = new ModelDBContex())
            {
                var model = new Model
                {
                    Code = agregatorCode
                };

                db.Modeli.Add(model);
                db.SaveChanges();
            }





        }
    
            



            /*  string path = @"..\nameOfAgregators.xml";
          bool added = false;
          if (!File.Exists(path))
          {
              added = true;
              string xmlString = $@"
                  <Code>{agregatorCode}</Code>
                  ";
              File.WriteAllText(path, xmlString);
          }
          else
          {
              string readFile = File.ReadAllText(path);

              string[] splitAgregators = readFile.Split('<', '>');
              string[] listOfAgregators = new string[10];

              //Console.WriteLine(readText);
              int d = 0;
              for (int i = 2; i < splitAgregators.Length; i = i + 4)
              {
                  listOfAgregators[d] = splitAgregators[i];
                  d++;
              }
              bool ima = false;
              do
              {
                  ima = false;
                  foreach (string s in listOfAgregators)
                  {
                      if (agregatorCode == s)
                      {
                          Console.WriteLine("Code {0} is already exists!", s);
                          agregatorCode = ("50" + r.Next(0, 9) + r.Next(0, 9)).ToString();
                          port = agregatorCode;
                          Console.WriteLine("New code is : {0}", agregatorCode);
                          ima = true;
                          break;
                      }
                  }
              } while (ima);
          }
          if (!postoji)
              {

                  Console.WriteLine("+New Agregator with " + agregatorCode + " is created");
              if (!added)
              {
                  string xmlString = $@"
                  <Code>{agregatorCode}</Code>
                  ";
                  File.AppendAllText(path, xmlString);
              }

          }*/
        

        public void Send(string code, DateTime timestamp, Dictionary<Enums.MeasureType, double> measurements,string codeAgr)
        {

            string path = @"..\"+codeAgr+"_"+code+".xml"; // primer : 5001_274623.xml

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
            }
    
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
