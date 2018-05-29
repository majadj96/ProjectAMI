using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AMIDevice
{
    class Program
    {

        public static void Update(IDevice d)
        {
            Random rand = new Random();
            d.measurements[Enums.MeasureType.electricity]= rand.Next(0, 34);
            d.measurements[Enums.MeasureType.voltage] = rand.Next(0, 244);
            d.measurements[Enums.MeasureType.activePower] = rand.Next(0, 102);
            d.measurements[Enums.MeasureType.reactivePower] = rand.Next(0, 103);
            d.TimeStamp = DateTime.Now;
        }

        static void Main(string[] args)
        {
            IDevice device = new Device();
            CreateChannelDevice createChannelDevice = new CreateChannelDevice(device.myAgregator);

            Task t1 = new Task(() =>
            {
                while (true)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        device.turnOff();
                        Console.WriteLine("Device is turned off at {0}", DateTime.Now);
                    }
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        device.turnOn();
                        Console.WriteLine("Device is turned on at {0}", DateTime.Now);
                    }
                }
            });

            t1.Start();

        
            while (true)
            {
            
                if (device.DeviceState == Enums.State.on)
                {
                    Thread.Sleep(30000);
                    try
                    {
                        CreateChannelDevice.proxy = CreateChannelDevice.factory.CreateChannel();
                        CreateChannelDevice.proxy.Send(device.DeviceCode, device.TimeStamp, device.measurements, device.myAgregator);
                        Console.WriteLine("Message sent in {0}.",device.TimeStamp);
                    }catch(Exception e)
                    {
                        Console.WriteLine("Agregator is not available at the moment, please try later.");

                    }
                    
            
                }
                Update(device);
            }
         
            Console.ReadKey();
        }
        
    }
}
