using Microsoft.VisualStudio.TestTools.UnitTesting;
using CICStatusChanger.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CICStatusChanger.Common.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void ToSecureStringTest()
        {
            const string testString = "testPw";
            var result = testString.ToSecureString();
            Assert.AreEqual(testString.Length, result.Length);
            Assert.IsInstanceOfType(result, typeof(SecureString));
        }
    }
}