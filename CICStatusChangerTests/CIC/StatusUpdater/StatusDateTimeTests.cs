using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CICStatusChanger.CIC.StatusUpdater;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace CICStatusChanger.CIC.StatusUpdater.Tests
{
    [TestClass()]
    public class StatusDateTimeTests
    {
        private static DateTime Today => DateTime.Today;
        private readonly DateTime FakeTime = new DateTime(2017, 3, 22, 15, 30, 20);

        public IStatusDateTime StatusDateTime;

        [TestInitialize]
        public void TestInitialize()
        {
            StatusDateTime = new StatusDateTime(TestUtils.MockTimeProvider(FakeTime));
        }

        [TestMethod()]
        public void StatusIsSetOnGoneHomeOnTheWeekendTest()
        {
            var statusDateTime = new StatusDateTime(TestUtils.MockTimeProvider(new DateTime(2017, 3, 25, 12, 20, 0)));
            var result1 = statusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 25, 15, 33, 0));
            var result2 = statusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 25, 12, 20, 0));
            var result3 = statusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 25, 9, 30, 0));
            var result4 = statusDateTime.IsInLunchTime(new DateTime(2017, 3, 25, 9, 30, 0));
            var result5 = statusDateTime.IsInWorkingHoursTime(new DateTime(2017, 3, 25, 9, 30, 0));
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
            Assert.IsFalse(result5);
        }

        [TestMethod()]
        public void IsInGoneHomeTimeTest()
        {
            var result1 = StatusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 22, 17, 55, 0));
            var result2 = StatusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 22, 17, 45, 0));
            var result3 = StatusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 22, 6, 30, 0));
            var result4 = StatusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 22, 12, 56, 0));
            var result5 = StatusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 22, 17, 30, 0));
            var result6 = StatusDateTime.IsInGoneHomeTime(new DateTime(2017, 3, 22, 15, 33, 0));

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
            Assert.IsFalse(result5);
            Assert.IsFalse(result6);
        }

        [TestMethod()]
        public void IsInWorkingHoursTimeTest()
        {
            var result = StatusDateTime.IsInWorkingHoursTime(new DateTime(2017, 3, 22, 11, 59, 0));
            var result2 = StatusDateTime.IsInWorkingHoursTime(new DateTime(2017, 3, 22, 13, 1, 0));
            var result3 = StatusDateTime.IsInWorkingHoursTime(new DateTime(2017, 3, 22, 17, 30, 0));
            var result4 = StatusDateTime.IsInWorkingHoursTime(new DateTime(2017, 3, 22, 17, 55, 0));
            var result5 = StatusDateTime.IsInWorkingHoursTime(new DateTime(2017, 3, 22, 17, 45, 0));
            Assert.IsTrue(result);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
            Assert.IsFalse(result5);
        }

        [TestMethod()]
        public void IsInLunchTimeTest()
        {
            var result = StatusDateTime.IsInLunchTime(new DateTime(2017, 3, 22, 12, 20, 0));
            var result2 = StatusDateTime.IsInLunchTime(new DateTime(2017, 3, 22, 12, 0, 0));
            var result3 = StatusDateTime.IsInLunchTime(new DateTime(2017, 3, 22, 13, 0, 0));
            Assert.IsTrue(result);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod()]
        public void IsInLunchTimeTest_IsNotTest()
        {
            var result = StatusDateTime.IsInLunchTime(new DateTime(2017, 3, 22, 14, 20, 0));
            var result2 = StatusDateTime.IsInLunchTime(new DateTime(2017, 3, 22, 13, 1, 0));
            var result3 = StatusDateTime.IsInLunchTime(new DateTime(2017, 3, 22, 18, 30, 0));
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod()]
        public void AtTimeTest()
        {
            var result = StatusDateTime.AtTime(17, 0, 0);
            Assert.AreEqual(2017, result.Year);
            Assert.AreEqual(3, result.Month);
            Assert.AreEqual(22, result.Day);
            Assert.AreEqual(result.Hour, 17);
            Assert.AreEqual(result.Minute, 0);
            Assert.AreEqual(result.Second, 0);
        }
    }
}