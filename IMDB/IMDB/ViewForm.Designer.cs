namespace imdb
{
    partial class ViewForm
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
            this.lbMovieList = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRank = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.rtDesc = new System.Windows.Forms.RichTextBox();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.lbDirectors = new System.Windows.Forms.ListBox();
            this.lbStars = new System.Windows.Forms.ListBox();
            this.lbWriters = new System.Windows.Forms.ListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMovieList
            // 
            this.lbMovieList.FormattingEnabled = true;
            this.lbMovieList.Location = new System.Drawing.Point(12, 12);
            this.lbMovieList.Name = "lbMovieList";
            this.lbMovieList.Size = new System.Drawing.Size(207, 186);
            this.lbMovieList.TabIndex = 0;
            this.lbMovieList.SelectedIndexChanged += new System.EventHandler(this.lbMovieList_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(299, 24);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(241, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtRank
            // 
            this.txtRank.Location = new System.Drawing.Point(299, 50);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(241, 20);
            this.txtRank.TabIndex = 2;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(299, 76);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(241, 20);
            this.txtYear.TabIndex = 4;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(246, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Title";
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Location = new System.Drawing.Point(246, 53);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(31, 13);
            this.lblRank.TabIndex = 7;
            this.lblRank.Text = "Rank";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(233, 105);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 8;
            this.lblDesc.Text = "Description";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(246, 79);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 9;
            this.lblYear.Text = "Year";
            // 
            // rtDesc
            // 
            this.rtDesc.Location = new System.Drawing.Point(299, 105);
            this.rtDesc.Name = "rtDesc";
            this.rtDesc.Size = new System.Drawing.Size(241, 83);
            this.rtDesc.TabIndex = 10;
            this.rtDesc.Text = "";
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(586, 12);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(202, 186);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 11;
            this.pbPoster.TabStop = false;
            // 
            // lbDirectors
            // 
            this.lbDirectors.FormattingEnabled = true;
            this.lbDirectors.Location = new System.Drawing.Point(299, 218);
            this.lbDirectors.Name = "lbDirectors";
            this.lbDirectors.Size = new System.Drawing.Size(159, 121);
            this.lbDirectors.TabIndex = 12;
            // 
            // lbStars
            // 
            this.lbStars.FormattingEnabled = true;
            this.lbStars.Location = new System.Drawing.Point(464, 218);
            this.lbStars.Name = "lbStars";
            this.lbStars.Size = new System.Drawing.Size(159, 121);
            this.lbStars.TabIndex = 13;
            // 
            // lbWriters
            // 
            this.lbWriters.FormattingEnabled = true;
            this.lbWriters.Location = new System.Drawing.Point(629, 218);
            this.lbWriters.Name = "lbWriters";
            this.lbWriters.Size = new System.Drawing.Size(159, 121);
            this.lbWriters.TabIndex = 14;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 316);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(94, 316);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbWriters);
            this.Controls.Add(this.lbStars);
            this.Controls.Add(this.lbDirectors);
            this.Controls.Add(this.pbPoster);
            this.Controls.Add(this.rtDesc);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblRank);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtRank);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lbMovieList);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.Load += new System.EventHandler(this.ViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMovieList;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtRank;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.RichTextBox rtDesc;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.ListBox lbDirectors;
        private System.Windows.Forms.ListBox lbStars;
        private System.Windows.Forms.ListBox lbWriters;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}