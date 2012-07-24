using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Infrastructure.Models;
using HtmlAgilityPack;
using Infrastructure;
using System.Threading.Tasks;

namespace Core
{
    public class PaperWallRssParser : IPaperWallRssParser
    {

        public PaperWallRssParser()
        {

        }

        public Task<List<PWImage>> GetImages(IEnumerable<Theme> selectedThemes)
        {
            throw new NotImplementedException();
        }
    }
}
