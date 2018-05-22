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
        static void Main(string[] args)
        {
            IDevice device = new Device();
            Console.WriteLine("code: {0} \n time:{1}\n state:{2} measure: ", device.DeviceCode, device.TimeStamp, device.DeviceState);


            ChannelFactory<IAMIAgregator> factory = new ChannelFactory<IAMIAgregator>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:" + Device.gdeSeKacim + "/IAMIAgregator"));

            IAMIAgregator proxy = factory.CreateChannel();

            while (true)
            {
                proxy.Send(device.DeviceCode, device.TimeStamp, device.measurements);
             
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
