using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace AMISystemManagement
{
    public class SystemManagement : ISystemManagement
    {
        public State state { get; set; }

        public SystemManagement() { }

        public SystemManagement(int e)
        {
            state = State.on;
        }

        public void Send(string agregatorCode, Dictionary<DateTime, Dictionary<string, List<Dictionary<Enums.MeasureType, double>>>> agregatorData)
        {
            using (var data = new GlobalBaseDBContex())
            {
                foreach(KeyValuePair<DateTime,Dictionary<string, List<Dictionary<Enums.MeasureType, double>>>> prvi in agregatorData)
                {
                    
                    foreach(KeyValuePair<string, List<Dictionary<Enums.MeasureType, double>>> drugi in prvi.Value)
                    {
                        for(int i=0; i < drugi.Value.Count; i++)
                        {
                          
                                GlobalBase gb = new GlobalBase()
                                {
                                    AgregatorCode = agregatorCode,
                                    TimeStamp = prvi.Key.ToString(),
                                    DeviceCode = drugi.Key,
                                    Voltage = drugi.Value[i][MeasureType.voltage],
                                    Eletricity = drugi.Value[i][MeasureType.electricity],
                                    ActivePower = drugi.Value[i][MeasureType.activePower],
                                    ReactivePower = drugi.Value[i][MeasureType.reactivePower]
                                    
                                };

                            data.GlobalBaseData.Add(gb);
                            data.SaveChanges();
                        }
                        
                    }
                }
                
            }
        }

        public void turnOff()
        {
            if (state == State.on)
            {
                state = State.off;
            }
        }

        public void turnOn()
        {
            if (state == State.off)
            {
                state = State.on;
            }
        }
    }
}
