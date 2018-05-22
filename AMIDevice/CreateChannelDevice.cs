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

        public CreateChannelDevice(string port)
        {
            ChannelFactory<IAMIAgregator> factory = new ChannelFactory<IAMIAgregator>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:"+port+"/IAMIAgregator"));

            IAMIAgregator proxy = factory.CreateChannel();
        }
    }
}
