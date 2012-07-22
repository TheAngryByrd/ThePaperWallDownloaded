using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Core.Tests
{
    [TestClass]
    public class ThemeServiceShould
    {
        [TestMethod]
        public void ReturnAllThemesFromGivenResourceFile()
        {

            var csv = "Name1,Url1,Name2,Url2";

            ThemeService service = new ThemeService(null );
            var themes = service.GetThemes();

            Assert.AreEqual("Name1", themes[0].Name);
            Assert.AreEqual("Url1", themes[0].FeedUrl);
            Assert.AreEqual("Name2", themes[1].Name);
            Assert.AreEqual("Url2", themes[1].FeedUrl);
        }
    }
}
