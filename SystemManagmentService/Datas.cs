using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagmentService
{
   public class Datas
    {
        public static List<String> type = new List<String>() { "Voltage", "Eletricity", "Active power","Reactive power" };
        public static List<String> operators = new List<String>() { ">", "<"};

        public static List<String> agregatorsCombo = new List<string>();
        public static List<String> devicesCombo = new List<string>();


        public static List<string> loadAgregatorsFromDataBase()
        {
            List<string> agregators = new List<string>();


            using (var data = new GlobalBaseDBContex())
            {
                var AgregatorBase = from d in data.GlobalBaseData select d;

                foreach (var lb in AgregatorBase)
                {
                    if (!agregators.Contains(lb.AgregatorCode))
                    {
                        agregators.Add(lb.AgregatorCode);
                    }
                }
            }
            return agregators;
        }

        public static List<string> loadDevicesFromDataBase()
        {
            List<string> devices = new List<string>();

            using (var data = new GlobalBaseDBContex())
            {
                var Global = from d in data.GlobalBaseData select d;
                foreach(var torka in Global)
                {
                    if (!devices.Contains(torka.DeviceCode))
                    {
                        devices.Add(torka.DeviceCode);
                    }
                }
            }
           
            return devices;
        }

    }
}
