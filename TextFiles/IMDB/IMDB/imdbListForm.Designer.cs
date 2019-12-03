namespace IMDB
{
    partial class IMDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param directorName="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.btnShow = new System.Windows.Forms.Button();
            this.lbFilmList = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.ListBox();
            this.lbDirectors = new System.Windows.Forms.ListBox();
            this.lbWriters = new System.Windows.Forms.ListBox();
            this.lbStars = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(12, 78);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(170, 23);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Search";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lbFilmList
            // 
            this.lbFilmList.FormattingEnabled = true;
            this.lbFilmList.Location = new System.Drawing.Point(221, 43);
            this.lbFilmList.Name = "lbFilmList";
            this.lbFilmList.Size = new System.Drawing.Size(529, 82);
            this.lbFilmList.TabIndex = 2;
            this.lbFilmList.SelectedIndexChanged += new System.EventHandler(this.lbFilmList_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // lbDescription
            // 
            this.lbDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lbDescription.FormattingEnabled = true;
            this.lbDescription.HorizontalExtent = 100;
            this.lbDescription.Location = new System.Drawing.Point(12, 131);
            this.lbDescription.MaximumSize = new System.Drawing.Size(1000, 212);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.ScrollAlwaysVisible = true;
            this.lbDescription.Size = new System.Drawing.Size(738, 82);
            this.lbDescription.TabIndex = 4;
            this.lbDescription.SelectedIndexChanged += new System.EventHandler(this.lbDescription_SelectedIndexChanged);
            // 
            // lbDirectors
            // 
            this.lbDirectors.FormattingEnabled = true;
            this.lbDirectors.Location = new System.Drawing.Point(62, 242);
            this.lbDirectors.Name = "lbDirectors";
            this.lbDirectors.Size = new System.Drawing.Size(168, 95);
            this.lbDirectors.TabIndex = 5;
            this.lbDirectors.SelectedIndexChanged += new System.EventHandler(this.lbDirectors_SelectedIndexChanged);
            // 
            // lbWriters
            // 
            this.lbWriters.FormattingEnabled = true;
            this.lbWriters.Location = new System.Drawing.Point(265, 242);
            this.lbWriters.Name = "lbWriters";
            this.lbWriters.Size = new System.Drawing.Size(169, 95);
            this.lbWriters.TabIndex = 6;
            this.lbWriters.SelectedIndexChanged += new System.EventHandler(this.lbWriters_SelectedIndexChanged);
            // 
            // lbStars
            // 
            this.lbStars.FormattingEnabled = true;
            this.lbStars.Location = new System.Drawing.Point(486, 242);
            this.lbStars.Name = "lbStars";
            this.lbStars.Size = new System.Drawing.Size(160, 95);
            this.lbStars.TabIndex = 7;
            this.lbStars.SelectedIndexChanged += new System.EventHandler(this.lbStars_SelectedIndexChanged);
            // 
            // IMDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 349);
            this.Controls.Add(this.lbStars);
            this.Controls.Add(this.lbWriters);
            this.Controls.Add(this.lbDirectors);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbFilmList);
            this.Controls.Add(this.btnShow);
            this.Name = "IMDB";
            this.Text = "IMDB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListBox lbFilmList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox lbDescription;
        private System.Windows.Forms.ListBox lbDirectors;
        private System.Windows.Forms.ListBox lbWriters;
        private System.Windows.Forms.ListBox lbStars;
    }
}

