using System;
using System.Windows.Forms;
using CICStatusChanger.CIC.StatusUpdater;
using CICStatusChanger.Properties;

namespace CICStatusChanger.TryIcon
{
    internal class ProcessIcon : IDisposable
	{
	    private readonly NotifyIcon _ni;
	    private readonly IStatusService _statusChangerService;

	    public ProcessIcon(IStatusService statusChangerService)
	    {
	        _statusChangerService = statusChangerService;
	        _ni = new NotifyIcon();
	    }
        
		public void Display()
		{
			_ni.MouseClick += MouseClick;
			_ni.Icon = Resources.glenn;
			_ni.Visible = true;
			_ni.ContextMenuStrip = new ContextMenus(_statusChangerService, ChangeIconCallback).Create();
		}

	    public void ChangeIconCallback(bool isActive = false)
	    {
            _ni.Icon = isActive ? Resources.glenn : Resources.SystemTrayApp;
        }

		public void Dispose() => _ni.Dispose();

	    private static void MouseClick(object sender, MouseEventArgs e)
		{
		}
	}
}