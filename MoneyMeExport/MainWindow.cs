using System;
using System.IO;
using Gtk;
using MoneyMeExport;

public partial class MainWindow: Gtk.Window
{	
	// Processed data is available!
	public delegate void DataReadyHandler (string data);
	public event DataReadyHandler DataReady;

	private uint statusBarContextId;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		DateTime now = DateTime.Now;
		entryBegin.Text = now.ToString("yyyy-MM") + "-01";
		entryEnd.Text = now.ToString ("yyyy-MM-dd");

		this.statusBarContextId = statusbar.GetContextId ("MainWindow");
		statusbar.Push (this.statusBarContextId, "Ready");
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnMenuExit (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	protected void OnMenuFileOpen (object sender, EventArgs e)
	{
		// Create and display a fileChooserDialog
		FileChooserDialog chooser = new FileChooserDialog(
			"Please select a file to open ...",
			this,
			FileChooserAction.Open,
			"Cancel", ResponseType.Cancel,
			"Open", ResponseType.Accept );

		if( chooser.Run() == ( int )ResponseType.Accept )
		{
			MoneyMeQuery mmq = new MoneyMeQuery (chooser.Filename);
			string[] startDateComponents = this.entryBegin.Text.Split ('-');
			string[] endDateComponents = this.entryEnd.Text.Split ('-');

			try {
				mmq.setStartDate (new DateTime (Int32.Parse (startDateComponents [0]),
				                                Int32.Parse (startDateComponents [1]),
				                                Int32.Parse (startDateComponents [2])
												)
								);
				mmq.setEndDate (new DateTime (Int32.Parse (endDateComponents [0]),
				                              Int32.Parse (endDateComponents [1]),
				                              Int32.Parse (endDateComponents [2])
				                              )
				                );
				chooser.Hide();

				// Update status bar message
				statusbar.Pop (this.statusBarContextId);
				statusbar.Push (this.statusBarContextId, "Ready");

				if (this.DataReady != null) {
					this.DataReady (mmq.ToString());
				}

			} catch (Exception ex) {
				// Show error in status bar
				statusbar.Pop (this.statusBarContextId);
				statusbar.Push (this.statusBarContextId, "Error");

				chooser.Hide ();
				MessageDialog md = new MessageDialog (
					this, DialogFlags.Modal, MessageType.Error, ButtonsType.Close, ex.Message, "");
				md.Run ();
				md.Destroy ();

				Console.WriteLine("Error: " + ex.Message);
			}
		}
		chooser.Destroy();
	}

	public void SaveProcessedData(string data)
	{
		FileChooserDialog saver = new FileChooserDialog(
			"Please select a destination file ...",
			this,
			FileChooserAction.Save,
			"Cancel", ResponseType.Cancel,
			"Open", ResponseType.Accept );

		FileFilter filter = new FileFilter ();
		filter.AddPattern ("*.csv");
		filter.Name = "*.csv";
		saver.AddFilter (filter);

		if (saver.Run () == (int)ResponseType.Accept) {
			string fileName = saver.Filename;
			string fileExt = fileName.Substring (fileName.Length - 4).ToLower ();
			if (! fileExt.Equals (".csv")) {
				fileName += ".csv";
			}

			StreamWriter outputFile = new StreamWriter (fileName);
			outputFile.Write (data);
			outputFile.Close ();
			Console.Write (data);
		}
		saver.Destroy ();
	}

	protected void OnSelectBeginButtonRelease (object o, ButtonReleaseEventArgs args)
	{
		Console.WriteLine ("OnSelectBeginButtonRelease");
		throw new NotImplementedException ();
	}

	protected void OnSelectBeginButtonPress (object o, ButtonPressEventArgs args)
	{
		Console.WriteLine ("OnSelectBeginButtonPress");
		throw new NotImplementedException ();
	}

	protected void OnEventBoxButtonRelease (object o, ButtonReleaseEventArgs args)
	{
		throw new NotImplementedException ();
	}

}
