using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure
{
    public interface IPaperWallRssParser
    {

        Task<List<PWImage>> GetImages(IEnumerable<Models.Theme> selectedThemes);
    }
}
