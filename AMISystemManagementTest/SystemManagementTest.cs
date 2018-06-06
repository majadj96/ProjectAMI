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




        
    }
}
