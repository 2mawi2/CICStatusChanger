using System;
using System.Windows.Forms;
using CICStatusChanger.CIC.StatusUpdater;
using CICStatusChanger.TryIcon;

namespace CICStatusChanger
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            var statusChangerService = StatusServiceFactory.Get();

		    using (var pi = new ProcessIcon(statusChangerService))
			{
				pi.Display();
				Application.Run();
			}
		}
	}
}