using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using RSSFeed.Models;

namespace RSSFeed
{

   
    public class RSSFeedReader
    {
        


        private static List<string> GetRssFeeds()
        {
            List<string> feeds = new List<string>();

            feeds.Add("http://feeds.bbci.co.uk/news/england/rss.xml");
            feeds.Add("http://www.huffingtonpost.co.uk/feeds/index.xml");

            return feeds;
        }

        public static List<PressRSS> GetFeed()
        {
            // both the links go to the config file
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var Feed = new List<PressRSS>();
            foreach (var feed in GetRssFeeds())
            {
                Uri feedUri = new Uri(feed);
                var xmlData = client.DownloadString(feedUri);
                XDocument xml = XDocument.Parse(xmlData);
                XNamespace media = XNamespace.Get("http://search.yahoo.com/mrss/");
                var result = (from story in xml.Descendants("item")
                        select new PressRSS
                        {
                            Title = ((string)story.Element("title")),
                            Link = ((string)story.Element("link")),
                            Description = ((string)story.Element("description")),
                            PubDate = ((string)story.Element("pubDate")),
                            Media = story.Element(media + "thumbnail") != null ? story.Element(media + "thumbnail").Attribute("url").Value : ""

                        }).Take(10).ToList();

                Feed.AddRange(result);

            }


            return Feed;

        }
    }
}