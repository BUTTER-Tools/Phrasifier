namespace Phrasifier
{
    partial class SettingsForm_Phrasifier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm_Phrasifier));
            this.SetFileButton = new System.Windows.Forms.Button();
            this.SelectedFileTextbox = new System.Windows.Forms.TextBox();
            this.EncodingDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CSVQuoteTextbox = new System.Windows.Forms.TextBox();
            this.CSVDelimiterTextbox = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SetFileButton
            // 
            this.SetFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetFileButton.Location = new System.Drawing.Point(12, 159);
            this.SetFileButton.Name = "SetFileButton";
            this.SetFileButton.Size = new System.Drawing.Size(118, 40);
            this.SetFileButton.TabIndex = 0;
            this.SetFileButton.Text = "Choose File";
            this.SetFileButton.UseVisualStyleBackColor = true;
            this.SetFileButton.Click += new System.EventHandler(this.SetFolderButton_Click);
            // 
            // SelectedFileTextbox
            // 
            this.SelectedFileTextbox.Enabled = false;
            this.SelectedFileTextbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFileTextbox.Location = new System.Drawing.Point(12, 130);
            this.SelectedFileTextbox.MaxLength = 2147483647;
            this.SelectedFileTextbox.Name = "SelectedFileTextbox";
            this.SelectedFileTextbox.Size = new System.Drawing.Size(463, 23);
            this.SelectedFileTextbox.TabIndex = 1;
            // 
            // EncodingDropdown
            // 
            this.EncodingDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingDropdown.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodingDropdown.FormattingEnabled = true;
            this.EncodingDropdown.Location = new System.Drawing.Point(12, 50);
            this.EncodingDropdown.Name = "EncodingDropdown";
            this.EncodingDropdown.Size = new System.Drawing.Size(268, 23);
            this.EncodingDropdown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select BUTTER Frequency List File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Frequency List File Encoding";
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(218, 346);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(118, 40);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CSVQuoteTextbox
            // 
            this.CSVQuoteTextbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSVQuoteTextbox.Location = new System.Drawing.Point(137, 262);
            this.CSVQuoteTextbox.MaxLength = 1;
            this.CSVQuoteTextbox.Name = "CSVQuoteTextbox";
            this.CSVQuoteTextbox.Size = new System.Drawing.Size(101, 23);
            this.CSVQuoteTextbox.TabIndex = 22;
            this.CSVQuoteTextbox.Text = "\"";
            this.CSVQuoteTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CSVDelimiterTextbox
            // 
            this.CSVDelimiterTextbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSVDelimiterTextbox.Location = new System.Drawing.Point(15, 261);
            this.CSVDelimiterTextbox.MaxLength = 1;
            this.CSVDelimiterTextbox.Name = "CSVDelimiterTextbox";
            this.CSVDelimiterTextbox.Size = new System.Drawing.Size(101, 23);
            this.CSVDelimiterTextbox.TabIndex = 21;
            this.CSVDelimiterTextbox.Text = ",";
            this.CSVDelimiterTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(134, 243);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(86, 16);
            this.label42.TabIndex = 20;
            this.label42.Text = "CSV Quote:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(14, 243);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(102, 16);
            this.label41.TabIndex = 19;
            this.label41.Text = "CSV Delimiter:";
            // 
            // SettingsForm_Phrasifier
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 400);
            this.Controls.Add(this.CSVQuoteTextbox);
            this.Controls.Add(this.CSVDelimiterTextbox);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EncodingDropdown);
            this.Controls.Add(this.SelectedFileTextbox);
            this.Controls.Add(this.SetFileButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm_Phrasifier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SetFileButton;
        private System.Windows.Forms.TextBox SelectedFileTextbox;
        private System.Windows.Forms.ComboBox EncodingDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox CSVQuoteTextbox;
        private System.Windows.Forms.TextBox CSVDelimiterTextbox;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
    }
}