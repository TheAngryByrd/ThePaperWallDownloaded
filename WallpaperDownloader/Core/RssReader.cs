using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Core  
{
    public class RssReader
    {
        public rss GetFeed(string url)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(rss));
            rss feed = null;
            using (XmlReader reader = XmlReader.Create(url))
            {

                feed = (rss)serializer.Deserialize(reader);
            }
            return feed;
        }
    }
}
