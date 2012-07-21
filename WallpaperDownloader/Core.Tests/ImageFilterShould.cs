using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Core.Tests
{
    [TestClass]
    public class ImageFilterShould
    {
        [TestMethod]
        public void RemoveAllImageUrlsThatHaveAlreadyBeenDownloaded()
        {
            ImageFilter filter = new ImageFilter();
            List<PWImage> images = new List<PWImage>();

            var alreadyDownloadedImage = "myAlreadyDownloadedImage.jpg";

            images.Add(new PWImage{imageUrl="http://google.com/newimage.jpg"});
            images.Add(new PWImage { imageUrl = "http://google.com/" + alreadyDownloadedImage });
            var fileInfoList = new List<FileInfo>();
            FileInfo fi = new FileInfo(@"c:\testWallpaper\" + alreadyDownloadedImage);
            fileInfoList.Add(fi);
            IEnumerable<FileInfo> fileInfoEnumerable = fileInfoList;
            List<PWImage> filteredImageList = filter.RemovePreviouslyDownloadedImages(images, fileInfoEnumerable);
            Assert.AreEqual(1, filteredImageList.Count);
            Assert.AreEqual(images[0], filteredImageList[0]);
        }
    }
}
