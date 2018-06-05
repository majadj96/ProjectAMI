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
        public static List<String> type = new List<String>() { "Voltage", "Eletricity", "Active power","Reactve power" };

        public static List<String> agregatorsCombo = new List<string>();


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

    }
}
