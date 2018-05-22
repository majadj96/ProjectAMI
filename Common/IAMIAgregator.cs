using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IAMIAgregator
    {

        string agregatorCode { get; set; }


        void turnOn();
        void turnOff();
        bool Send(string code, DateTime timestamp, Dictionary<)
        

    }
}
