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
                device.turnOn();
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
                device.turnOff();
            });

        }

        List<string> listagr = new List<string>();
        [Test]
        [TestCase("a")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckChosenAgregatorBad(string agregatorID)
        {
            IDevice device = new Device(Enums.State.on);
            device.CheckChosenAgregator(listagr, agregatorID);
        }

        [Test]
        [TestCase("11111","22222")]
        [TestCase("1", "2")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckLocalBaseBad(string myAgregator, string DeviceCode)
        {
            IDevice device = new Device(Enums.State.on);
            device.CheckLocalBase(myAgregator, DeviceCode);

        }



        [Test]
        [TestCase("bbbb", "aaaa")]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckLocalBaseBad2(string myAgregator, string DeviceCode)
        {
            IDevice device = new Device(Enums.State.on);
            device.CheckLocalBase(myAgregator, DeviceCode);

        }

    }
}
