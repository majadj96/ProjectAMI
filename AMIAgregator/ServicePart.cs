using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AMIAgregator
{
    public class ServicePart
    {
        private static ServiceHost serviceHost;
        public ServicePart()
        {
            serviceHost = new ServiceHost(typeof(Agregator));
            serviceHost.AddServiceEndpoint(typeof(IAMIAgregator), new NetTcpBinding(), new Uri("net.tcp://localhost:8000/IAMIAgregator"));
        }

        public void Open()
        {
            serviceHost.Open();
        }

        public void Close()
        {
            serviceHost.Close();
        }

    }
}
