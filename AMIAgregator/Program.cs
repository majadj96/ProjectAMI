using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Common.Enums;

namespace AMIAgregator
{
    public class Program
    {
        static void Main(string[] args)
        {

            IAMIAgregator agregator = new Agregator(1);
            CreateChannelAgregator createChannelAgregator = new CreateChannelAgregator();
            ServicePart service = new ServicePart();
            service.Open();
            
            Task t1 = new Task(() =>
            {
                while (true)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        agregator.turnOff(Enums.State.on);
                        Console.WriteLine("Agregator is turned off at {0}", DateTime.Now);
                        service.Close();
                    }
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        agregator.turnOn(Enums.State.off);
                        Console.WriteLine("Agregator is turned on at {0}", DateTime.Now);
                        service = new ServicePart();
                        service.Open();
                    }
                }
            });

            Task t2 = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    using (var data = new AgregatorBaseDBContex())
                    {
                        AgregatorBase agr = data.AgregatorBaseData.Where(d => d.AgregatorCode == agregator.agregatorCode).First();
                        agr.Time = DateTime.Now.ToString();
                        data.SaveChanges();
                      

                    }
                }
            });

            t1.Start();
            t2.Start();
         
            while (true)
            {

                if (agregator.state == Enums.State.on)
                {

                    string path = @"..\configurabileTime.txt";
                    string text = System.IO.File.ReadAllText(path);
                    int time = Int32.Parse(text);
                    Thread.Sleep(time * 60000);

                    Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorDataLocal = new Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<MeasureType, double>>>>();

                    
                    try
                    {

                        agregatorDataLocal = ReadFromLocal(agregator); //citanje lokalne baze 

                        CreateChannelAgregator.proxy = CreateChannelAgregator.factory.CreateChannel();
                        CreateChannelAgregator.proxy.Send(agregator.agregatorCode,agregatorDataLocal); //slanje globalnoj
                        Console.WriteLine("Measurements for Agregator [{0}] are sent.", agregator.agregatorCode);

                        DeleteFromLocal(agregator); // brisanje iz lokalne
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("System Management is off");

                    }
                
                }
            }
         


            Console.ReadLine();

        }

        public static void DeleteFromLocal(IAMIAgregator agregator)
        {
            using (var data = new LocalBaseDBContex())
            {


                var AgregatorBase = from d in data.LocalBaseData select d;


                foreach (var lb in AgregatorBase)
                {
                    if (lb.AgregatorCode == agregator.agregatorCode)
                    {
                        data.LocalBaseData.Remove(lb);

                    }
                }
                Console.WriteLine("Measurements for Agregator [{0}] are deleted from LocalDataBase.", agregator.agregatorCode);
                data.SaveChanges();
            }
        }


        public static Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> ReadFromLocal(IAMIAgregator agregator)
        {
            Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorDataLocal = new Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<MeasureType, double>>>>();

            Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>> deviceMeasurements = new Dictionary<string, Dictionary<DateTime, Dictionary<MeasureType, double>>>();
            Dictionary<DateTime, Dictionary<Enums.MeasureType, double>> list = new Dictionary<DateTime, Dictionary<MeasureType, double>>();

            using (var data = new LocalBaseDBContex())
            {
                var AgregatorBase = from d in data.LocalBaseData select d;

                foreach (var lb in AgregatorBase)
                {
                    if (lb.AgregatorCode == agregator.agregatorCode)
                    {
                        Dictionary<MeasureType, double> measurement = new Dictionary<MeasureType, double>();
                        measurement.Add(MeasureType.voltage, lb.Voltage);
                        measurement.Add(MeasureType.electricity, lb.Eletricity);
                        measurement.Add(MeasureType.reactivePower, lb.ReactivePower);
                        measurement.Add(MeasureType.activePower, lb.ActivePower);
                        list.Add(DateTime.Parse(lb.TimeStamp), measurement);
                        deviceMeasurements[lb.DeviceCode] = list;
                    }
                }

            }

            agregatorDataLocal[DateTime.Now] = deviceMeasurements;
            return agregatorDataLocal;
        }


    }
}
