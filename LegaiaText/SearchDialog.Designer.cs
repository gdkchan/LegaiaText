namespace LegaiaText
{
    partial class SearchDialog
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
            this.LabelInstructions = new System.Windows.Forms.Label();
            this.TextSearch = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelInstructions
            // 
            this.LabelInstructions.AutoSize = true;
            this.LabelInstructions.Location = new System.Drawing.Point(12, 9);
            this.LabelInstructions.Name = "LabelInstructions";
            this.LabelInstructions.Size = new System.Drawing.Size(203, 13);
            this.LabelInstructions.TabIndex = 0;
            this.LabelInstructions.Text = "Type the text to search on the box below:";
            // 
            // TextSearch
            // 
            this.TextSearch.Location = new System.Drawing.Point(12, 29);
            this.TextSearch.Name = "TextSearch";
            this.TextSearch.Size = new System.Drawing.Size(290, 20);
            this.TextSearch.TabIndex = 1;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(308, 29);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(64, 20);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "&OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 61);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.TextSearch);
            this.Controls.Add(this.LabelInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "SearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchDialog_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelInstructions;
        private System.Windows.Forms.TextBox TextSearch;
        private System.Windows.Forms.Button ButtonOK;
    }
}