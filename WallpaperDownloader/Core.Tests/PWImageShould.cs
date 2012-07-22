using System;
using Core;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class ImageShould
    {
        private string expectedImageUrl = @"http://thepaperwall.com/wallpapers/people/big/big_584778739bace9b64fb91975340190ed2f64a51d.jpg";

        [TestMethod]
        public void GetFileNameFromUrl()
        {
            var image = new PWImage();
            var imageName = image.GetImageFileName(expectedImageUrl);

            Assert.AreEqual("big_584778739bace9b64fb91975340190ed2f64a51d.jpg", imageName);

        }

        [TestMethod]
        public void FileNameShouldCallGetImageFileName()
        {
            var image = new PWImage();
            image.imageUrl = expectedImageUrl;
            Assert.AreEqual("big_584778739bace9b64fb91975340190ed2f64a51d.jpg", image.imageName);
        }

    }
}
