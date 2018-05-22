using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace AMIAgregator
{
    class Program
    {
        static void Main(string[] args)
        {

            IAMIAgregator agregator = new Agregator();
            IAMIAgregator agregator1 = new Agregator();
            IAMIAgregator agregator2 = new Agregator();

           /* Dictionary<MeasureType, double> d = new Dictionary<MeasureType, double>();
            d.Add(MeasureType.voltage, 234);
            d.Add(MeasureType.reactivePower, 32);
            d.Add(MeasureType.activePower, 200);
            d.Add(MeasureType.electricity, 100);


            agregator.Send("23451240", DateTime.Now, d);*/

            Console.ReadLine();

        }
    }
}
