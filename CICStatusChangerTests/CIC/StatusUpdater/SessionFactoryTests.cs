using Microsoft.VisualStudio.TestTools.UnitTesting;
using CICStatusChanger.CIC.StatusUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ININ.IceLib.Connection;

namespace CICStatusChanger.CIC.StatusUpdater.Tests
{
    [TestClass()]
    public class SessionFactoryTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var result = SessionFactory.Get();
            Assert.AreEqual("StatusChangerApp", result.GetSessionSettings().ApplicationName);
            Assert.AreEqual("StatusChangerAppId", result.GetSessionSettings().ApplicationTraceId);
            Assert.AreEqual("indyhqic", result.GetHostSettings().HostEndpoint.Host);
            Assert.IsNotNull(result.GetAuthSettings());
        }
    }
}