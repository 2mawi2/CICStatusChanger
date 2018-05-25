using Microsoft.VisualStudio.TestTools.UnitTesting;
using CICStatusChanger.TryIcon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CICStatusChanger.CIC.StatusUpdater;

namespace CICStatusChanger.TryIcon.Tests
{
    [TestClass()]
    public class ContextMenusTests
    {
        private ContextMenus _contextMenus;

        [TestInitialize]
        public void TestInitialize()
        {
            var timeProvider = TestUtils.MockTimeProvider();
            _contextMenus = new ContextMenus(new StatusService(new StatusDateTime(timeProvider), new RandomMinuteGenerator(timeProvider)));
        }

        [TestMethod()]
        public void CreateTest()
        {
            var result = _contextMenus.Create();
            Assert.AreEqual(4, result.Items.Count);
            Assert.IsInstanceOfType(result.Items[0], typeof(ToolStripMenuItem));
            Assert.IsInstanceOfType(result.Items[1], typeof(ToolStripMenuItem));
            Assert.IsInstanceOfType(result.Items[2], typeof(ToolStripSeparator));
            Assert.IsInstanceOfType(result.Items[3], typeof(ToolStripMenuItem));
        }
    }
}