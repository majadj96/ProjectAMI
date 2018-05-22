using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace Common
{
    public interface IAMIAgregator
    {

        string agregatorCode { get; set; }
        State state { get; set; }
        void turnOn();
        void turnOff();
        void Send(string code, DateTime timestamp, Dictionary<MeasureType, double> measurements);
        

    }
}
