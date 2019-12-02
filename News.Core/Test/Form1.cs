using News.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using News.Core;

namespace News
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
          //  MyNet myNet = new MyNet(titles.Text);
          //  myNet.getNews();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str = "";
            switch (cbxSites.SelectedItem.ToString())
            {

                case "MyNet":
                    {
                        str = "http://sinema.mynet.com/rss/RSS-enyeniler/rss.xml";
                        break;
                    }
                case "CNN":
                    {
                        str = "https://www.cnnturk.com/feed/rss/dunya/news";
                        break;
                    }
                case "HaberTurk":
                    {
                        str = "http://www.haberturk.com/rss/kategori/teknoloji.xml";
                        break;
                    }
                default:
                    break;
            }

            
            MyNet myNet = new MyNet(str);

            List<NewsItem> list = new List<NewsItem>();
            list = myNet.getNews();
            titles.Items.Clear();
            foreach (var item in list)
            {
                titles.Items.Add(item.title);
            }
           
        }

        private void lbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
