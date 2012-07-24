using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class PaperWallParserShould
    {

        private string expectedImageUrl = @"http://thepaperwall.com/wallpapers/people/big/big_584778739bace9b64fb91975340190ed2f64a51d.jpg";
        [TestMethod]
        public void CanGetImagesFromRssFeed()
        {
        
            string description = string.Format(@"<p><a href=""{0}""><img src=""http://thepaperwall.com/wallpapers/people/small/small_584778739bace9b64fb91975340190ed2f64a51d.jpg?x=130&y=89&q=85&sig=SVA2qhNVOsYltxwW7ULPyQ--"" align=""left"" height=""150"" width=""240""/>", expectedImageUrl);
            var rssChannelItem = new rssChannelItem
            {
                description =
                    description
            };
            var rssChannelItem2 = new rssChannelItem
            {
                description =
                    description
            };

            PaperWallRssParser parser = new PaperWallRssParser();


            var rss = new rss
            {
                channel = new rssChannel
                {
                    item = new rssChannelItem[] { rssChannelItem, rssChannelItem2 }
                }
            };
            List<PWImage> imageUrls = parser.GetImageUrls(rss);

            Assert.AreEqual(2, imageUrls.Count);

            foreach (var image in imageUrls)
            {
                Assert.AreEqual(expectedImageUrl, image.imageUrl);
            }
        }

      
    }
}
