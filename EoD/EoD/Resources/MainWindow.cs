using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public string clientNameString;
	public string projectNameString;

	public int addCounter;

	public int programControl;

	//<param> Application start </param>
	public MainWindow () : base (Gtk.WindowType.Toplevel){}

	public void main(){
		MainContent myClass1 = new MainContent();		
		myClass1.ReportSectionOne();
	}

	//<param> Application closes </param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}


	protected void OnM5H2MainCheck2Toggled (object sender, EventArgs e){
	}

	protected void OnM5H2MainCheck1Toggled (object sender, EventArgs e){
	}

	protected void OnMainButtonControls1Clicked (object sender, EventArgs e){
	}

	protected void OnButton1Clicked (object sender, EventArgs e){
	}

	protected void OnRadiobutton10Toggled (object sender, EventArgs e){
	}

	protected void OnRadiobutton8Toggled (object sender, EventArgs e){
	}

	protected void OnRadiobutton6Toggled (object sender, EventArgs e){

		Console.WriteLine(programControl);

		switch (programControl){
		case 1:
			MainContent myClass1 = new MainContent();	
			//myClass1.Level1Toggled();
			myClass1.tempFunc();
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

	//ATM Blank
	protected void OnRadiobutton2Toggled (object sender, EventArgs e){
	}
}



