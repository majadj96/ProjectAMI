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
        public long TimeStamp { get; set; }
        public Dictionary<MeasureType, double> measurements { get ; set ; }
        public State DeviceState { get; set; }
        public string myAgregator { get; set; }


        public Device(State state)
        {
            DeviceState = state;
        }

        public Device()
        {
            Console.WriteLine("-----------------Creating new Device------------------");
            
            measurements = new Dictionary<MeasureType, double>();
            Random rand = new Random();
            DeviceCode = rand.Next(1000,9999).ToString();

            TimeStamp = Datas.ConvertToUnixTime(DateTime.Now);

            measurements.Add(MeasureType.electricity, rand.Next(0,30));
            measurements.Add(MeasureType.voltage, rand.Next(0,240));
            measurements.Add(MeasureType.activePower, rand.Next(0,100));
            measurements.Add(MeasureType.reactivePower, rand.Next(0,100));

            DeviceState = State.on;
            int a = 0;
            List<string> listagr;
            string agregatorID;
            do
            {
                Console.WriteLine("Choose Agreagator:");
                listagr = ReadAgregatorsFromBase(); //metoda citanja iz baze

                agregatorID = Console.ReadLine();
                a = int.Parse(agregatorID);
            } while (a < 48 || a > 57);


            myAgregator = CheckChosenAgregator(listagr, agregatorID); // metoda provera sa bazom 

            DeviceCode = CheckLocalBase(myAgregator, DeviceCode);// provera da li postoji taj device na tom agregatoru
            
            Console.WriteLine("Device is created with code [{0}] and agregator [{1}].", DeviceCode,myAgregator);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Start measuring..");

        }

        public bool turnOff()
        {
            if (this.DeviceState == Enums.State.on)
            {
                this.DeviceState = Enums.State.off;
                return true;
            }
            else
            {
                throw new ArgumentException("State is up to date");
            }
        }

        public bool turnOn()
        {
            if (this.DeviceState == Enums.State.off)
            {
                this.DeviceState = Enums.State.on;
                return true;
            }
            else
            {
                throw new ArgumentException("State is up to date");
            }
        }


     


        public string CheckLocalBase(string myAgregator, string DeviceCode)
        {
            if (myAgregator.Length != 4 || DeviceCode.Length != 4)
            {
                throw new ArgumentOutOfRangeException("Invalid code");
            }

            try
            {
                int.Parse(myAgregator);
                int.Parse(DeviceCode);
            }
            catch
            {
                throw new ArgumentException("It must be number.");
            }


            using (var lData = new LocalBaseDBContex())
            {
                bool exists = false;
                do
                {
                    exists = false;
                    foreach (var lb in lData.LocalBaseData)
                    {
                        if (lb.AgregatorCode == myAgregator && lb.DeviceCode == DeviceCode)
                        {
                            Console.WriteLine("Device with that code already exist-> changing code..");
                            Random rand = new Random();
                            DeviceCode = rand.Next(200, 10000).ToString();
                            Console.WriteLine("New code is : {0}", DeviceCode);
                            exists = true;
                            break;
                        }
                       
                    }
                } while (exists);

            }

            return DeviceCode;
        }


        public List<string> ReadAgregatorsFromBase()
        {
            List<string> listAgr = new List<string>();
            int i = 1;
            using (var data = new AgregatorBaseDBContex())
            {
                var AgregatorBase = from d in data.AgregatorBaseData select d;

                foreach (var lb in AgregatorBase)
                {
                    DateTime timeA = DateTime.Parse(lb.Time);
                    if (timeA >= DateTime.Now.AddSeconds(-10))
                    {
                        Console.WriteLine("{0}. {1}" ,i, lb.AgregatorCode);
                        listAgr.Add((lb.Id).ToString());
                        i++;
                    }

                }

            }

            return listAgr;
        }



        public string CheckChosenAgregator(List<string> listagr, string agregatorID)
        {
            try
            {
                int.Parse(agregatorID);
            }
            catch
            {
                throw new ArgumentOutOfRangeException("It must be number.");
            }

            AgregatorBase entity;
            
            using (var aData = new AgregatorBaseDBContex())
            {
                do
                {
                    agregatorID = (Int32.Parse(agregatorID) - 1).ToString();
                    string agrID = listagr[Int32.Parse(agregatorID)];
                    entity = aData.AgregatorBaseData.Find(Int32.Parse(agrID));

                    if (entity == null)
                    {
                        Console.WriteLine("Incorect format. Try again. \n->");
                        agregatorID = Console.ReadLine();
                    }

                } while (entity == null);
            }

            return entity.AgregatorCode;
        }

    }
}
