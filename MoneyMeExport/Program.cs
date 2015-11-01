using System;
using Gtk;

namespace MoneyMeExport
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			try {
				Application.Init ();
				MainWindow win = new MainWindow ();
				//MoneyMeQuery mmq = new MoneyMeQuery ();
				//mmq.SubscribeToMainWinEvents (win);
				win.DataReady += win.SaveProcessedData;

				win.Show ();
				Application.Run ();
			} catch(Exception e) {
				Console.WriteLine ("Exception {0}", e.Message);
				Application.Quit ();
			}
		}
	}
}
