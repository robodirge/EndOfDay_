
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionThree(){
		// Supply text for title label 
		MainLabelTitle.Text = "Report Detail";

		// Supply content for Client fields
		M1H1MainLabelHeader1.Text = "Test activities:";
		//MainHboxSubContainerM
		MainHboxSubContainerM1H2.Visible = true;
		M1MainEntryField1.Visible = false;

		// Supply content for Project fields
		M2H1MainLabelHeader1.Text = "Test tasks completed:";
		M2MainEntryField1.Visible = false;
		M2MainTextView1.Visible = true;

		MainVboxSubContainerM3.Visible = true;
		M3H1MainLabelHeader1.Text = "Breif overview of testing:";
		M3MainEntryField1.Visible = false;
		MainHboxSubContainerM3H1Sub1.Hide();
		M3MainTextView1.Visible = true;
		M3MainTextView1.Sensitive = true;
	}

	public void Level3Toggled6 (){
	}

	protected void Level3Toggled8 (){
	}

	protected void Level3Toggled10 (){
	}

	protected void Level3ButtonControls1Clicked (){
	}

	protected void Level3Button (){

		programControl = 4;
		ReportSectionFour();
		//Console.WriteLine("here 3");
	}

	protected void Level3Check1Toggled (){
	}

	protected void Level3Check2Toggled (){
	}

}

