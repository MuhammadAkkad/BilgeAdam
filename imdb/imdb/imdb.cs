using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Services;

namespace imdb
{
    public partial class Main : Form
    {

        imdbServices s = new imdbServices();
        List<Movie> mList = new List<Movie>();
        List<string> sList = new List<string>();
        Movie movie = new Movie();
        public Main()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbListResult.Items.Clear();
            mList = s.Search(txtLink.Text);
            foreach (var item in mList)
            {
                lbListResult.Items.Add(item.Name);
            }
        }
        private void txtLink_TextChanged(object sender, EventArgs e)
        {

        }
        private void lbListResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lbListResult_Click(object sender, EventArgs e)
        {
            int movieIndex = lbListResult.SelectedIndex;
            movie = mList[movieIndex];
            MovieDetailsForm mdf = new MovieDetailsForm(movie);
            mdf.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnSavedMovies_Click(object sender, EventArgs e)
        {
            ListDBMovies db = new ListDBMovies();
            db.Show();
        }
        private void btnList100_Click(object sender, EventArgs e)
        {
           sList = s.Top100();
            foreach (var item in sList)
            {                
                lbListResult.Items.Add(item); //lbListResult.Items.Add(m.Groups[1].Value);
            }
        }
    }
}