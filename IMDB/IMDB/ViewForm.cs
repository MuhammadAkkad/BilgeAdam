using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace imdb
{
    public partial class ViewForm : Form
    {
        List<MovieDTO> mList = new List<MovieDTO>();
        List<CastDTO> cList = new List<CastDTO>();
        MovieService services = new MovieService();
        MovieDTO movieDTO = new MovieDTO();

        public ViewForm()
        {
            InitializeComponent();
        }

        private void lbMovieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int movieIndex = lbMovieList.SelectedIndex;
            movieDTO = mList[movieIndex];
            txtTitle.Text = movieDTO.Name;
            txtRank.Text = movieDTO.Rank;
            txtYear.Text = movieDTO.Year.ToString();
            rtDesc.Text = movieDTO.Description;
            pbPoster.ImageLocation = movieDTO.Photo;

            //services.
            //lbDirectors.Items.Add();


        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            var obj = services.GetAllMovies();
            mList = new JavaScriptSerializer().Deserialize<List<MovieDTO>>(obj);
            foreach (var item in mList)
            {
                lbMovieList.Items.Add(item.Name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var json = new JavaScriptSerializer().Serialize(movieDTO);
            services.Delete(json);
        }
    }
}
