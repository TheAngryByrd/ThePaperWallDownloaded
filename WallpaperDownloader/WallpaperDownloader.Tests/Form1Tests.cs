using System;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Windows.Forms;
using System.Collections.Generic;
using Infrastructure.Models;

namespace WallpaperDownloader.Tests
{
    [TestClass]
    public class Form1Tests
    {


        [TestMethod]
        public void DownloadShouldGetAllImagesForEachRssInSelectedTheme()
        {

            var themeSevice = MockRepository.GenerateStub<IThemeService>();
            themeSevice.Stub(a => a.GetThemes()).Return(new List<Theme>());
            var paperWallRssParser = MockRepository.GenerateStub<IPaperWallRssParser>();
            var imageFilter = MockRepository.GenerateStub<IImageFilter>();
            var downloader = MockRepository.GenerateStub<IAsyncDownloadManager>();
            var themes = new List<Theme>();
            paperWallRssParser.Expect(a => a.GetImages(Arg<List<Theme>>.Is.Equal(themes)));


            var form = MockRepository.GeneratePartialMock<Form1>(themeSevice, paperWallRssParser, imageFilter,downloader);
           

            paperWallRssParser.VerifyAllExpectations();
        }
    }
}
