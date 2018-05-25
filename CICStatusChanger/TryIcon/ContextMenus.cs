using System;
using System.Windows.Forms;
using CICStatusChanger.CIC.StatusUpdater;

namespace CICStatusChanger.TryIcon
{
    public class ContextMenus
    {
        private readonly ToolMenuItemFactory _toolMenuItemFactory;
        private readonly IStatusService _statusChangerService;
        private readonly Action<bool> _changeIconCallback;

        public ContextMenus(IStatusService statusChangerService, Action<bool> changeIconCallback = null)
        {
            _statusChangerService = statusChangerService;
            _changeIconCallback = changeIconCallback;
            _toolMenuItemFactory = new ToolMenuItemFactory(this);
            _statusChangerService.Enable();
        }

        public ContextMenuStrip Create()
        {
            return CreateMenu();
        }

        private ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();

            var item = _toolMenuItemFactory.CreateEnableItem();
            menu.Items.Add(item);

            item = _toolMenuItemFactory.CreateDisableItem(item);
            menu.Items.Add(item);

            var sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            item = ToolMenuItemFactory.CreateExitButton(item);
            menu.Items.Add(item);

            return menu;
        }

        public void OnEnableClick(object sender, EventArgs e)
        {
            _changeIconCallback?.Invoke(true);
            _statusChangerService.Enable();
        }

        public void OnDisableClick(object sender, EventArgs e)
        {
            _changeIconCallback?.Invoke(false);
            _statusChangerService.Disable();
        }

        public static void OnExitClick(object sender, EventArgs e) => Application.Exit();
    }
}