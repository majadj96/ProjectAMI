using AMIAgregator;
using Common;
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
        public static Dictionary<Enums.MeasureType, double> measurements = new Dictionary<Enums.MeasureType, double>();
        public static Dictionary<Enums.MeasureType, double> measurements1 = new Dictionary<Enums.MeasureType, double>() { { Enums.MeasureType.activePower,300} };
        public static Dictionary<Enums.MeasureType, double> measurements3 = new Dictionary<Enums.MeasureType, double>() { { Enums.MeasureType.reactivePower, 300 } };

        public static Dictionary<Enums.MeasureType, double> measurements2 = null;

        //Prvi test - timestamp out
        [Test]
        [TestCase("1111", 1546300803, "2222")] 
        [TestCase("2222", 1528236930, "1111")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SendTestBad1(string code, long timestamp, string codeAgr)
        {
            IAMIAgregator agregator = new Agregator();
            if(timestamp== 1546300803)
            agregator.Send(code, timestamp, measurements1, codeAgr);
            if (timestamp == 1528236930)
                agregator.Send(code, timestamp, measurements3, codeAgr);

        }

        //Drugi test - Prazan diksnari
        [Test]
        [TestCase("1111", 1528236933, "1111")]
        [ExpectedException(typeof(ArgumentException))]
        public void SendTestBad3(string code, long timestamp, string codeAgr)
        {
            measurements1.Add(Enums.MeasureType.activePower, 300);
            IAMIAgregator agregator = new Agregator();
            agregator.Send(code, timestamp, measurements, codeAgr);
        }

        //Treci test - null diksnari
        [Test]
        [TestCase("2222", 1528236938, "2222")]
        [ExpectedException(typeof(NullReferenceException))]
        public void SendTestBad(string code, long timestamp, string codeAgr)
        {
            IAMIAgregator agregator = new Agregator();
            agregator.Send(code, timestamp, measurements2, codeAgr);
        }

        [Test]
        [TestCase("22222", 1528236936, "1111")]
        [TestCase("22222", 1528236936, "11211")]
        [TestCase("2222", 1528236936, "11131")]
        [TestCase("aaa", 1528236936, "a")]
        [ExpectedException(typeof(ArgumentException))]
        public void SendTestBad4(string code, long timestamp, string codeAgr)
        {
            IAMIAgregator agregator = new Agregator();
                agregator.Send(code, timestamp, measurements, codeAgr);
         

        }

        [TestCase("aaaa", 1528236936, "sssa")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SendTestBad5(string code, long timestamp, string codeAgr)
        {
            IAMIAgregator agregator = new Agregator();
            agregator.Send(code, timestamp, measurements, codeAgr);


        }
        //Ako je kod manji od 4 i veci od 4
        [Test]
        [TestCase("11111")]
        [TestCase("11")]
        [ExpectedException(typeof(ArgumentException))]
        public void addAgregatorBad(string code)
        {
            Agregator agregator = new Agregator();
            agregator.addAgregator(code);            
        }

        //Ukoliko kod nije broj
        [Test]
        [TestCase("aaaa")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void addAgregatorBad1(string code)
        {
            Agregator agregator = new Agregator();
            agregator.addAgregator(code);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [ExpectedException(typeof(OutOfMemoryException))]
        public void KonstrunktorAgregatoraBad(int e)
        {
            IAMIAgregator agregator = new Agregator(e);
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]

        public void KonstrunktorAgregatoraGood(int e)
        {
            IAMIAgregator agregator = new Agregator(e);
        }
       


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



/*
 * 
 * 

*/