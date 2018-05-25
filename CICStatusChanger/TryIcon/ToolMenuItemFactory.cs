using System.Windows.Forms;
using CICStatusChanger.Properties;

namespace CICStatusChanger.TryIcon
{
    public class ToolMenuItemFactory
    {
        private readonly ContextMenus _contextMenus;

        public ToolMenuItemFactory(ContextMenus contextMenus)
        {
            _contextMenus = contextMenus;
        }

        public static ToolStripMenuItem CreateExitButton(ToolStripMenuItem item)
        {
            item = new ToolStripMenuItem {Text = "Exit"};
            item.Click += ContextMenus.OnExitClick;
            item.Image = Resources.About;
            return item;
        }

        public ToolStripMenuItem CreateDisableItem(ToolStripMenuItem item)
        {
            item = new ToolStripMenuItem {Text = "Disable"};
            item.Click += _contextMenus.OnDisableClick;
            item.Image = Resources.Exit;
            return item;
        }

        public ToolStripMenuItem CreateEnableItem()
        {
            var item = new ToolStripMenuItem {Text = "Enable"};
            item.Click += _contextMenus.OnEnableClick;
            item.Image = Resources.enabled;
            return item;
        }
    }
}