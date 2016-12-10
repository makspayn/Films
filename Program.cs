using System;
using System.Windows.Forms;
using Films.Forms;

namespace Films
{
	static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(MainForm.GetInstance());
		}
	}
}