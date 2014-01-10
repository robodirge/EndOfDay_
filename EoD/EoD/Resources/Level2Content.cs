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
		M2H1MainLabelHeader1.Text = "Date:";
		M2MainEntryField1.Text = DateTime.Now.ToString("dd/MM/yyyy");
	}

	public void Level2Toggled6 (){
	}

	protected void Level2Toggled8 (){
	}

	protected void Level2Toggled10 (){
	}

	protected void Level2ButtonControls1Clicked (){
	}

	protected void Level2Check1Toggled (){
	}

	protected void Level2Check2Toggled (){
	}

}

