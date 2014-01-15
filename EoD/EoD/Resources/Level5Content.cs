
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionFive(){
		MainLabelTitle.Text = "Report Detail";
		MainVboxSubContainerM1.Show();
		MainVboxSubContainerM2.Show();
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();

		MainHboxSubContainerM1H1Sub1.Visible = false;
		M1MainEntryField1.Visible = false;
		label8.Visible = false;
		MainHboxSubContainerM1H2.Visible = false;

		M1H1MainLabelHeader1.Text = "Test tasks completed:";
		M1MainTextView1.Visible = true;
		M1MainTextView1.Sensitive = true;
		M1MainTextView1.Buffer.Text = "";
		M1MainTextView1.HeightRequest = 200;
		GtkScrolledWindow.Visible = true;
		GtkScrolledWindow.SetPolicy(PolicyType.Never,PolicyType.Always);

		MainHboxSubContainerM2H1Sub1.Hide();
		M2MainEntryField1.Hide();
		MainHboxSubContainerM2H2.Hide();

		M2H1MainLabelHeader1.Text = "Brief overview of testing:";
		M2MainTextView1.Visible = true;
		M2MainTextView1.Sensitive = true;
		M2MainTextView1.Buffer.Text = "";
		
		MainButtonControls2.Label = "Spell Check";
		MainButtonControls2.Visible = true;
		MainButtonControls2.Sensitive = true;
	}

	public void level5Toggled6 (){
	}

	protected void level5Toggled8 (){
	}

	protected void level5Toggled10 (){
	}

	protected void level5ButtonControls2Clicked (){
		string sRef = M1MainTextView1.Buffer.Text;
		EoD.Level5Dialog Nw = new EoD.Level5Dialog(ref sRef);

		//EoD.Level5Dialog Nw = new EoD.Level5Dialog(M2MainTextView1.Buffer.Text);
		ResponseType response = (ResponseType) Nw.Run();
		if (response == ResponseType.DeleteEvent){
			Nw.AppQuit();
			M1MainTextView1.Buffer.Text = Nw.getText();
			Nw.Destroy();
		}



	}

	protected void level5Button (){

	}

	protected void level5Check1Toggled (){

	}

	protected void level5Check2Toggled (){

	}

	protected void level5Check3Toggled (){

	}

}

