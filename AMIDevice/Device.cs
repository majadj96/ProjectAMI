using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace AMIDevice
{
    public class Device : IDevice
    {
        public string DeviceCode { get; set; }
        public DateTime TimeStamp { get; set; }
        public Dictionary<MeasureType, double> measurements { get ; set ; }
        public State DeviceState { get; set; }
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

            bool choice = false;

            do
            {
                Console.WriteLine("Choose Agreagator:");
                foreach(var a in )
                


            } while (choice == false);
            Console.WriteLine("----New Device with code {0} is created----", DeviceCode);
        }
    }
}
