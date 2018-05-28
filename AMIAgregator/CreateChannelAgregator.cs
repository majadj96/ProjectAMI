using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMIAgregator
{
    public class CreateChannelAgregator
    {
        public static ISystemManagement proxy;
        public static ChannelFactory<ISystemManagement> factory;
        public CreateChannelAgregator()
        {
            factory = new ChannelFactory<ISystemManagement>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:10100/ISystemManagement"));
            proxy = factory.CreateChannel();
        }
    }
}
