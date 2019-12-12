using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imdb
{
    public partial class ListDBMovies : Form
    {
        imdbContext ctx = new imdbContext();
        public ListDBMovies()
        {
            InitializeComponent();
        }

        private void ListDBMovies_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'imdbContextDataSet.Movies' table. You can move, or remove it, as needed.
            this.moviesTableAdapter.Fill(this.imdbContextDataSet.Movies);

        }

        private void gvMovieDBList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvMovieDBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Movie movie = new Movie();
                string name = gvMovieDBList.Rows[e.RowIndex].Cells[0].Value.ToString();
                string desc = gvMovieDBList.Rows[e.RowIndex].Cells[1].Value.ToString();
                string year = gvMovieDBList.Rows[e.RowIndex].Cells[2].Value.ToString();
                DateTime Date = Convert.ToDateTime(year);
                string link = gvMovieDBList.Rows[e.RowIndex].Cells[3].Value.ToString();
                string rank = gvMovieDBList.Rows[e.RowIndex].Cells[4].Value.ToString();

                movie.Name = name;
                movie.Description = desc;
                movie.Year = Date;
                movie.Link = link;
                movie.Rank = rank;
                MovieDetailsForm mdf = new MovieDetailsForm(movie);
                mdf.Show();

                //ctx.Movies.Where(m => m.Link == movie.Link).ToList();
            }
        }
    }
}
