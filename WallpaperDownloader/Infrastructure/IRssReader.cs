using System;
using Infrastructure;
using Infrastructure.Models;
namespace Infrastructure
{
    public interface IRssReader
    {
        System.Threading.Tasks.Task<rss> GetFeed(string url);
        System.Collections.Generic.List<Infrastructure.Models.PWImage> GetImageUrls(rss feed);
    }
}
