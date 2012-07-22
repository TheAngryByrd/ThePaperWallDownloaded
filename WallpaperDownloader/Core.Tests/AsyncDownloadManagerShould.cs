using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Core.Tests
{
    [TestClass]
    public class AsyncDownloadManagerShould
    {
        [TestMethod]
        public void CreateAnAsyncTaskForEachImageUrl()
        {
            var imageDownloader = MockRepository.GenerateMock<IImageDownloader>();
            AsyncDownloadManager downloadManager = new AsyncDownloadManager(imageDownloader);
            string directory = @"c:\images";

            var images = new List<PWImage>();
            images.Add(new PWImage());
            images.Add(new PWImage());
            var downloads = downloadManager.GenerateDownloadTasks(directory, null);
            
             Assert.AreEqual(2, 1);
          
        }

        [TestMethod]
        public void RunAllTasks()
        {
            var imageDownloader = MockRepository.GenerateMock<IImageDownloader>();
            imageDownloader.Expect(a => a.Download("","")).IgnoreArguments().Repeat.Twice();
            AsyncDownloadManager downloadManager = new AsyncDownloadManager(imageDownloader);
            List<Task> tasks = new List<Task>();
            for(int i =0;i<2;i++)
            {
                 tasks.Add( Task.Factory.StartNew(() => imageDownloader.Download("","")));
            }



            downloadManager.RunTasks(tasks.ToArray());

            imageDownloader.VerifyAllExpectations();
       
        }
    }
}
