
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionSix(){
		MainLabelTitle.Text = "Environments";
		MainVboxSubContainerM1.Show();
		MainVboxSubContainerM2.Hide();
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();

		M1MainTextView1.Visible = false;
		GtkScrolledWindow.Visible = false;
		GtkScrolledWindow.SetPolicy(PolicyType.Never,PolicyType.Never);
		button9.Visible = false;
		M1H1MainLabelHeader1.Text = "Select your enviroments";
		button8.Label = "Select enviros";
		button8.Sensitive = false;
	}

	public void Level6Toggled6 (){
	}

	protected void Level6Toggled8 (){
	}

	protected void Level6Toggled10 (){
	}

	protected void Level6ButtonControls2Clicked (int iRef){

	}

	protected void Level6Button (){
		//Create word DOC!
	}

	protected void Level6Check1Toggled (){

	}

	protected void Level6Check2Toggled (){

	}

	protected void Level6Check3Toggled (){

	}
}

