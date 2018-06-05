using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMIDevice
{
    public class CreateChannelDevice
    {

        public static IAMIAgregator proxy;
        public static ChannelFactory<IAMIAgregator> factory;

        public CreateChannelDevice(string port)
        {
            factory = new ChannelFactory<IAMIAgregator>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:"+port+"/IAMIAgregator"));
            proxy = factory.CreateChannel();
        }
    }
}
