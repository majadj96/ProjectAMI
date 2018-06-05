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
    public interface ISystemManagement
    {
        State state { get; set; }

        void turnOn();
        void turnOff();
        [OperationContract]
        void Send(string agregatorCode, Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorData);




    }
}
