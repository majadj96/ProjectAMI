using AMISystemManagement;
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Common.Enums;

namespace AMIDevice
{
    public class Device : IDevice
    {
        public string DeviceCode { get; set; }
        public DateTime TimeStamp { get; set; }
        public Dictionary<MeasureType, double> measurements { get ; set ; }
       public State DeviceState { get; set; }

        public string myAgregator { get; set; }
        public Device()
        {
            Console.WriteLine("----Creating new Device----");
            DeviceState = State.on;
            measurements = new Dictionary<MeasureType, double>();
            Random rand = new Random();
            DeviceCode = rand.Next(200,10000).ToString(); // UMESTO HASH**
            measurements.Add(MeasureType.electricity, rand.Next(0,30));// struja ide u rasponu od 0 do 30kWh
            measurements.Add(MeasureType.voltage, rand.Next(0,240));//napon ide u rasponu od 0 do 240V
            measurements.Add(MeasureType.activePower, rand.Next(0,100));
            measurements.Add(MeasureType.reactivePower, rand.Next(0,100));

            TimeStamp = DateTime.Now;

            bool choice = false;

            do
            {
                Console.WriteLine("Choose Agreagator by name:");

                string path = @"..\..\..\AMIAgregator\bin\nameOfAgregators.xml";

                string[] listOfAgregators = new string[10];
                string[] listOfDevices = new string[10];
                int j = 0;
               /* using (XmlReader reader = XmlReader.Create(path))
                {
                    while (reader.Read())
                    {
                       // reader.MoveToContent();
                        if (reader.Name == "code")
                        {
                            //reader.Read();
                            listOfAgregators[j] = reader.Value.Trim();
                            Console.WriteLine("*- {0}", listOfAgregators[j]);
                            j++;
                        }
                    }
                }*/

               
                 string readText = File.ReadAllText(path);

                 string[] split = readText.Split('<','>');
                 //Console.WriteLine(readText);
                 
                 for(int i = 2; i < split.Length; i = i + 4)
                 {
                     listOfAgregators[j] = split[i];
                     j++;
                     Console.WriteLine("- {0}", split[i]);
                 }
                myAgregator = Console.ReadLine();


                 for (int i = 0; i < listOfAgregators.Length; i++) {
                     if (listOfAgregators[i] == myAgregator)
                     {
                         choice = true;
                         break;
                     }

                 }
                if (!choice)
                {
                    Console.WriteLine("Wrong Agregator name!");
                }
                else
                {
                    string pathOfDevices = @"..\..\..\AMIAgregator\bin\agregator"+myAgregator+".xml";
                    if (!File.Exists(pathOfDevices))
                    {
                        string xmlString = $@"
	                      <Code>{DeviceCode}</Code>
                           ";
                        File.WriteAllText(pathOfDevices, xmlString);
                    }
                    else
                    {
                        string readFile = File.ReadAllText(pathOfDevices);
                        string[] splitDevices = readFile.Split('<', '>');
                        //Console.WriteLine(readText);
                        int d = 0;
                        for (int i = 2; i < splitDevices.Length; i = i + 4)
                        {
                            listOfDevices[d] = splitDevices[i];
                            d++;
                        }

                        bool exists = false;
                        do
                        {
                            exists = false;
                            foreach (string s in listOfDevices)
                            {
                                if (DeviceCode == s)
                                {
                                    DeviceCode = rand.Next(0, 100).ToString();
                                    exists = true;
                                    break;
                                }
                            }
                        } while (exists);

                        string xmlString = $@"
	                    <Code>{DeviceCode}</Code>
                         ";

                        File.AppendAllText(pathOfDevices, xmlString);
                    }
                    Console.WriteLine("----New Device with code {0} is created----", DeviceCode);
                }
            } while (choice == false);
           

        }

        public void turnOff()
        {
            if (DeviceState == State.on)
            {
                DeviceState = State.off;
            }
        }

        public void turnOn()
        {
            if (DeviceState == State.off)
            {
                DeviceState = State.on;
            }
        }
    }
}
