using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

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
            Movie movie = new Movie();
            DialogResult dr = MessageBox.Show("Please choose an option: \n Yes View \n No Delete \n" +
                "\n Cancel Does nothing :)", "Action", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);

            // Show Details
            if (dr == DialogResult.Yes)
            {
                if (gvMovieDBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
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
                }
            }
            // Delete
            else if (dr == DialogResult.No)
            {
                if (gvMovieDBList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string link = gvMovieDBList.Rows[e.RowIndex].Cells[3].Value.ToString();                    
                    var movieObject = ctx.Movies.FirstOrDefault(m => m.Link == link);
                    ctx.Movies.Remove(movieObject);
                    ctx.SaveChanges();
                }
                MessageBox.Show("deleted");
            }
            else
            {
                MessageBox.Show("else!");
            }
            this.moviesTableAdapter.Fill(this.imdbContextDataSet.Movies);
        }
    }
}
