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

        public static string gdeSeKacim;
        public Device()
        {
            Console.WriteLine("----Creating new Device----");
            DeviceState = State.on;
            DeviceCode = GetHashCode().ToString();
            measurements = new Dictionary<MeasureType, double>();
            Random rand = new Random();
            measurements.Add(MeasureType.electricity, rand.Next(0,30));// struja ide u rasponu od 0 do 30kWh
            measurements.Add(MeasureType.voltage, rand.Next(0,240));//napon ide u rasponu od 0 do 240V
            measurements.Add(MeasureType.activePower, rand.Next(0,100));
            measurements.Add(MeasureType.reactivePower, rand.Next(0,100));

            TimeStamp = DateTime.Now;

            bool choice = false;

        //    do
         //   {
              
                Console.WriteLine("Choose Agreagator by name:");

                string path = @"C:\Users\john\Desktop\RES\ProjectAMI\AMIAgregator\bin\nameOfAgregators.xml";

                    string readText = File.ReadAllText(path);
            


                Console.WriteLine(readText);

            foreach (KeyValuePair<MeasureType, double> a in measurements) // Ispis vrednosti trenutnih
            {
                Console.WriteLine(a.Key+" :"+a.Value);
            }
                /*
            foreach (KeyValuePair<string, Dictionary<string, Dictionary<MeasureType, double>>> a in Datas.agregators)
                {
                    Console.WriteLine("- {0}", a.Key);
                }
                */

            gdeSeKacim = Console.ReadLine();
                /*
                if (!Datas.agregators.Keys.Contains(name))
                {
                    Console.WriteLine("Wrong Agregator name!");
                    break;
                }

                if (!Datas.agregators[name].Keys.Contains(DeviceCode))
                {
                    Datas.agregators[name].Add(DeviceCode, measurements);
                    choice = true;
                }
                else
                {
                    DeviceCode = GetHashCode().ToString();
                    Datas.agregators[name].Add(DeviceCode, measurements);
                    choice = true;
                }
                
    */

           // } while (choice == false);
            Console.WriteLine("----New Device with code {0} is created----", DeviceCode);
        }
    }
}
