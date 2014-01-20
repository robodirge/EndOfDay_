
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionFour(){
		// Supply text for title label 
		MainLabelTitle.Text = "Metrics";

		MainVboxSubContainerM1.Hide();
		MainVboxSubContainerM2.Hide();
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();

		M5H1MainLabelHeader1.Text = "Stats:";
		label1.Text = "New issues raised today:";
		label2.Text = "Issues re-opened today:";
		label3.Text = "Issues closed today:";
		label4.Text = "Total number of issues open against this project:";

		label1.WidthRequest = 300;
		label2.WidthRequest = 300;
		label3.WidthRequest = 300;
		label4.WidthRequest = 300;

		label1.Xalign = 0.0f;
		label2.Xalign = 0.0f;
		label3.Xalign = 0.0f;
		label4.Xalign = 0.0f;

		label1.Justify = Justification.Left;
		label2.Justify = Justification.Left;
		label3.Justify = Justification.Left;
		label4.Justify = Justification.Left;

		label5.Visible = false;
		M5MainEntryField5.Visible = false;

		M5MainEntryField1.Text = "";
		M5MainEntryField2.Text = "";
		M5MainEntryField3.Text = "";
		M5MainEntryField4.Text = "";
	}

	public void level4Toggled6 (){
	}

	protected void level4Toggled8 (){
	}

	protected void level4Toggled10 (){
	}

	protected void level4ButtonControls1Clicked (){
	}

	protected void level4Button (){
		//get&set data vars

		//Create Doc
		/*
		 * USe vars with data stored
		 * 
		 */


		programControl = 5;
		ReportSectionFive();
	}

	protected void level4Check1Toggled (){
	}

	protected void level4Check2Toggled (){
	}

}

