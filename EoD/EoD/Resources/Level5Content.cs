
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
		M2MainTextView1.HeightRequest = 200;

		//MainButtonControls2.Label = "Spell Check";
		//MainButtonControls2.Visible = true;
		//MainButtonControls2.Sensitive = true;

		GtkScrolledWindow1.Visible = true;
		GtkScrolledWindow1.SetPolicy(PolicyType.Never,PolicyType.Always);

		MainHboxSubContainerM1H2.Visible = true;
		M1H2MainCheck1.Visible = false;
		M1H2MainCheck2.Visible = false;
		M1H2MainCheck3.Visible = false;

		MainHboxSubContainerM2H2.Visible = true;
		M2H2MainCheck1.Visible = false;
		M2H2MainCheck2.Visible = false;
		M2H2MainCheck3.Visible = false;

		hbox9.Visible = true;
		button8.WidthRequest = 100;
		button8.Sensitive = false;
		button9.WidthRequest = 100;
		button8.Label = "Info";
		button9.Label = "Spell Check";

		hbox10.Visible = true;
		button10.WidthRequest = 100;
		button10.Sensitive = false;
		button11.WidthRequest = 100;
		button10.Label = "Info";
		button11.Label = "Spell Check";

	}

	public void level5Toggled6 (){
	}

	protected void level5Toggled8 (){
	}

	protected void level5Toggled10 (){
	}

	protected void level5ButtonControls2Clicked (int iRef){
		string sRef;
		EoD.Level5Dialog Nw = null;
		if(iRef == 1){
			sRef = M1MainTextView1.Buffer.Text;
			Nw = new EoD.Level5Dialog(ref sRef);
		}
		else if(iRef == 2){
			sRef = M2MainTextView1.Buffer.Text;
			Nw = new EoD.Level5Dialog(ref sRef);
		}
		else{
			Console.WriteLine("Error missing content -- level5ButtonControls2Clicked");
		}

		//EoD.Level5Dialog Nw = new EoD.Level5Dialog(M2MainTextView1.Buffer.Text);
		ResponseType response = (ResponseType) Nw.Run();
		if (response == ResponseType.DeleteEvent){
			Nw.AppQuit();
			if(iRef == 1){
				M1MainTextView1.Buffer.Text = Nw.getText();
			}
			else if(iRef == 2){
				M2MainTextView1.Buffer.Text = Nw.getText();
			}
			Nw.Destroy();
		}
	}

	protected void level5Button (){
		if(bSmokes){
			ReportSectionSix();
		}
		else{
			//Create Document
		}
	}

	protected void level5Check1Toggled (){

	}

	protected void level5Check2Toggled (){

	}

	protected void level5Check3Toggled (){

	}

	protected void OnButton10Clicked (object sender, EventArgs e){

	}

	protected void OnButton11Clicked (object sender, EventArgs e){
		level5ButtonControls2Clicked (2);
	}

	protected void OnButton8Clicked (object sender, EventArgs e){
	}

	protected void OnButton9Clicked (object sender, EventArgs e){
		level5ButtonControls2Clicked (1);
	}
}

