#region Usings

using System;
using System.Windows.Forms;

#endregion

namespace Quik.TransactionsManager.TestApp
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TestForm());
		}
	}
}
