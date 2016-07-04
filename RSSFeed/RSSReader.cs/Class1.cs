using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RSSReader.cs
{
    public class Class1
    {
        public class WordPressRSS
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
            public string PubDate { get; set; }
        }


        public static List<WordPressRSS> GetFeed()
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var xmlData = client.DownloadString("https://blog.wordpress.com/feed/");

            XDocument xml = XDocument.Parse(xmlData);

            var Feed = (from story in xml.Descendants("item")
                        select new WordPressRSS
                        {
                            Title = ((string)story.Element("title")),
                            Link = ((string)story.Element("link")),
                            Description = ((string)story.Element("description")),
                            PubDate = ((string)story.Element("pubDate"))
                        }).Take(10).ToList();

            return Feed;

        }

    }
}