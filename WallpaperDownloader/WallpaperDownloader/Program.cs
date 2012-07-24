using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using Ninject.Modules;
using Infrastructure;
using Core;

namespace WallpaperDownloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = BuildKernel().Get<Form1>();

            Application.Run(form);
        }

        static IKernel BuildKernel()
        {
            var kernel = new StandardKernel();
            
            kernel.Bind<IThemeService>().To<ThemeService>().WithConstructorArgument("themeCsv",WallpaperResource.Wallpaper);
            kernel.Bind<IPaperWallRssParser>().To<PaperWallRssParser>();

            return kernel;
        }
    }
}
