using AMISystemManagement;
using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMISystemManagementTest
{
    [TestFixture]
    public class SystemManagementTest
    {
       
            [Test]
            public void turnOnGoodParameter()
            {
                ISystemManagement system = new SystemManagement(Enums.State.off);

                bool ret = system.turnOn();

                Assert.AreEqual(true, ret);

            }

            [Test]
            public void turnOnBadParameter()
            {
            ISystemManagement system = new SystemManagement(Enums.State.on);

            Assert.Throws<ArgumentException>(() =>
                {
                    bool ret = system.turnOn();
                });

            }


        [Test]
        public void turnOffGoodParameter()
        {
            ISystemManagement system = new SystemManagement(Enums.State.on);

            bool ret = system.turnOff();

            Assert.AreEqual(true, ret);

        }

        [Test]
        public void turnOffBadParameter()
        {
            ISystemManagement system = new SystemManagement(Enums.State.off);

            Assert.Throws<ArgumentException>(() =>
            {
                bool ret = system.turnOff();
            });

        }

        //public void Send(string agregatorCode, Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorData)
        

        //Prvi test - agregator code los
        [Test]
        [TestCase("11111")]
        [TestCase("222")]
        [ExpectedException(typeof(ArgumentException))]
        public void SendTestBad1(string agregatorCode)
        {
            Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorData = new Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>>();
            ISystemManagement system = new SystemManagement();
            system.Send(agregatorCode, agregatorData);
        }

        [Test]
        [TestCase("test")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SendTestBad2(string agregatorCode)
        {
            Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorData = new Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>>();
            ISystemManagement system = new SystemManagement();
            system.Send(agregatorCode, agregatorData);
        }


        //Drugi test - null diksnari
        [Test]
        [TestCase("2222")]
        [ExpectedException(typeof(NullReferenceException))]
        public void SendTestBad3(string agregatorCode)
        {
            Dictionary<DateTime, Dictionary<string, Dictionary<DateTime, Dictionary<Enums.MeasureType, double>>>> agregatorData = null;
            ISystemManagement system = new SystemManagement();
            system.Send(agregatorCode, agregatorData);
        }

        


    }
}
