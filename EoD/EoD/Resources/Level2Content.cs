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

		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();
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

		//Console.WriteLine("here 3");
	}

	protected void Level2Check1Toggled (){
	}

	protected void Level2Check2Toggled (){
	}

}

