﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMISystemManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ISystemManagement systemManagement = new SystemManagement();
            ServicePart service = new ServicePart();
            service.Open();
            bool on = true;
            Task t1 = new Task(() =>
            {
                while (true)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        if (on)
                        {
                            on = false;
                            systemManagement.turnOff();
                            Console.WriteLine("System Management is turned off at {0}", DateTime.Now);
                            service.Close();
                        }
                    }
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    {
                        if (!on)
                        {
                            on = false;
                            systemManagement.turnOn();
                            Console.WriteLine("System Management is turned on at {0}", DateTime.Now);
                            service = new ServicePart();
                            service.Open();
                        }
                    }
                }
            });

            t1.Start();

            while (true)
            {
            }

                Console.ReadLine();
            
        }
    }
}
