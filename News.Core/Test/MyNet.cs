using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeHollow.FeedReader;

namespace News.Core
{
    public class MyNet : Agency
    {
 
        public MyNet(string link) {
            this.link = link;
        }


        public override List<NewsItem> getNews()
        {
           
            string url = link;
            var feed = FeedReader.Read(url);


            List<NewsItem> list = new List<NewsItem>();
            foreach (var item in feed.Items) {
                NewsItem newsItem = new NewsItem();
                newsItem.title = item.Title;
                newsItem.description = item.Description;
                newsItem.link = item.Link;
                list.Add(newsItem);

            }
            
            return list;
        }
    }
}
