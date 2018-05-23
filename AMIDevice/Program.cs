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
            d.measurements[Enums.MeasureType.electricity]= rand.Next(0, 34);// struja ide u rasponu od 0 do 30kWh
            d.measurements[Enums.MeasureType.voltage] = rand.Next(0, 244);
            d.measurements[Enums.MeasureType.activePower] = rand.Next(0, 102);
            d.measurements[Enums.MeasureType.reactivePower] = rand.Next(0, 103);
            d.TimeStamp = DateTime.Now;

        }

        static void Main(string[] args)
        {
            IDevice device = new Device();
            Console.WriteLine("code: {0} \n time:{1}\n state:{2} measure: ", device.DeviceCode, device.TimeStamp, device.DeviceState);


            ChannelFactory<IAMIAgregator> factory = new ChannelFactory<IAMIAgregator>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:" + Device.gdeSeKacim + "/IAMIAgregator"));

            IAMIAgregator proxy = factory.CreateChannel();

            while (true)
            {
                proxy.Send(device.DeviceCode, device.TimeStamp, device.measurements);
                Update(device);
                Thread.Sleep(10000);
            }

            /*foreach (var v in device.measurements)
            {
                Console.WriteLine("{0} : {1}", v.Key, v.Value);
            }
            */
            Console.ReadKey();
        }
    }
}
