using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	static string clientNameString;
	static string projectNameString;

	static int addCounter;

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
		radiobutton7.Active = true;
		M3MainEntryField1.Visible = false;  // Entry Field 
		M3MainTextView1.Visible = true;		// Text field

		// Supply content for version fields
		M4H1MainLabelHeader1.Text = "Is a build / version number avalible?";	// "Build version(s) tested:";
		MainHboxSubContainerM4H1Sub1.Visible = true;
		M4MainTextView1.Sensitive = false;
		radiobutton9.Active = true;
		M4MainEntryField1.Visible = false;
		M4MainTextView1.Visible = true;

		// Supply content for Client fields
		M5H1MainLabelHeader1.Text = "Was a primary environment used for testing?";	// "Test environment(s)";
		MainHboxSubContainerM5H1Sub1.Visible = true;
		radiobutton11.Active = true;
		//M5MainTextView1.Sensitive = false;
		//M5MainEntryField1.Visible = false;
		//M5MainTextView1.Visible = true;
		vbox1.Visible = true;
		hbox1.Visible = true;
		M5MainEntryField1.Sensitive = false;
		button1.Sensitive = false;
		hbox2.Visible = false;
		hbox3.Visible = false;
		hbox4.Visible = false;
		hbox5.Visible = false;
		hbox6.Visible = false;
		hbox7.Visible = false;
		
		MainHboxSubContainerM5H2.Visible = true; // Reveal check boxes
		M5H2MainCheck3.Visible = false;
		M5H2MainCheck1.Label = "Cross environment checks/smoke tests";
		M5H2MainCheck2.Label = "Issue Verification & Retest";

		radiobutton6.Label = "Yes";
		radiobutton8.Label = "Yes";
		radiobutton10.Label = "Yes";

		radiobutton7.Label = "No";
		radiobutton9.Label = "No";
		radiobutton11.Label = "No";
	
		MainButtonControls1.Sensitive = false;
		addCounter = 2;
		return;
	}

	//<param> Application closes </param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnRadiobutton6Toggled (object sender, EventArgs e)
	{
		if (radiobutton6.Active)
			M3MainTextView1.Sensitive = true; 
		else{
			M3MainTextView1.Sensitive = false;
		}
		return;
	}

	protected void OnRadiobutton8Toggled (object sender, EventArgs e)
	{
		if (radiobutton8.Active) {
			M4MainTextView1.Sensitive = true; 
		}
		else{
			M4MainTextView1.Sensitive = false;
		}
		return;
	}

	protected void OnRadiobutton10Toggled (object sender, EventArgs e)
	{
		if (radiobutton10.Active){
			//M5MainTextView1.Sensitive = true; 
			MainButtonControls1.Sensitive = true;

			M5MainEntryField1.Sensitive = true;
			M5MainEntryField2.Sensitive = true;
			M5MainEntryField3.Sensitive = true;
			M5MainEntryField4.Sensitive = true;
			M5MainEntryField5.Sensitive = true;
			M5MainEntryField6.Sensitive = true;
			M5MainEntryField7.Sensitive = true;
			button1.Sensitive = true;
			button2.Sensitive = true;
			button3.Sensitive = true;
			button4.Sensitive = true;
			button5.Sensitive = true;
			button6.Sensitive = true;
		}
		else{
			//M5MainTextView1.Sensitive = false;

			M5MainEntryField1.Sensitive = false;
			M5MainEntryField2.Sensitive = false;
			M5MainEntryField3.Sensitive = false;
			M5MainEntryField4.Sensitive = false;
			M5MainEntryField5.Sensitive = false;
			M5MainEntryField6.Sensitive = false;
			M5MainEntryField7.Sensitive = false;
			button1.Sensitive = false;
			button2.Sensitive = false;
			button3.Sensitive = false;
			button4.Sensitive = false;
			button5.Sensitive = false;
			button6.Sensitive = false;

			if((M5H2MainCheck1.Active)||(M5H2MainCheck2.Active)){
			}else{
				MainButtonControls1.Sensitive = false;
			}
		}
		return;
	}

	//protected void 

	protected void OnMainButtonControls1Clicked (object sender, EventArgs e)
	{
		Console.WriteLine("Next level");

		bool clientNameBool = false;
		clientNameString = IsInvalid(M1MainEntryField1.Text, ref clientNameBool);
		bool projectNameBool = false;
		projectNameString = IsInvalid(M2MainEntryField1.Text, ref projectNameBool);
		
		if(clientNameBool){
			Console.WriteLine(clientNameString);
		}
		else{
			EoD.MissingInfoDialog MIC = new EoD.MissingInfoDialog();
			MIC.SetLabelText("Client name is invalid");
			MIC.Run();
			MIC.Destroy();
		}
	
		if(projectNameBool)
			Console.WriteLine(projectNameString);
		else{
			EoD.MissingInfoDialog MIP = new EoD.MissingInfoDialog();
			MIP.SetLabelText("Project name is invalid");
			MIP.Run();
			MIP.Destroy();
		}
		
		return;
	}

	public string IsInvalid(string illegaltemp, ref bool bvalue){
		string oldstring = illegaltemp;
		string invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());
		foreach (char c in invalid){
			illegaltemp = illegaltemp.Replace(c.ToString(), ""); 
		}

		if(illegaltemp == ""){
			illegaltemp = oldstring;
			bvalue = false;
		}
		else if(oldstring != illegaltemp){
			string errortemp = @"Are you happy for this string to be used:  " + oldstring;

			MessageDialog SN = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.YesNo, errortemp);

			SN.Title="Invalid string entered";
			ResponseType response = (ResponseType) SN.Run();
			if (response == ResponseType.Yes || response == ResponseType.DeleteEvent){
				bvalue = true;
			}
			else if (response == ResponseType.No){
				bvalue = false;
				illegaltemp = oldstring;
			}
		}
		else
			bvalue = true;

		return illegaltemp;
	}

	protected void OnM5H2MainCheck1Toggled (object sender, EventArgs e)
	{
		if(M5H2MainCheck1.Active)
			MainButtonControls1.Sensitive = true;
		else{
			if((radiobutton10.Active)||(M5H2MainCheck2.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void OnM5H2MainCheck2Toggled (object sender, EventArgs e)
	{
		if(M5H2MainCheck2.Active)
			MainButtonControls1.Sensitive = true;
		else{
			if((radiobutton10.Active)||(M5H2MainCheck1.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void PrimAdd (object sender, EventArgs e)
	{
		switch (addCounter){
		case 2:
			hbox2.Visible = true;
			button1.Hide();
			addCounter++;
			break;
		case 3:
			hbox3.Visible = true;
			button2.Hide();
			addCounter++;
			break;
		case 4:
			hbox4.Visible = true;
			button3.Hide();
			addCounter++;
			break;
		case 5:
			hbox5.Visible = true;
			button4.Hide();
			addCounter++;
			break;
		case 6:
			hbox6.Visible = true;
			button5.Hide();
			addCounter++;
			break;
		case 7:
			hbox7.Visible = true;
			button6.Hide();
			addCounter++;
			break;
		default:

			break;
		}
	}

}



