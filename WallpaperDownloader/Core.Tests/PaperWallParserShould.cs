using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Core.Tests
{
    [TestClass]
    public class PaperWallParserShould
    {

        [TestMethod]
        public void GetRssItemsParseTheUrlImagesFromFeedFilterOutAlreadyDownloadedImagesAndSetTheThemeOnEachImage()
        {
            var rssReader = MockRepository.GenerateMock<IRssReader>();


            PaperWallRssParser parser = new PaperWallRssParser(rssReader);
            var themes = new List<Theme>();
            themes.Add(new Theme{FeedUrl= "url1"});
            themes.Add(new Theme { FeedUrl = "url2" });
            var url1Rss = new rss();
             var url2Rss = new rss();
            var url1RssTask = Task<rss>.Run(() => { return url1Rss; });
            var url2RssTask = Task<rss>.Run(() => { return url2Rss; });

            rssReader.Expect(a => a.GetFeed(Arg<string>.Is.Equal("url1"))).Return(url1RssTask);
            rssReader.Expect(a => a.GetFeed(Arg<string>.Is.Equal("url2"))).Return(url2RssTask);

            var url1Images = new List<PWImage>{new PWImage()};
            var url2Image =new List<PWImage> { new PWImage(), new PWImage() };
            rssReader.Expect(a => a.GetImageUrls(Arg<rss>.Is.Equal(url1Rss))).Return(url1Images);
            rssReader.Expect(a => a.GetImageUrls(Arg<rss>.Is.Equal(url2Rss))).Return(url2Image);



            var pwImages = parser.GetImages(themes).Result;

            rssReader.VerifyAllExpectations();

            Assert.AreEqual(3, pwImages.Count);
            Assert.AreEqual(themes[0],pwImages[0].Theme);
            Assert.AreEqual(themes[1], pwImages[1].Theme);
            Assert.AreEqual(themes[1], pwImages[2].Theme);

        }





      
    }
}
