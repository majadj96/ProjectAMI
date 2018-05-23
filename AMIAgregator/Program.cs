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

            IAMIAgregator agregator = new Agregator(1);

            ServicePart service = new ServicePart();
            service.Open();

            Console.ReadLine();

        }
    }
}
