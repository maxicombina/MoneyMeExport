
// This file has been generated by the GUI designer. Do not modify.
public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action FileAction;
	private global::Gtk.Action OpenAction;
	private global::Gtk.Action ExitAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar1;
	private global::Gtk.Table table1;
	private global::Gtk.Button button2;
	private global::Gtk.Entry entryBegin;
	private global::Gtk.Entry entryEnd;
	private global::Gtk.Label lblBegin;
	private global::Gtk.Label lblEnd;
	private global::Gtk.Statusbar statusbar;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.OpenAction = new global::Gtk.Action ("OpenAction", global::Mono.Unix.Catalog.GetString ("Open"), null, null);
		this.OpenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Open");
		w1.Add (this.OpenAction, "<Primary>o");
		this.ExitAction = new global::Gtk.Action ("ExitAction", global::Mono.Unix.Catalog.GetString ("Exit"), null, null);
		this.ExitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Exit");
		w1.Add (this.ExitAction, "<Primary>q");
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MoneyMe Export");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.AllowGrow = false;
		this.AllowShrink = true;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 10;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='OpenAction' action='OpenAction'/><separator/><menuitem name='ExitAction' action='ExitAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.table1 = new global::Gtk.Table (((uint)(2)), ((uint)(3)), false);
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		// Container child table1.Gtk.Table+TableChild
		this.button2 = new global::Gtk.Button ();
		this.button2.CanFocus = true;
		this.button2.Name = "button2";
		this.button2.UseUnderline = true;
		this.button2.Relief = ((global::Gtk.ReliefStyle)(2));
		this.button2.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.table1.Add (this.button2);
		global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.button2]));
		w3.TopAttach = ((uint)(1));
		w3.BottomAttach = ((uint)(2));
		w3.LeftAttach = ((uint)(2));
		w3.RightAttach = ((uint)(3));
		w3.XOptions = ((global::Gtk.AttachOptions)(4));
		w3.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.entryBegin = new global::Gtk.Entry ();
		this.entryBegin.CanFocus = true;
		this.entryBegin.Name = "entryBegin";
		this.entryBegin.IsEditable = true;
		this.entryBegin.InvisibleChar = '•';
		this.table1.Add (this.entryBegin);
		global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.entryBegin]));
		w4.LeftAttach = ((uint)(1));
		w4.RightAttach = ((uint)(2));
		w4.XOptions = ((global::Gtk.AttachOptions)(4));
		w4.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.entryEnd = new global::Gtk.Entry ();
		this.entryEnd.CanFocus = true;
		this.entryEnd.Name = "entryEnd";
		this.entryEnd.IsEditable = true;
		this.entryEnd.InvisibleChar = '•';
		this.table1.Add (this.entryEnd);
		global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.entryEnd]));
		w5.TopAttach = ((uint)(1));
		w5.BottomAttach = ((uint)(2));
		w5.LeftAttach = ((uint)(1));
		w5.RightAttach = ((uint)(2));
		w5.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.lblBegin = new global::Gtk.Label ();
		this.lblBegin.Name = "lblBegin";
		this.lblBegin.LabelProp = global::Mono.Unix.Catalog.GetString ("Begin");
		this.table1.Add (this.lblBegin);
		global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblBegin]));
		w6.XOptions = ((global::Gtk.AttachOptions)(1));
		w6.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.lblEnd = new global::Gtk.Label ();
		this.lblEnd.Name = "lblEnd";
		this.lblEnd.LabelProp = global::Mono.Unix.Catalog.GetString ("End");
		this.table1.Add (this.lblEnd);
		global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblEnd]));
		w7.TopAttach = ((uint)(1));
		w7.BottomAttach = ((uint)(2));
		w7.XOptions = ((global::Gtk.AttachOptions)(4));
		w7.YOptions = ((global::Gtk.AttachOptions)(4));
		this.vbox1.Add (this.table1);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.table1]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar = new global::Gtk.Statusbar ();
		this.statusbar.Name = "statusbar";
		this.statusbar.Spacing = 6;
		this.vbox1.Add (this.statusbar);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar]));
		w9.Position = 2;
		w9.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 289;
		this.DefaultHeight = 126;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.OpenAction.Activated += new global::System.EventHandler (this.OnMenuFileOpen);
		this.ExitAction.Activated += new global::System.EventHandler (this.OnMenuExit);
	}
}
