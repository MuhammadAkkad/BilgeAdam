namespace imdb
{
    partial class ListDBMovies
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
            this.gvMovieDBList = new System.Windows.Forms.DataGridView();
            this.imdbContextDataSet = new imdb.imdbContextDataSet();
            this.moviesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moviesTableAdapter = new imdb.imdbContextDataSetTableAdapters.MoviesTableAdapter();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rankDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovieDBList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imdbContextDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gvMovieDBList
            // 
            this.gvMovieDBList.AutoGenerateColumns = false;
            this.gvMovieDBList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMovieDBList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.linkDataGridViewTextBoxColumn,
            this.rankDataGridViewTextBoxColumn});
            this.gvMovieDBList.DataSource = this.moviesBindingSource;
            this.gvMovieDBList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMovieDBList.Location = new System.Drawing.Point(0, 0);
            this.gvMovieDBList.Name = "gvMovieDBList";
            this.gvMovieDBList.Size = new System.Drawing.Size(541, 373);
            this.gvMovieDBList.TabIndex = 0;
            this.gvMovieDBList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMovieDBList_CellContentClick);
            // 
            // imdbContextDataSet
            // 
            this.imdbContextDataSet.DataSetName = "imdbContextDataSet";
            this.imdbContextDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // moviesBindingSource
            // 
            this.moviesBindingSource.DataMember = "Movies";
            this.moviesBindingSource.DataSource = this.imdbContextDataSet;
            // 
            // moviesTableAdapter
            // 
            this.moviesTableAdapter.ClearBeforeFill = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // linkDataGridViewTextBoxColumn
            // 
            this.linkDataGridViewTextBoxColumn.DataPropertyName = "Link";
            this.linkDataGridViewTextBoxColumn.HeaderText = "Link";
            this.linkDataGridViewTextBoxColumn.Name = "linkDataGridViewTextBoxColumn";
            // 
            // rankDataGridViewTextBoxColumn
            // 
            this.rankDataGridViewTextBoxColumn.DataPropertyName = "Rank";
            this.rankDataGridViewTextBoxColumn.HeaderText = "Rank";
            this.rankDataGridViewTextBoxColumn.Name = "rankDataGridViewTextBoxColumn";
            // 
            // ListDBMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 373);
            this.Controls.Add(this.gvMovieDBList);
            this.Name = "ListDBMovies";
            this.Text = "ListDBMovies";
            this.Load += new System.EventHandler(this.ListDBMovies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMovieDBList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imdbContextDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvMovieDBList;
        private imdbContextDataSet imdbContextDataSet;
        private System.Windows.Forms.BindingSource moviesBindingSource;
        private imdbContextDataSetTableAdapters.MoviesTableAdapter moviesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rankDataGridViewTextBoxColumn;
    }
}