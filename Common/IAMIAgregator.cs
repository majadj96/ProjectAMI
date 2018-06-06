using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace Common
{
    [ServiceContract]
    public interface IAMIAgregator
    {

        string agregatorCode { get; set; }
        State state { get; set; }
        bool turnOn();
        bool turnOff();
        [OperationContract]
        void Send(string code, long timestamp, Dictionary<MeasureType, double> measurements,string codeAgr); // ***DODAT AGREGATOR CODE***
        

    }
}
