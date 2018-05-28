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
        public static ModelDBContex db = new ModelDBContex();
        static void Main(string[] args)
        {

            IAMIAgregator agregator = new Agregator(1);

            ServicePart service = new ServicePart();
            service.Open();
            
            Task t1 = new Task(() =>
            {
                while (true)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        agregator.turnOff();
                        Console.WriteLine("Agregator is turned off at {0}", DateTime.Now);
                        service.Close();
                    }
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        agregator.turnOn();
                        Console.WriteLine("Agregator is turned on at {0}", DateTime.Now);
                        service = new ServicePart();
                        service.Open();
                    }
                }
            });

            t1.Start();

            while (true)
            {
                if (agregator.state == Enums.State.on)
                {
                   // proxy.Send(device.DeviceCode, device.TimeStamp, device.measurements, device.myAgregator);
                    Thread.Sleep(5*3600);
                }
            }
            
            Console.ReadLine();

        }
    }
}
