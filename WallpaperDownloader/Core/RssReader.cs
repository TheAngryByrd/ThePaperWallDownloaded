using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HtmlAgilityPack;
using Infrastructure;
using Infrastructure.Models;

namespace Core  
{
    public class RssReader : IRssReader
    {
        public async Task<rss> GetFeed(string url)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(rss));
            rss feed = null;
            XmlReader reader = await Task.Run(() => XmlReader.Create(url));
            using (reader)
            {
                feed = (rss)serializer.Deserialize(reader);
            }
            return feed;
        }

        public List<PWImage> GetImageUrls(rss feed)
        {
            var images = new List<PWImage>();
            HtmlDocument doc = new HtmlDocument();
            foreach (var rssChannelItem in feed.channel.item)
            {
                var html = rssChannelItem.description;

                doc.LoadHtml(html);
                var imageUrl = doc.DocumentNode.ChildNodes[1].Attributes[0].Value;
                images.Add(new PWImage { imageUrl = imageUrl });
            }
            return images;
        }
    }
}
