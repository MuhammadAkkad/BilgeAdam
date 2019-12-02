namespace News
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Update = new System.Windows.Forms.Button();
            this.titles = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbxSites = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.SystemColors.Highlight;
            this.Update.Location = new System.Drawing.Point(566, 270);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(192, 31);
            this.Update.TabIndex = 0;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.button1_Click);
            // 
            // titles
            // 
            this.titles.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.titles.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titles.FormattingEnabled = true;
            this.titles.ItemHeight = 20;
            this.titles.Location = new System.Drawing.Point(12, 42);
            this.titles.Name = "titles";
            this.titles.Size = new System.Drawing.Size(514, 384);
            this.titles.TabIndex = 1;
            this.titles.SelectedIndexChanged += new System.EventHandler(this.lbResult_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cbxSites
            // 
            this.cbxSites.AccessibleDescription = "";
            this.cbxSites.AccessibleName = "";
            this.cbxSites.BackColor = System.Drawing.SystemColors.Window;
            this.cbxSites.FormattingEnabled = true;
            this.cbxSites.Items.AddRange(new object[] {
            "CNN",
            "MyNet",
            "HaberTurk"});
            this.cbxSites.Location = new System.Drawing.Point(566, 129);
            this.cbxSites.Name = "cbxSites";
            this.cbxSites.Size = new System.Drawing.Size(192, 94);
            this.cbxSites.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxSites);
            this.Controls.Add(this.titles);
            this.Controls.Add(this.Update);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.ListBox titles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckedListBox cbxSites;
    }
}

