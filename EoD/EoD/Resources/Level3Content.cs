
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
		MainLabelTitle.Text = "Issue Summary";

		GtkScrolledWindow.Visible = true;
		GtkScrolledWindow.SetPolicy(PolicyType.Never,PolicyType.Never);

		//MainVboxSubContainerM1.Hide();
		M1H1MainLabelHeader1.Text = "Issues that have blocked testing?";
		MainHboxSubContainerM1H1Sub1.Visible = true;
		radiobutton3.Active = true;
		radiobutton2.Label = "Yes";
		radiobutton3.Label = "No";

		M1MainEntryField1.Visible = false;

		hbox8.Visible = true;
		M1MainTextView1.Visible = true;
		M1MainTextView1.Sensitive = false;

		MainHboxSubContainerM1H2.Visible = false;

		label8.Visible = true;
		label8.Text = "Issues blocking testing:";

		MainVboxSubContainerM2.Hide();
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();

		MainVboxSubContainerM5.Show();
		M5H1MainLabelHeader1.Text = "Top 5 issues of concern:";
		
		vbox1.Visible = true;
		MainHboxSubContainerM5H1Sub1.Visible = false;

		M5MainEntryField1.Sensitive = true;
		M5MainEntryField2.Sensitive = true;
		M5MainEntryField3.Sensitive = true;
		M5MainEntryField4.Sensitive = true;
		M5MainEntryField5.Sensitive = true;

		M5MainEntryField1.Visible = true;
		M5MainEntryField2.Visible = true;
		M5MainEntryField3.Visible = true;
		M5MainEntryField4.Visible = true;
		M5MainEntryField5.Visible = true;

		hbox1.Visible = true;
		hbox2.Visible = true;
		hbox3.Visible = true;
		hbox4.Visible = true;
		hbox5.Visible = true;
		hbox6.Visible = false;
		hbox7.Visible = false;

		label1.Visible = true;
		label2.Visible = true;
		label3.Visible = true;
		label4.Visible = true;
		label5.Visible = true;

		label1.Text = "1:";
		label2.Text = "2:";
		label3.Text = "3:";
		label4.Text = "4:";
		label5.Text = "5:";

		M5MainEntryField1.Text = "";
		M5MainEntryField2.Text = "";
		M5MainEntryField3.Text = "";
		M5MainEntryField4.Text = "";
		M5MainEntryField5.Text = "";

		M5MainEntryField6.Visible = false;
		M5MainEntryField7.Visible = false;
		button1.Visible = false;
		button2.Visible = false;
		button3.Visible = false;
		button4.Visible = false;
		button5.Visible = false;
		button6.Visible = false;

		MainHboxSubContainerM5H2.Visible = false;
	
	}

	#region spellcheck
	/*
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

			Console.WriteLine(M2MainTextView1.Buffer.Text);

			doc1.Words.First.InsertBefore(M2MainTextView1.Buffer.Text);

			doc1.Content.LanguageID = WdLanguageID.wdEnglishUK;

			Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
			errors = spellErrorsColl.Count;

			Console.WriteLine(errors);

			object optional = Missing.Value;

			//	if(errors > 0 ){
			//	for(int x = 1; x <= spellErrorsColl.Count; x++){
			//		Console.WriteLine(spellErrorsColl[x].Text);
			//	}
			//}

			Word.SpellingSuggestions correctionSpelling;

			//correctionSpelling = app.GetSpellingSuggestions(spellErrorsColl[1].Text);

			if(errors > 0){
				for(int p = 1; p <= spellErrorsColl.Count; p++){

					correctionSpelling = app.GetSpellingSuggestions(spellErrorsColl[p].Text);

					for(int x = 1; x <= correctionSpelling.Count; x++){
						Console.WriteLine(correctionSpelling[x].Name);
					} 
				}
			}
			//doc1.CheckSpelling(
			//	optional, optional, optional, optional, optional, optional,
			//	optional, optional, optional, optional, optional, optional);

			label8.Text = errors + " errors corrected ";
			object first = 0;
			object last = doc1.Characters.Count - 1;
			M2MainTextView1.Buffer.Text = doc1.Range(first, last).Text;
			//textBox1.Text = doc1.Range(ref first, ref last).Text;
		}
		app.Quit();

	}
	*/
	#endregion

	public void Level3Toggled6 (){
	}

	protected void Level3Toggled8 (){
	}

	protected void Level3Toggled10 (){
	}

	protected void Level3ButtonControls1Clicked (){
	}

	protected void Level3Button (){
		bool bNextSection1 = true;

		if(radiobutton2.Active){
			if(M1MainTextView1.Buffer.Text == ""){
				MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Missing issue numbers!"));
				PF.Title= "Please provide issue numbers.";
				ResponseType response = (ResponseType) PF.Run();
				if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
					PF.Destroy();
					bNextSection1 = false;
				}
			}
		}

		top5ListArray = new string[5];

		bool bAllBlank = false;

		for(int x = 1; x < 6; x++){
			switch(x){
			case 1:
				if(M5MainEntryField1.Text == ""){
					top5ListArray[0] = "N/A"; 
					bAllBlank = true;
				}
				else{
					top5ListArray[0] = M5MainEntryField1.Text;
					bAllBlank = false;
				}
				break;
			case 2:
				if(M5MainEntryField2.Text == ""){
					top5ListArray[1] = "N/A"; 

					bAllBlank = true;
				}
				else{
					top5ListArray[1] = M5MainEntryField2.Text;
					bAllBlank = false;
				}
				break;
			case 3:
				if(M5MainEntryField3.Text == ""){
					top5ListArray[2] = "N/A";
					bAllBlank = true;
				} 
				else{
					top5ListArray[2] = M5MainEntryField3.Text;
					bAllBlank = false;
				}
				break;
			case 4:
				if(M5MainEntryField4.Text == ""){
					top5ListArray[3] = "N/A"; 
					bAllBlank = true;
				}
				else{
					top5ListArray[3] = M5MainEntryField4.Text;
					bAllBlank = false;
				}
				break;
			case 5:
				if(M5MainEntryField5.Text == ""){
					top5ListArray[4] = "N/A"; 
					bAllBlank = true;
				}
				else{
					top5ListArray[4] = M5MainEntryField5.Text;
					bAllBlank = false;
				}
				break;
			default:
				break;
			}

		}

		//rearrange
		int p;
		if(!bAllBlank){
			for(int x = 0; x < 5; x++){
				if(top5ListArray[x] == "N/A"){
					p = x + 1;
					for(; p < 5; p++){

						if(top5ListArray[p] != "N/A"){
							top5ListArray[x] = top5ListArray[p];
							top5ListArray[p] = "N/A";
							break;
						}
					}
				}
				Console.WriteLine(top5ListArray[x]);
			}

			M5MainEntryField1.Text = top5ListArray[0];
			M5MainEntryField2.Text = top5ListArray[1];
			M5MainEntryField3.Text = top5ListArray[2];
			M5MainEntryField4.Text = top5ListArray[3];
			M5MainEntryField5.Text = top5ListArray[4];

		}
		else{
			//Don't include section in report
			Console.WriteLine("All empty");
		}

		if(bNextSection1){
			programControl = 4;
			ReportSectionFour();
		}
	}

	protected void Level3Check2Toggled (){
		if (radiobutton2.Active) {
			M1MainTextView1.Sensitive = true; 
		}
		else{
			M1MainTextView1.Sensitive = false;
		}
		return;
	}

}

