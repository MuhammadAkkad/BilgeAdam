namespace WinORM
{
    partial class DbManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbManager));
            this.trvServerItems = new System.Windows.Forms.TreeView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.connect = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateClassContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvServerItems
            // 
            this.trvServerItems.ImageKey = "Database_16x.png";
            this.trvServerItems.ImageList = this.ImageList;
            this.trvServerItems.Location = new System.Drawing.Point(25, 61);
            this.trvServerItems.Name = "trvServerItems";
            this.trvServerItems.SelectedImageIndex = 0;
            this.trvServerItems.Size = new System.Drawing.Size(211, 353);
            this.trvServerItems.TabIndex = 0;
            this.trvServerItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvServerItems_AfterSelect);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "Database_16x.png");
            this.ImageList.Images.SetKeyName(1, "Database_8x_16x.png");
            this.ImageList.Images.SetKeyName(2, "AzureTable_color_16x.png");
            this.ImageList.Images.SetKeyName(3, "Field_16x.png");
            this.ImageList.Images.SetKeyName(4, "Key_16x.png");
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(161, 9);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 1;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(25, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 2;
            this.txtServer.Text = "Localhost";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripMenuItem,
            this.generateClassContextMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.InfoToolStripMenuItem.Text = "Info";
            this.InfoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // generateClassContextMenu
            // 
            this.generateClassContextMenu.Name = "generateClassContextMenu";
            this.generateClassContextMenu.Size = new System.Drawing.Size(151, 22);
            this.generateClassContextMenu.Text = "Generate Class";
            this.generateClassContextMenu.Click += new System.EventHandler(this.generateClassContextMenu_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(348, 61);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(440, 353);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // DbManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.trvServerItems);
            this.Name = "DbManager";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DbManager_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvServerItems;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateClassContextMenu;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ImageList ImageList;
    }
}

