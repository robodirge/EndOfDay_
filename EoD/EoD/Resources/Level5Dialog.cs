using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;
using System.Reflection;

namespace EoD
{
	public partial class Level5Dialog : Gtk.Dialog
	{
		static string sToSpellCheck;

		Gtk.ListStore tsSpellingError;
		Gtk.ListStore tsSpellingCorrection;

		Gtk.TreeViewColumn tvcError;
		Gtk.TreeViewColumn tvcCorrection;
		
		Gtk.CellRendererText crtError;
		Gtk.CellRendererText crtCorrection;

		Word.Application app;
		Word.ProofreadingErrors spellErrorsColl;

		Word._Document doc1;

		public Level5Dialog (ref string sTempText)
		{
			sToSpellCheck = sTempText;

			this.Build();
			textview1.Buffer.Text = sToSpellCheck;

			InitSetUp();
			CheckSpelling();
		}

		public void InitSetUp(){
			tvcError = new Gtk.TreeViewColumn();
			tvcError.Title = "Error";

			tvcCorrection = new Gtk.TreeViewColumn();
			tvcCorrection.Title = "Correction";

			treeViewError1.AppendColumn(tvcError);
			treeViewCorrection1.AppendColumn(tvcCorrection);

			crtError = new Gtk.CellRendererText();
			crtCorrection = new Gtk.CellRendererText();

			tvcError.PackStart(crtError, true);
			tvcCorrection.PackStart(crtCorrection, true);

			tvcError.AddAttribute(crtError, "text", 0);
			tvcCorrection.AddAttribute(crtCorrection, "text", 0);

			tsSpellingError = new Gtk.ListStore(typeof (string), typeof (int), typeof (int), typeof (int));
			tsSpellingCorrection = new Gtk.ListStore(typeof (string));

			treeViewError1.Model = tsSpellingError;
			treeViewCorrection1.Model = tsSpellingCorrection;

			app = new Word.Application();
			app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		}

		public void CheckSpelling(){
			int errors = 0;

			if (sToSpellCheck == ""){
				Console.WriteLine("no content");
			}
			else
			{
				app.Visible = false;

				object template = Missing.Value;
				object newTemplate = Missing.Value;
				object documentType = Missing.Value;
				object visible = true;

				doc1 = app.Documents.Add(template, newTemplate, documentType, visible);

				doc1.Words.First.InsertBefore(sToSpellCheck);

				doc1.Content.LanguageID = WdLanguageID.wdEnglishUK;

				spellErrorsColl = doc1.SpellingErrors;
				errors = spellErrorsColl.Count;

				object optional = Missing.Value;


				Word.SpellingSuggestions correctionSpelling;

				if(errors > 0){
					for(int p = 1; p <= spellErrorsColl.Count; p++){

						correctionSpelling = app.GetSpellingSuggestions(spellErrorsColl[p].Text);
						tsSpellingError.AppendValues(spellErrorsColl[p].Text, p, spellErrorsColl[p].Start, spellErrorsColl[p].End);
					}
				}

				//doc1.CheckSpelling(
				//	optional, optional, optional, optional, optional, optional,
				//	optional, optional, optional, optional, optional, optional);

				label1.Text = errors + " Errors";
				//object first = 0;
				//object last = doc1.Characters.Count - 1;
				//M2MainTextView1.Buffer.Text = doc1.Range(first, last).Text;
				//textBox1.Text = doc1.Range(ref first, ref last).Text;
			}
		}
		
		protected void OnTreeViewError1CursorChanged (object sender, EventArgs e){
			tsSpellingCorrection.Clear();

			TreeSelection selection = (sender as TreeView).Selection;
			TreeModel model;
			TreeIter iter;

			if(selection.GetSelected(out model, out iter)){
				//Console.WriteLine("Selected item: " + model.GetValue(iter, 0).ToString() + " - " + model.GetValue(iter, 1).ToString());

				int ibob = Convert.ToInt32(model.GetValue(iter, 1).ToString());

				Word.SpellingSuggestions correctionSpelling;
				correctionSpelling = app.GetSpellingSuggestions(spellErrorsColl[ibob].Text);

				for(int x = 1; x <= correctionSpelling.Count; x++){
					tsSpellingCorrection.AppendValues(correctionSpelling[x].Name);
				} 
			}	                       
		}

		protected void OnButton23Clicked (object sender, EventArgs e){
			app.Documents.Close(WdSaveOptions.wdDoNotSaveChanges);
			app.Quit();
		}

		protected void OnTreeViewCorrection1CursorChanged (object sender, EventArgs e){
			button8.Sensitive = true;
		}

		protected void OnButton8Clicked (object sender, EventArgs e){
			TreeSelection selection2 = treeViewCorrection1.Selection;//(sender as TreeView).Selection;
			TreeModel model2;
			TreeIter iter2;

			TreeSelection selection1 = treeViewError1.Selection;//(sender as TreeView).Selection;
			TreeModel model1;
			TreeIter iter1;

			int ibob;
			object first = 0;
			object last = 0;
			if(selection1.GetSelected(out model1, out iter1)){
				ibob = Convert.ToInt32(model1.GetValue(iter1, 1).ToString());
				first = Convert.ToInt32(model1.GetValue(iter1, 2).ToString());
				last = Convert.ToInt32(model1.GetValue(iter1, 3).ToString());
			}

			if(selection2.GetSelected(out model2, out iter2)){
				//Console.WriteLine("Selected item: " + model.GetValue(iter, 0).ToString());


				//spellErrorsColl[ibob].Text = model2.GetValue(iter2, 0).ToString();

				//object first = 0;
				//object last = doc1.Characters.Count - 1;
				Word.Range rng;
				rng = doc1.Range(ref first, ref last);
				rng.Select();
				rng.Text = model2.GetValue(iter2, 0).ToString();

				/*
				doc1.Range(first, last).Text = "";  ///errrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrorrrrrrrrrrrrrrrrr
				int ilength = model2.GetValue(iter2, 0).ToString().Length;

				last = ilength;
				doc1.Range(first, last).Text = model2.GetValue(iter2, 0).ToString();
				//doc1.Range(first, first).Text = model2.GetValue(iter2, 0).ToString();

				first = 0;
				last = doc1.Characters.Count - 1;
				textview1.Buffer.Text = "";
				textview1.Buffer.Text = doc1.Range(first, last).Text;
				*/
			}

		}
	}
}

