using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionTwo(){
		// Supply text for title label 
		MainLabelTitle.Text = "Report Details";
		label10.Visible = true;
		// Supply content for Client fields
		M1H1MainLabelHeader1.Text = "Testers initials:";
		M1MainEntryField1.Text = "";
		M1MainEntryField1.Sensitive = false;

		// Supply content for Project fields
		M2H1MainLabelHeader1.Text = "Date tested:";
		M2MainEntryField1.Text = DateTime.Now.ToString("dd/MM/yyyy"); /// Could make a calender

		//MainVboxSubContainerM3.Hide();
		M3H1MainLabelHeader1.Text = "Test activities:";
		MainHboxSubContainerM3H1Sub1.Visible = false;
		M3MainEntryField1.Visible = false;
		M3MainTextView1.Visible = false;
		GtkScrolledWindow2.Visible = false;
		MainHboxSubContainerM3H2.Visible = true;

		M3H2MainCheck1.Label = "Scripting & Planning";
		M3H2MainCheck2.Label = "Test Execution";
		M3H2MainCheck3.Label = "Issue Verification & Retest";

		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();

		MainButtonControls1.Sensitive = true;
		//MainButtonControls3.Sensitive = true; // Enable Back' But
		InitialsSetup();
	}

	public void Level2Toggled6 (){
	}

	protected void Level2Toggled8 (){
	}

	protected void Level2Toggled10 (){
	}

	protected void Level2ButtonControls1Clicked (){
	}

	public void InitialsSetup(){
		vbox2.Visible = true;
		Initradiobutton2.Active = true;
		//initArray = new string[12];

		for(int x = 0; x < initArray.Length; x++){
			switch(x){
			case 0:
				initArray[x] = "BV";
				InCheck1.Label = initArray[x];
				break;
			case 1:
				initArray[x] = "ELR";
				InCheck2.Label = initArray[x];
				break;
			case 2:
				initArray[x] = "SA";
				InCheck3.Label = initArray[x];
				break;
			case 3:
				initArray[x] = "AF";
				InCheck4.Label = initArray[x];
				break;
			case 4:
				initArray[x] = "TY";
				InCheck5.Label = initArray[x];
				break;
			case 5:
				initArray[x] = "TG";
				InCheck6.Label = initArray[x];
				break;
			case 6:
				initArray[x] = "GH";
				InCheck7.Label = initArray[x];
				break;
			case 7:
				initArray[x] = "LW";
				InCheck8.Label = initArray[x];
				break;
			case 8: 
				initArray[x] = "JG";
				InCheck9.Label = initArray[x];
				break;
			case 9: 
				initArray[x] = "KH";
				InCheck10.Label = initArray[x];
				break;
			case 10: 
				initArray[x] = "MG";
				InCheck11.Label = initArray[x];
				break;
			case 11: 
				initArray[x] = "SS";
				InCheck12.Label = initArray[x];
				break;
			default:
				break;
			}
		}

		
		/*
		InCheck13.Label = "BV";
		InCheck14.Label = "BV";


		InCheck15.Label = "Other";
		*/
		InCheck13.Sensitive = false;
		InCheck14.Sensitive = false;
		InCheck15.Sensitive = false;
	}

	protected void Level2Button (){
		bool hasEnabled = false;
		sAllinitials = "";
		for(int p = 0; p < initEnabledArray.Length; p++){
			if(initEnabledArray[p]){
				hasEnabled = true;
				sAllinitials += (initArray[p] + "/");
			}
		}


		if((M1MainEntryField1.Text == "")&&(Initradiobutton1.Active == true)){
			MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Please provide 'Other' initials."));
			PF.WidthRequest = 600; 
			PF.Title= "Missing initials!Please provide 'Other' initials.";
			ResponseType response = (ResponseType) PF.Run();
			if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
				PF.Destroy();
			}
		}else if(!hasEnabled){
			MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Please check initials boxes or use 'Other' text field."));
			PF.WidthRequest = 600; 
			PF.Title= "Missing initials!";
			ResponseType response = (ResponseType) PF.Run();
			if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
				PF.Destroy();
			}
		}
		else{
			programControl = 3;
			vbox2.Visible = false;
			label10.Visible = false;

			//sAllinitials
			if(M1MainEntryField1.Text != ""){
				sAllinitials += M1MainEntryField1.Text;
			}

			Console.WriteLine(sAllinitials);

			ReportSectionThree();
		}
	}

	protected void Level2Check1Toggled (){
		if(M3H2MainCheck1.Active)
			MainButtonControls1.Sensitive = true;
		else{
			if((M3H2MainCheck2.Active)||(M3H2MainCheck3.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void Level2Check2Toggled (){
		if(M3H2MainCheck2.Active)
			MainButtonControls1.Sensitive = true;
		else{
			if((M3H2MainCheck1.Active)||(M3H2MainCheck3.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void Level2Check3Toggled (){
		if(M3H2MainCheck3.Active)
			MainButtonControls1.Sensitive = true;
		else{
			if((M3H2MainCheck1.Active)||(M3H2MainCheck2.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	public void InCheck15Toggled(){
		if (Initradiobutton1.Active)
			M1MainEntryField1.Sensitive = true; 
		else{
			M1MainEntryField1.Sensitive = false;
		}
		return;
	}
}

