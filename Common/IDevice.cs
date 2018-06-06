﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public interface IDevice
    {
        string DeviceCode { get; set; }
        long TimeStamp { get; set; }
        Dictionary<Enums.MeasureType, double> measurements { get; set; }
        Enums.State DeviceState { get; set; }
        string myAgregator { get; set; }

        void turnOn(Enums.State DeviceState);
        void turnOff(Enums.State DeviceState);
    }
}
