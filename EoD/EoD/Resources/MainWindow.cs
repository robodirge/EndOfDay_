using System;
using Gtk;

public partial class MainWindow: Gtk.Window{
	//<param> Application start </param>
	public MainWindow () : base (Gtk.WindowType.Toplevel){
		Build ();

		//Run First report section
		ReportSectionOne();
	}

	//<param> Fill in fields for the first section in the report - Project details </param>
	public void ReportSectionOne(){
		// Supply text for title label 
		MainLabelTitle.Text = "Project Details";

		// Supply content for Client fields
		M1H1MainLabelHeader1.Text = "Client:";
		M1MainEntryField1.Text = "";

		// Supply content for Project fields
		M2H1MainLabelHeader1.Text = "Project name:";
		M2MainEntryField1.Text = "";
		
		// Supply content for tested fields
		M3H1MainLabelHeader1.Text = "Was a URL used for testing?";	// "URL(s) tested:";
		MainHboxSubContainerM3H1Sub1.Visible = true;	// Reveal y/n
		M3MainTextView1.Sensitive = false;	// Disable access to edit text
		M3H1Sub1MainRadio2.Active = true;	// Enable 'no'
		M3MainEntryField1.Visible = false;  // Entry Field 
		M3MainTextView1.Visible = true;		// Text field

		// Supply content for version fields
		M4H1MainLabelHeader1.Text = "Is a build / version number avalible?";	// "Build version(s) tested:";
		MainHboxSubContainerM4H1Sub1.Visible = true;
		M4MainTextView1.Sensitive = false;
		M4H1Sub1MainRadio2.Active = true;
		M4MainEntryField1.Visible = false;
		M4MainTextView1.Visible = true;

		// Supply content for Client fields
		M5H1MainLabelHeader1.Text = "Was a primary environment used for testing?";	// "Test environment(s)";
		MainHboxSubContainerM5H1Sub1.Visible = true;
		M5H1Sub1MainRadio2.Active = true;
		M5MainTextView1.Sensitive = false;
		M5MainEntryField1.Visible = false;
		M5MainTextView1.Visible = true;
		MainHboxSubContainerM5H2.Visible = true; // Reveal check boxes

		return;
	}




	//<param> Application closes </param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;

	}
}
