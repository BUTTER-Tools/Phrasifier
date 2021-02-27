using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;
using System.Linq;


namespace Phrasifier
{
    public class Phrasifier : Plugin
    {


        public string[] InputType { get; } = { "Tokens" };
        public string OutputType { get; } = "Tokens";

        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { { 0, "TokenCount" } };
        public bool InheritHeader { get; } = false;

        #region Plugin Details and Info

        public string PluginName { get; } = "Phrasify";
        public string PluginType { get; } = "Preprocessing";
        public string PluginVersion { get; } = "0.9.0";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "This plugin will use a BUTTER frequency list to replace individual words with phrases. " + 
                                                    "This is useful for taking n-grams and joining them into single tokens using collocation metrics. " + 
                                                    "A useful preprocessing step for something like word2vec.";
        public string PluginTutorial { get; } = "Coming soon...";
        public bool TopLevel { get; } = false;


        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion




        private string CSVFileLocation { get; set; } = "";
        private string SelectedEncoding { get; set; } = "utf-8";
        private string Delimiter { get; set; } = ",";
        private string Quote { get; set; } = "\"";
        private int maxWords { get; set; } = 0;

        Dictionary<int, HashSet<string>> phraseReplacements { get; set; }
        Dictionary<string, int> OutputArrayMap { get; set; }



        public void ChangeSettings()
        {

            using (var form = new SettingsForm_Phrasifier(CSVFileLocation, SelectedEncoding, Delimiter, Quote))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SelectedEncoding = form.SelectedEncoding;
                    CSVFileLocation = form.CSVFileLocation;
                    Delimiter = form.Delimiter;
                    Quote = form.Quote;
                }
            }
        }





        public Payload RunPlugin(Payload Input)
        {



            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;

            string[] criticalThing = new string[3] { "the", "united", "states" };


            for (int i = 0; i < Input.StringArrayList.Count; i++)
            {


                List<string> phrasifiedText = new List<string>();

                for (int j = 0; j < Input.StringArrayList[i].Length; j++)
                {


                    for (int numberOfWords = maxWords; numberOfWords > 0; numberOfWords--)
                    {

                        //make sure that we don't overextend past the array
                        if (j + numberOfWords - 1 >= Input.StringArrayList[i].Length) continue;

                        //make the target string

                        string TargetString;

                        if (numberOfWords > 1)
                        {
                            TargetString = String.Join("_", Input.StringArrayList[i].Skip(j).Take(numberOfWords).ToArray());

                            if (phraseReplacements[numberOfWords].Contains(TargetString))
                            {
                                phrasifiedText.Add(TargetString);
                                j += numberOfWords - 1;

                                //break out of the lower level for loop back to moving on to new words altogether
                                break;

                            }

                        }
                        else
                        {
                            phrasifiedText.Add(Input.StringArrayList[i][j]);
                        }


                    }

                }

                pData.StringArrayList.Add(phrasifiedText.ToArray());
                pData.SegmentNumber.Add(Input.SegmentNumber[i]);

            }

            return (pData);

        }









        public void Initialize()
        {

            phraseReplacements = new Dictionary<int, HashSet<string>>();
            OutputHeaderData = new Dictionary<int, string>();
            OutputArrayMap = new Dictionary<string, int>();
            maxWords = 0;

            try
            {
                using (var stream = File.OpenRead(CSVFileLocation))
                using (var reader = new StreamReader(stream, encoding: Encoding.GetEncoding(SelectedEncoding)))
                {
                    var data = CsvParser.ParseHeadAndTail(reader, Delimiter[0], Quote[0]);

                    var header = data.Item1;
                    var lines = data.Item2;

                    string[] HeadersFromFile = header.ToArray<string>();

                    foreach (var line in lines)
                    {
                        //read in each row of the frequency list
                        //0 - TextID
                        //1 - Segment
                        //2 - SegmentID
                        //3 - Frequency
                        //4 - Documents (we won't keep this one)
                        //5 - ObsPct
                        //6 - IDF
                        //7 - PhraseLength
                        //8 - Pointwise Mutual Information
                        
                        string word = line[2]; //ngram
                        int phraseLength = Int32.Parse(line[7]);    //PhraseLength
                        double PMI = -1.0;
                        if (!string.IsNullOrEmpty(line[8])) PMI = Double.Parse(line[8]);         //Pointwise Mutual Information

                        if (phraseLength > 1)
                        {

                            if (phraseLength > maxWords) maxWords = phraseLength;

                            if (!phraseReplacements.ContainsKey(phraseLength))
                            {
                                phraseReplacements.Add(phraseLength, new HashSet<string>());
                            }


                            //just making sure that we can adequately capture multi-word phrases regardless of whether there's
                            //spaces or underscores to show separation
                            if (word.Contains(' '))
                            {
                                phraseReplacements[phraseLength].Add(String.Join("_", word.Split(' ')));
                            }
                            //if it's a multi-word phrase, and it doesn't have any spaces, we have to assume that it's already using underscores
                            else
                            {
                                phraseReplacements[phraseLength].Add(word);
                            }
                        }
                    }
                }

            }
            catch
            {
                phraseReplacements = new Dictionary<int, HashSet<string>>();
                OutputHeaderData = new Dictionary<int, string>();
                OutputHeaderData.Add(0, "TokenCount");
                OutputArrayMap = new Dictionary<string, int>();
                MessageBox.Show("There was an error while trying to read your BUTTER Frequency List file. If you currently have the Frequency List file open in another program, please close it and try again. This error can also be caused when your spreadsheet is not correctly formatted, or that your selections for delimiters and quotes are not the same as what is used in your spreadsheet.", "Error reading spreadsheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public bool InspectSettings()
        {
            if (string.IsNullOrEmpty(CSVFileLocation))
            {
                return false;
            }
            else
            {
                return true;
            }
        }





        public Payload FinishUp(Payload Input)
        {
            phraseReplacements.Clear();
            OutputArrayMap.Clear();
            return (Input);
        }


        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {
            CSVFileLocation = SettingsDict["CSVFileLocation"];
            SelectedEncoding = SettingsDict["SelectedEncoding"];
            Delimiter = SettingsDict["Delimiter"];
            Quote = SettingsDict["Quote"];
        }



        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();

            SettingsDict.Add("CSVFileLocation", CSVFileLocation);
            SettingsDict.Add("SelectedEncoding", SelectedEncoding);
            SettingsDict.Add("Delimiter", Delimiter);
            SettingsDict.Add("Quote", Quote);
          
            return (SettingsDict);
        }
        #endregion

       
    }

}