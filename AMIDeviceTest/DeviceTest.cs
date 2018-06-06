using AMIDevice;
using Common;
using Moq;
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
        IDevice device1;
        IDevice device2;

        [SetUp]
        public void Setup()
        {
            var moq = new Mock<IDevice>();
            moq.Setup(d => d.DeviceState).Returns(Enums.State.on);
            device1 = moq.Object;
            var moq2 = new Mock<IDevice>();
            moq2.Setup(d => d.DeviceState).Returns(Enums.State.off);
            device2 = moq2.Object;
        }
        
        [Test]
        public void turnOnGoodParameter()
        {
            IDevice device22 = new Device(Enums.State.off);
         
            bool ret = device22.turnOn();

            Assert.AreEqual(true, ret);
        
           }

        [Test]
        public void turnOnBadParameter()
        {
            IDevice device22 = new Device(Enums.State.on);

            Assert.Throws<ArgumentException>(() =>
            {
                bool ret = device22.turnOn();
            });
           
        }

       
      

    }
}
