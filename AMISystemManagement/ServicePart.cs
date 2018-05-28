using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMISystemManagement
{
    public class ServicePart
    {
        private static ServiceHost serviceHost;
        public ServicePart()
        {
            serviceHost = new ServiceHost(typeof(SystemManagement));
            serviceHost.AddServiceEndpoint(typeof(ISystemManagement), new NetTcpBinding(), new Uri("net.tcp://localhost:10100/ISystemManagement"));
        }
        public void Open()
        {
            Console.WriteLine("Service host is opened.");
            serviceHost.Open();
        }

        public void Close()
        {
            serviceHost.Close();
        }

    }
}
