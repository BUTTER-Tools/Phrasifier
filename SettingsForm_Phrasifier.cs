using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;





namespace Phrasifier
{
    internal partial class SettingsForm_Phrasifier : Form
    {


        #region Get and Set Options

        public string CSVFileLocation { get; set; }
        public string SelectedEncoding { get; set; }
        public string Delimiter { get; set; }
        public string Quote { get; set; }
        #endregion



        public SettingsForm_Phrasifier(string CSVFileLocation, string SelectedEncoding, string Delimiter, string Quote)
        {
            InitializeComponent();

            foreach (var encoding in Encoding.GetEncodings())
            {
                EncodingDropdown.Items.Add(encoding.Name);
            }

            try
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact(SelectedEncoding);
            }
            catch
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact(Encoding.Default.BodyName);
            }

            CSVDelimiterTextbox.Text = Delimiter;
            CSVQuoteTextbox.Text = Quote;
            SelectedFileTextbox.Text = CSVFileLocation;


            this.SelectedEncoding = SelectedEncoding;

           
        }












        private void SetFolderButton_Click(object sender, System.EventArgs e)
        {


            SelectedFileTextbox.Text = "";

            if (CSVDelimiterTextbox.TextLength < 1 || CSVQuoteTextbox.TextLength < 1)
            {
                MessageBox.Show("You must enter characters for your delimiter and quotes, respectively. This plugin does not know how to read a delimited spreadsheet without this information.", "I need details for your spreadsheet!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            using (var dialog = new OpenFileDialog())
            {

                dialog.Multiselect = false;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.ValidateNames = true;
                dialog.Title = "Please choose the BUTTER Frequency file that you would like to read";
                dialog.FileName = "BUTTER-FrequencyList.csv";
                dialog.Filter = "Comma-Separated Values (CSV) File (*.csv)|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFileTextbox.Text = dialog.FileName;

                }
                else
                {
                    SelectedFileTextbox.Text = "";
                }
            }
        }
















        private void OKButton_Click(object sender, System.EventArgs e)
        {
            this.SelectedEncoding = EncodingDropdown.SelectedItem.ToString();

            this.CSVFileLocation = SelectedFileTextbox.Text;

            if (CSVQuoteTextbox.Text.Length > 0)
            {
                this.Quote = CSVQuoteTextbox.Text;
            }
            else
            {
                this.Quote = "\"";
            }
            if (CSVDelimiterTextbox.Text.Length > 0)
            {
                this.Delimiter = CSVDelimiterTextbox.Text;
            }
            else
            {
                this.Delimiter = ",";
            }
            



            this.DialogResult = DialogResult.OK;

        }
    }
}
