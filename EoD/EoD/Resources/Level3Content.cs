
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;
using System.Reflection;

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
		M2MainTextView1.Buffer.Text = "";

		MainVboxSubContainerM3.Visible = true;
		M3H1MainLabelHeader1.Text = "Breif overview of testing:";
		M3MainEntryField1.Visible = false;
		MainHboxSubContainerM3H1Sub1.Hide();
		M3MainTextView1.Visible = true;
		M3MainTextView1.Sensitive = true;

		MainButtonControls2.Visible = true;
		label8.Text = "Page 3";
	
	}

	public void CheckSpelling(){
		Word.Application app = new Word.Application();
	
		int errors = 0;

		if (M2MainTextView1.Buffer.Text == ""){
			Console.WriteLine("no content");
		}
		else
		{
			app.Visible = false;

			// Setting these variables is comparable to passing null to the function.
			// This is necessary because the C# null cannot be passed by reference.
			object template = Missing.Value;
			object newTemplate = Missing.Value;
			object documentType = Missing.Value;
			object visible = true;

			Word._Document doc1 = app.Documents.Add(template, newTemplate, documentType, visible);
			doc1.Words.First.InsertBefore(M1MainTextView1.Buffer.Text);
			Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
			errors = spellErrorsColl.Count;

			object optional = Missing.Value;

			doc1.CheckSpelling(
				optional, optional, optional, optional, optional, optional,
				optional, optional, optional, optional, optional, optional);

			//ExtraLabel.Visible = true;

			label8.Visible = true;
			label8.Text = errors + " errors corrected ";
			object first = 0;
			object last = doc1.Characters.Count - 1;
			M1MainTextView1.Buffer.Text = doc1.Range(first, last).Text;
			//textBox1.Text = doc1.Range(ref first, ref last).Text;
		}
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
		//ReportSectionFour();
	}

	protected void Level3Check1Toggled (){
	}

	protected void Level3Check2Toggled (){
	}

}

