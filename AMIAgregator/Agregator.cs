using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMIAgregator
{
    class Agregator : IAMIAgregator
    {
        public string agregatorCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Send(string code, DateTime timestamp, System.Collections.Generic.Dictionary<object> )
        {
            throw new NotImplementedException();
        }

        public void turnOff()
        {
            throw new NotImplementedException();
        }

        public void turnOn()
        {
            throw new NotImplementedException();
        }
    }
}
