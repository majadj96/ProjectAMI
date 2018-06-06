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
        [TestCase(Enums.State.off)]
        [TestCase(1)]
        public void turnOnGoodParameter(Enums.State DeviceState)
        {
            Device deviceTest = new Device();
            deviceTest.turnOn(DeviceState);
        }



        [Test]
        [TestCase(Enums.State.on)]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase("text")]
        [ExpectedException(typeof(ArgumentException))]

        public void turnOnBadParameter(Enums.State DeviceState)
        {
            Device deviceTest = new Device();
            deviceTest.turnOn(DeviceState);
        }

        [TestCase(Enums.State.on)]
        [TestCase(0)]
        public void turnOffGoodParameter(Enums.State DeviceState)
        {
            Device deviceTest = new Device();
            deviceTest.turnOn(DeviceState);
        }



        [Test]
        [TestCase(Enums.State.off)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase("text")]
        [ExpectedException(typeof(ArgumentException))]

        public void turnOffBadParameter(Enums.State DeviceState)
        {
            Device deviceTest = new Device();
            deviceTest.turnOn(DeviceState);
        }



      

    }
}
