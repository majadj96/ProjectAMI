using AMISystemManagement;
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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

          Console.WriteLine("Choose Agreagator by name:");


            using (var data = new AgregatorBaseDBContex())
            {

                var AgregatorBase = from d in data.AgregatorBaseData select d;

                foreach(var lb in AgregatorBase)
                {
                    Console.WriteLine(lb.Id +". " + lb.AgregatorCode);
                }

            }

            string agregatorID = Console.ReadLine();
            AgregatorBase entity;
            using (var aData = new AgregatorBaseDBContex())
            {
                do
                {
                    entity = aData.AgregatorBaseData.Find(Int32.Parse(agregatorID));

                    if (entity == null)
                    {
                        Console.WriteLine("Incorect format. Try again. \n->");
                        agregatorID = Console.ReadLine();
                    }

                } while (entity == null);
            }

            myAgregator = entity.AgregatorCode;
           

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
