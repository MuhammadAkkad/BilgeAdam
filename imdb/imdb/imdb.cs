using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace imdb
{
    public partial class Main : Form
    {
        imdbServices service = new imdbServices();
        List<MovieDTO> mList = new List<MovieDTO>();
        List<string> sList = new List<string>();
        MovieDTO movieDTO = new MovieDTO();
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
            mList.Clear();
            mList = service.Search(txtLink.Text);
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
            movieDTO = mList[movieIndex];
            MovieDetailsForm mdf = new MovieDetailsForm(movieDTO);
            mdf.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnSavedMovies_Click(object sender, EventArgs e)
        {
            mList.Clear();
            lbListResult.Items.Clear();
            mList = service.GetAllMovies();
            foreach (var item in mList)
            {
                lbListResult.Items.Add(item.Name);
            }
        }
        private void btnList100_Click(object sender, EventArgs e)
        {
            sList = service.Top100();
            foreach (var item in sList)
            {
                lbListResult.Items.Add(item);
            }
        }
    }
}