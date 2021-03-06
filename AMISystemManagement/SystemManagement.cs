﻿using Common;
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

        public SystemManagement() { state = State.on; }

        public SystemManagement(State s)
        {
            state = s;
        }

        public void Send(string agregatorCode, Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorData)
        {
            if (agregatorCode.Length != 4)
            {
                throw new ArgumentException("Invalid code");
            }

            
            try
            {
                int.Parse(agregatorCode);
                
            }
            catch
            {
                throw new ArgumentOutOfRangeException("It must be number.");
            }



            if (agregatorData.Count <= 0)
            {
                try { }
                catch (Exception e)
                {
                    throw new ArgumentException("Dictionary is empty.");
                }
            }
            
            using (var data = new GlobalBaseDBContex())
            {
                foreach(KeyValuePair<DateTime,Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> prvi in agregatorData)
                {
                    
                    foreach(KeyValuePair<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>> drugi in prvi.Value)
                    {
                        foreach (KeyValuePair<DateTime, Dictionary<Enums.MeasureType, double>> treci in drugi.Value) {

                              
                                GlobalBase gb = new GlobalBase()
                                {
                                    AgregatorCode = agregatorCode,
                                    TimeStamp = prvi.Key.ToString(),
                                    DeviceCode = drugi.Key,
                                    DeviceTime = treci.Key.ToString(),
                                    Voltage = treci.Value[MeasureType.voltage],
                                    Eletricity = treci.Value[MeasureType.electricity],
                                    ActivePower = treci.Value[MeasureType.activePower],
                                    ReactivePower = treci.Value[MeasureType.reactivePower]

                                };

                                data.GlobalBaseData.Add(gb);
                                data.SaveChanges();
                            

                        }
                        
                        
                    }
                }
                
            }

            Console.WriteLine("Measurements for Agregator [{0}] are added in GlobalDataBase.", agregatorCode);
        }

        public bool turnOff()
        {
            
                if (this.state == Enums.State.on)
                {
                    this.state = Enums.State.off;
                    return true;
                }
            
            else
            {
               
               throw new ArgumentException("State is up to date");
              
            }
        }

        public bool turnOn()
        {
            if (this.state == Enums.State.off)
            {
                this.state = Enums.State.on;
                return true;
            }
            else
            {
               throw new ArgumentException("State is up to date");
               

            }
        }
    }
}
