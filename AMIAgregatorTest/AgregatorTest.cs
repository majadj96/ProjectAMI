using AMIAgregator;
using Common;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMIAgregatorTest
{
    [TestFixture]
    public class AgregatorTest
    {

        [Test]
        public void turnOnBadParameter()
        {
            IAMIAgregator agr2 = new Agregator(Enums.State.on);
            Assert.Throws<ArgumentException>(() =>
            {
                agr2.turnOn();
            });
        }


        [Test]
        public void turnOnGoodParameter()
        {
            IAMIAgregator agr2 = new Agregator(Enums.State.off);
            
                bool ret=agr2.turnOn();
            Assert.AreEqual(true, ret);


        }



        [Test]
        public void turnOffGoodParameter()
        {
            IAMIAgregator agr2 = new Agregator(Enums.State.on);

            bool ret = agr2.turnOff();
            Assert.AreEqual(true, ret);


        }


        [Test]
        public void turnOffBadParameter()
        {
            IAMIAgregator agr2 = new Agregator(Enums.State.off);
            Assert.Throws<ArgumentException>(() =>
            {
                agr2.turnOff();
            });
        }

    }
}
