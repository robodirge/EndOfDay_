using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	//<param> Fill in fields for the first section in the report - Project details </param>
	public void ReportSectionOne(){
		//myMainClass = new MainWindow(); ///////>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		this.Build();

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

		MainButtonControls2.Hide();
		MainButtonControls3.Hide();

		addCounter = 2;
		programControl = 1;
		return;

	}

	public void Level1Toggled6 (){
		if (radiobutton6.Active)
			M3MainTextView1.Sensitive = true; 
		else{
			M3MainTextView1.Sensitive = false;
		}
		return;
	}

	protected void Level1Toggled8 (){
		//MainWindow myMainClass = new MainWindow();
		if (radiobutton8.Active) {
			M4MainTextView1.Sensitive = true; 
		}
		else{
			M4MainTextView1.Sensitive = false;
		}
		return;
	}

	protected void Level1Toggled10 (){
		//MainWindow myMainClass = new MainWindow();
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

	protected void Level1ButtonControls1Clicked (){
		//MainWindow myMainClass = new MainWindow();
		bool clientNameBool = false;
		clientNameString = IsInvalid(M1MainEntryField1.Text, ref clientNameBool, "Client name");
		bool projectNameBool = false;
		projectNameString = IsInvalid(M2MainEntryField1.Text, ref projectNameBool, "Project name");


		if(clientNameBool)
			M1MainEntryField1.Text = clientNameString;
		if(projectNameBool)
			M2MainEntryField1.Text = projectNameString;

		bool primBool = true;

		//Check all 7 primary fields if text not = to ""  // I could link the '+' to the enviro chooser
		if(radiobutton10.Active){
			if(M5MainEntryField1.Text == ""){
				MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("First primary environment is missing!"));
				PF.Title= "Missing input";
				ResponseType response = (ResponseType) PF.Run();
				if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
					primBool = false;
					PF.Destroy();
				}
			}
		}

		if((clientNameBool) && (projectNameBool) && (primBool)){
			SetLevel1Options();
			programControl = 2; 
			ReportSectionTwo();
		}

		return;
	}

	public string IsInvalid(string illegaltemp, ref bool bvalue, string sTitle){
		//MainWindow myMainClass = new MainWindow();
		string oldstring = illegaltemp;
		string invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());
		foreach (char c in invalid){
			illegaltemp = illegaltemp.Replace(c.ToString(), ""); 
		}

		if(illegaltemp == ""){

			MessageDialog E1 = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, (sTitle + " field is empty"));
			E1.WidthRequest = 600; 
			E1.Title= sTitle + " field is empty";

			ResponseType response = (ResponseType) E1.Run();
			if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
				bvalue = false;
				illegaltemp = oldstring;
				E1.Destroy();
			}
		}
		else if(oldstring != illegaltemp){
			string errortemp = (sTitle + " Is incorrect. Are you happy for this name to be used: ") + illegaltemp;

			MessageDialog SN = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.YesNo, errortemp);
			SN.WidthRequest = 600; 
			SN.Title= sTitle + " is invalid";

			ResponseType response = (ResponseType) SN.Run();
			if (response == ResponseType.Yes){
				bvalue = true;
				SN.Destroy();
			}
			else if (response == ResponseType.No|| response == ResponseType.DeleteEvent){
				bvalue = false;
				illegaltemp = oldstring;
				SN.Destroy();
			}
		}
		else
			bvalue = true;

		return illegaltemp;
	}

	protected void Level1Check1Toggled (){
		//MainWindow myMainClass = new MainWindow();
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

	protected void Level1Check2Toggled (){
		//MainWindow myMainClass = new MainWindow();
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

	protected void PrimAdd (){
		//MainWindow myMainClass = new MainWindow();
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

	protected void SetLevel1Options(){
		//Check all 7 primary fields if text not = to ""  // I could link the '+' to the enviro chooser
		if(radiobutton10.Active){
			int iTempCount = 1; // Has to be 1 as field1 cant be ""
			if((hbox2.Visible) && (M5MainEntryField2.Text != ""))
				iTempCount++;
			if((hbox3.Visible) && (M5MainEntryField3.Text != ""))
				iTempCount++;
			if((hbox4.Visible) && (M5MainEntryField4.Text != ""))
				iTempCount++;
			if((hbox5.Visible) && (M5MainEntryField5.Text != ""))
				iTempCount++;
			if((hbox6.Visible) && (M5MainEntryField6.Text != ""))
				iTempCount++;
			if((hbox7.Visible) && (M5MainEntryField7.Text != ""))
				iTempCount++;

			primListArray = new string[iTempCount];
			//value is - apply to an array which is global!

			for(int x =0; x < primListArray.Length; x++){
				switch(x){
				case 0:
					primListArray[0] = M5MainEntryField1.Text;
					break;
				case 1:
					primListArray[1] = M5MainEntryField2.Text;
					break;
				case 2:
					primListArray[2] = M5MainEntryField3.Text;
					break;
				case 3:
					primListArray[3] = M5MainEntryField4.Text;
					break;
				case 4:
					primListArray[4] = M5MainEntryField5.Text;
					break;
				case 5:
					primListArray[5] = M5MainEntryField6.Text;
					break;
				case 6: 
					primListArray[6] = M5MainEntryField7.Text;
					break;
				}
			}
		}

		if(radiobutton6.Active){
			urlUsedString = M3MainTextView1.Buffer.Text;
		}else{
			urlUsedString = @"N/A";
		}

		if(radiobutton8.Active){
			buildVersionString = M4MainTextView1.Buffer.Text;
		}else{
			buildVersionString = DateTime.Now.ToString("dd/MM/yyyy");
		}

		Console.WriteLine(clientNameString);
		Console.WriteLine(projectNameString);
		Console.WriteLine(urlUsedString);
		Console.WriteLine(buildVersionString);

		return;
	}

}

