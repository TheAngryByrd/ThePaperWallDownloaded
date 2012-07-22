using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core.Models;
using HtmlAgilityPack;

namespace Core
{
    public class PaperWallRssParser
    {
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
