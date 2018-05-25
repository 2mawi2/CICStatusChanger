using Microsoft.VisualStudio.TestTools.UnitTesting;
using CICStatusChanger.CIC.StatusUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICStatusChanger.CIC.StatusUpdater.Tests
{
    [TestClass()]
    public class RandomMinuteGeneratorTests
    {
        private RandomMinuteGenerator _randomGenerator;
        private readonly DateTime fakeTime = new DateTime(2017, 3, 22, 15, 30, 20);

        [TestInitialize]
        public void TestInitialize()
        {
            _randomGenerator = new RandomMinuteGenerator(TestUtils.MockTimeProvider(fakeTime));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _randomGenerator = null;
        }

        [TestMethod()]
        public void GetRandomTimeInIntervalTest_IsInRange()
        {
            var result = _randomGenerator.GetRandomTimeInInterval(5);
            Assert.IsTrue(result >= fakeTime.AddMinutes(-5));
            Assert.IsTrue(result <= fakeTime.AddMinutes(5));
            CheckIfSecondResultHasStillTheSameMinute();
        }

        private void CheckIfSecondResultHasStillTheSameMinute()
        {
            var result2 = _randomGenerator.GetRandomTimeInInterval(5);
            Assert.AreEqual(result2.Minute, result2.Minute);
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetRandomTimeInIntervalTest()
        {
            var result = _randomGenerator.GetRandomTimeInInterval(-1);
            Assert.IsInstanceOfType(result, typeof(DateTime));
        }
    }
}