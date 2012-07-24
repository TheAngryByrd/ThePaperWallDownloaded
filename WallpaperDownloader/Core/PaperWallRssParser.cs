using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Infrastructure.Models;
using HtmlAgilityPack;
using Infrastructure;
using System.Threading.Tasks;

namespace Core
{
    public class PaperWallRssParser : IPaperWallRssParser
    {
        private IRssReader rssReader;


  

        public PaperWallRssParser(IRssReader rssReader)
        {
            // TODO: Complete member initialization
            this.rssReader = rssReader;
        }

        public async Task<List<PWImage>> GetImages(IEnumerable<Theme> selectedThemes)
        {
            List<PWImage> images = new List<PWImage>();
            foreach (Theme theme in selectedThemes)
            {
                var rss = await rssReader.GetFeed(theme.FeedUrl);
                var tempImages = rssReader.GetImageUrls(rss);
                tempImages.ForEach(i => i.Theme = theme);
                images.AddRange(tempImages);
            }

            return images;
        }
    }
}
