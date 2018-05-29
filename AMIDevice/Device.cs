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
            Console.WriteLine("-----------------Creating new Device------------------");
            
            measurements = new Dictionary<MeasureType, double>();
            Random rand = new Random();
            DeviceCode = rand.Next(200,10000).ToString();

            TimeStamp = DateTime.Now;

            measurements.Add(MeasureType.electricity, rand.Next(0,30));
            measurements.Add(MeasureType.voltage, rand.Next(0,240));
            measurements.Add(MeasureType.activePower, rand.Next(0,100));
            measurements.Add(MeasureType.reactivePower, rand.Next(0,100));

            DeviceState = State.on;

            Console.WriteLine("Choose Agreagator:");
            
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
                 entity = aData.AgregatorBaseData.Find(Int32.Parse(agregatorID));
            }

            myAgregator = entity.AgregatorCode;


            bool exists = false;

            using (var lData = new LocalBaseDBContex())
            {
                do
                {
                    exists = false;
                    foreach (var lb in lData.LocalBaseData)
                    {
                        if (lb.AgregatorCode == myAgregator && lb.DeviceCode == DeviceCode)
                        {
                            Console.WriteLine("Device with that code already exist-> changing code..");
                            DeviceCode = rand.Next(200, 10000).ToString();
                            Console.WriteLine("New code is : {0}", DeviceCode);
                            exists = true;
                            break;
                        }

                    }
                } while (exists);

            }
            
            Console.WriteLine("Device is created with code [{0}] and agregator [{1}].", DeviceCode,myAgregator);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Start measuring..");

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
