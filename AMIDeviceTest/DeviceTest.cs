using AMIDevice;
using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMIDeviceTest
{
    [TestFixture]
    public class DeviceTest
    {
        
        [Test]
        public void turnOnGoodParameter()
        {
            IDevice device = new Device(Enums.State.off);
         
            bool ret = device.turnOn();

            Assert.AreEqual(true, ret);
        
           }

        [Test]
        public void turnOnBadParameter()
        {
            IDevice device = new Device(Enums.State.on);

            Assert.Throws<ArgumentException>(() =>
            {
                bool ret = device.turnOn();
            });
           
        }

        [Test]
        public void turnOffGoodParameter()
        {
            IDevice device = new Device(Enums.State.on);

            bool ret = device.turnOff();

            Assert.AreEqual(true, ret);
            
        }

        [Test]
        public void turnOffBadParameter()
        {
            IDevice device = new Device(Enums.State.off);

            Assert.Throws<ArgumentException>(() =>
            {
                bool ret = device.turnOff();
            });

        }

       /* [Test]
        public void ReadAgregatorsFromBaseGood()
        {
            IDevice device = new Device();
            List<string> listagr = device.ReadAgregatorsFromBase();
            Assert.IsEmpty(listagr);

        }
        [Test]
        public void ReadAgregatorsFromBaseBad()
        {
            IDevice device = new Device();
            List<string> listagr = device.ReadAgregatorsFromBase();
            //Assert.IsNull(listagr);
           
            

        }

        [Test]
        [TestCase()]
        public void CheckChosenAgregatorGood()
        {
            IDevice device = new Device();
           // string ret = device.CheckChosenAgregator(listagr, agregatorID);
        }
        */
       


    }
}
