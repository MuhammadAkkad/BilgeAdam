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
            this.btnSavedMovies = new System.Windows.Forms.Button();
            this.btnList100 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbListResult
            // 
            this.lbListResult.FormattingEnabled = true;
            this.lbListResult.Location = new System.Drawing.Point(12, 107);
            this.lbListResult.Name = "lbListResult";
            this.lbListResult.Size = new System.Drawing.Size(383, 329);
            this.lbListResult.TabIndex = 0;
            this.lbListResult.Click += new System.EventHandler(this.lbListResult_Click);
            this.lbListResult.SelectedIndexChanged += new System.EventHandler(this.lbListResult_SelectedIndexChanged);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(12, 81);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(383, 20);
            this.txtLink.TabIndex = 1;
            this.txtLink.TextChanged += new System.EventHandler(this.txtLink_TextChanged);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(9, 65);
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
            // btnSavedMovies
            // 
            this.btnSavedMovies.Location = new System.Drawing.Point(12, 463);
            this.btnSavedMovies.Name = "btnSavedMovies";
            this.btnSavedMovies.Size = new System.Drawing.Size(100, 23);
            this.btnSavedMovies.TabIndex = 5;
            this.btnSavedMovies.Text = "Saved Movies";
            this.btnSavedMovies.UseVisualStyleBackColor = true;
            this.btnSavedMovies.Click += new System.EventHandler(this.btnSavedMovies_Click);
            // 
            // btnList100
            // 
            this.btnList100.Location = new System.Drawing.Point(295, 463);
            this.btnList100.Name = "btnList100";
            this.btnList100.Size = new System.Drawing.Size(100, 23);
            this.btnList100.TabIndex = 6;
            this.btnList100.Text = "Top 100";
            this.btnList100.UseVisualStyleBackColor = true;
            this.btnList100.Click += new System.EventHandler(this.btnList100_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 498);
            this.Controls.Add(this.btnList100);
            this.Controls.Add(this.btnSavedMovies);
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
        private System.Windows.Forms.Button btnSavedMovies;
        private System.Windows.Forms.Button btnList100;
    }
}

