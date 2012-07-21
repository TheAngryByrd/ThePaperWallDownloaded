using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class WallpaperFeed
    {
        private string _category;
        private string _rssLink;
        public WallpaperFeed(string category, string rssLink)
        {
            _category = category;
            _rssLink = rssLink;
        }

        public override string ToString()
        {
            return _category;
        }
    }
}
