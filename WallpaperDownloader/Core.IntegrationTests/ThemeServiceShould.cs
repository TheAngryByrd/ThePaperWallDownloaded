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


            ThemeService service = new ThemeService(WallpaperResource.Wallpaper );
            var themes = service.GetThemes();

            Assert.AreEqual("Wallpaper of the Day", themes[0].Name);
            Assert.AreEqual("http://www.thepaperwall.com/wallpaperday_rss.php", themes[0].FeedUrl);
            Assert.AreEqual(38, themes.Count);

        }
    }
}
