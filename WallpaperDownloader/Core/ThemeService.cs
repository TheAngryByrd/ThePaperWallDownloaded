using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using CsvHelper;

namespace Core
{
    public class ThemeService
    {

        private string _csv;
        private Stream stream;
        private string themeCsv;

   
 

        public ThemeService(string themeCsv)
        {
            // TODO: Complete member initialization
            this.themeCsv = themeCsv;
        }

        public List<Theme> GetThemes()
        {
            var themes = new List<Theme>();

            var reader = new CsvReader(new StringReader(themeCsv));
            while (reader.Read())
            {
                var currentObject = reader.CurrentRecord;
                themes.Add(new Theme { Name = currentObject[0], FeedUrl = currentObject[1].Trim() });
            }
            return themes;
        }

        //public static StreamReader GetResource(string dotFilePath)
        //{
        //    try
        //    {
        //        var assembly = Assembly.GetExecutingAssembly();
        //        var assemblyName = assembly.GetName().Name;
        //        var stream = assembly.GetManifestResourceStream(assemblyName + "." + dotFilePath);

        //        return new StreamReader(stream);

                
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return null;
        //    }
        //}
    }
}
