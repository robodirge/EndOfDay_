using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public string clientNameString;
	public string projectNameString;
	public string urlUsedString;
	public string buildVersionString;
	public string[] primListArray;
	public string[] top5ListArray;

	public int addCounter;

	public int programControl;

	//<param> Application start </param>
	public MainWindow () : base (Gtk.WindowType.Toplevel){}

	public void main(){
		ReportSectionOne();
	}

	//<param> Application closes </param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnM5H2MainCheck2Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Check2Toggled();
			break;
		case 2:
			Console.WriteLine("asd");
			break;
		default:
			break;
		}
	}//

	protected void OnM5H2MainCheck1Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Check1Toggled();
			break;
		case 2:
			Console.WriteLine("asd");
			break;
		default:
			break;
		}
	}//

	protected void OnMainButtonControls1Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1ButtonControls1Clicked();
			break;
		case 2:
			Level2Button();
			//Console.WriteLine("asd");
			break;
		case 3:
			Level3Button();
			break;
		case 4:
			//level4Button
			break;
		default:
			break;
		}
	}

	protected void OnButton1Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			PrimAdd();
			break;
		case 2:
			Console.WriteLine("asd");
			break;
		default:
			break;
		}
	}

	protected void OnRadiobutton10Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Toggled10();
			break;
		case 2:
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnRadiobutton8Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Toggled8();
			break;
		case 2:
			Console.WriteLine("asd");
			break;
		default:
			break;
		}
	}

	protected void OnRadiobutton6Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Toggled6();
			break;
		case 2:
			Console.WriteLine("asd");
			break;
		default:
			break;
		}
	}

	//ATM Blank   
	protected void OnRadiobutton4Toggled (object sender, EventArgs e){
	}

	protected void OnRadiobutton2Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			break;
		case 3:
			Level3Check2Toggled();
			break;
		default:
			break;
		}
	}

	//ATM Blank
	protected void OnMainButtonControls2Clicked(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnM3H2MainCheck1Toggled(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			Level2Check1Toggled();
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnM3H2MainCheck2Toggled(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			Level2Check2Toggled();
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnM3H2MainCheck3Toggled(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			Level2Check3Toggled();
			break;
		case 3:
			break;
		default:
			break;
		}
	}
}



