using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Common.Enums;

namespace AMIAgregator
{
    class Agregator : IAMIAgregator
    {
        public string agregatorCode { get; set; }
        public State state { get ; set; }

        
    
        public Agregator()
        {
            state = State.on;
            agregatorCode = GetHashCode().ToString();
            bool postoji = false;
            Console.WriteLine("----Creating new Agregator----");
                foreach(KeyValuePair<string, Dictionary<MeasureType,double>> c in Datas.agregators)
                {
                    if (c.Key.Equals(agregatorCode))
                    {
                        postoji = true;
                        break;
                    }
                }

            if (!postoji)
            {
                Datas.agregators.Add(agregatorCode, new Dictionary<MeasureType, double>());
            }
            Console.WriteLine("+New Agregator with "+agregatorCode+" is created");

        }

        public void Send(string code, DateTime timestamp, Dictionary<Enums.MeasureType, double> measurements)
        {

            using (XmlWriter writer = XmlWriter.Create("measutements.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Employees");

                foreach (Employee employee in employees)
                {
                    writer.WriteStartElement("Employee");

                    writer.WriteElementString("ID", employee.Id.ToString());
                    writer.WriteElementString("FirstName", employee.FirstName);
                    writer.WriteElementString("LastName", employee.LastName);
                    writer.WriteElementString("Salary", employee.Salary.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();



            }

        public void turnOff()
        {
            if(state == State.on)
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
