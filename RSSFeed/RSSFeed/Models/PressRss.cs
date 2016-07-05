using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSFeed.Models
{
    public class PressRSS
    {
        public int ID { get; set; }
        public string Title { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
            public string PubDate { get; set; }
        public string Media { get; set; }
    }
}