namespace imdb
{
    partial class Main
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
            this.lbListResult = new System.Windows.Forms.ListBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.lblLink = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbListResult
            // 
            this.lbListResult.FormattingEnabled = true;
            this.lbListResult.Location = new System.Drawing.Point(12, 127);
            this.lbListResult.Name = "lbListResult";
            this.lbListResult.Size = new System.Drawing.Size(383, 433);
            this.lbListResult.TabIndex = 0;
            this.lbListResult.Click += new System.EventHandler(this.lbListResult_Click);
            this.lbListResult.SelectedIndexChanged += new System.EventHandler(this.lbListResult_SelectedIndexChanged);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(12, 79);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(383, 20);
            this.txtLink.TabIndex = 1;
            this.txtLink.TextChanged += new System.EventHandler(this.txtLink_TextChanged);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(9, 63);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(84, 13);
            this.lblLink.TabIndex = 2;
            this.lblLink.Text = "Search keyword";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 572);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.lbListResult);
            this.Name = "Main";
            this.Text = "Movies";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbListResult;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.Button btnSearch;
    }
}

