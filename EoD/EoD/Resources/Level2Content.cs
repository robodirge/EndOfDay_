using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionTwo(){
		// Supply text for title label 
		MainLabelTitle.Text = "Report Details";

		// Supply content for Client fields
		M1H1MainLabelHeader1.Text = "Testers initials:";
		M1MainEntryField1.Text = "";

		// Supply content for Project fields
		M2H1MainLabelHeader1.Text = "Date tested:";
		M2MainEntryField1.Text = DateTime.Now.ToString("dd/MM/yyyy"); /// Could make a calender

		//MainVboxSubContainerM3.Hide();
		M3H1MainLabelHeader1.Text = "Test activities:";
		MainHboxSubContainerM3H1Sub1.Visible = false;
		M3MainEntryField1.Visible = false;
		M3MainTextView1.Visible = false;
		MainHboxSubContainerM3H2.Visible = true;

		M3H2MainCheck1.Label = "Scripting & Planning";
		M3H2MainCheck2.Label = "Test Execution";
		M3H2MainCheck3.Label = "Issue Verification & Retest";

		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();

		MainButtonControls1.Sensitive = false;
	}

	public void Level2Toggled6 (){
	}

	protected void Level2Toggled8 (){
	}

	protected void Level2Toggled10 (){
	}

	protected void Level2ButtonControls1Clicked (){
	}

	protected void Level2Button (){
		if(M1MainEntryField1.Text == ""){
			MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Missing initials!"));
			PF.Title= "Please provide initials.";
			ResponseType response = (ResponseType) PF.Run();
			if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
				PF.Destroy();
			}
		}else{
			programControl = 3;
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

}

