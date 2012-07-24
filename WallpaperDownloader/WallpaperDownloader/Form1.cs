using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Infrastructure.Models;
using Infrastructure;



namespace WallpaperDownloader
{
  

    public partial class Form1 : Form
    {
        private readonly IPaperWallRssParser _paperWallRssParser;
        private readonly IThemeService _themeService;
        private IAsyncDownloadManager _downloadManager;
        private IImageFilter _imageFilter;
        public virtual void Init()
        {
            InitializeComponent();

        
            var themes = _themeService.GetThemes();
            this.themeCheckBoxList.Items.AddRange(themes.Cast<object>().ToArray());
        }

        public Form1(IThemeService themeService, IPaperWallRssParser paperWallRssParser, IImageFilter imageFilter, IAsyncDownloadManager asyncDownloadManager)
        {
            this._themeService = themeService;
            this._paperWallRssParser = paperWallRssParser;
            this._imageFilter = imageFilter;
            this._downloadManager = asyncDownloadManager;
            Init();
        }

        private void EnableButtons(bool enabled)
        {
            BtnGetWallPaper.Enabled = enabled;
            uncheckAll.Enabled = enabled;
            checkAll.Enabled = enabled;
        }

        public async Task DownloadWallpapers(IEnumerable<Theme> selectedThemes)
        {

            //Get all image url from theme rss


            List<PWImage> imageList = await _paperWallRssParser.GetImages(selectedThemes);
            var alreadyDownloadedImages = new List<FileInfo>();
            foreach (var theme in selectedThemes)
            {
                var wallPaperThemePath = Path.Combine(@"c:\wallpapers", theme.Name);
                var dir = Directory.CreateDirectory(wallPaperThemePath);
                alreadyDownloadedImages.AddRange(dir.EnumerateFiles());

            }
            imageList =_imageFilter.RemovePreviouslyDownloadedImages(imageList, alreadyDownloadedImages);

 


             

                 await _downloadManager.DownloadImages(@"c:\wallpapers",imageList);

        }



        private void SetupProgress(PWImage image)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Text = image.imageName;

            var progressBar = new ProgressBar();

            image.progress = new Progress<DownloadProgressChangedEventArgs>();
            image.progress.ProgressChanged += (s, e) =>
            {
                progressBar.Value = e.ProgressPercentage;
            };


            var panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.Controls.Add(progressBar);
            panel.Controls.Add(label);


            progressTable.Controls.Add(panel);
            progressTable.Refresh();

            //var ui = TaskScheduler.FromCurrentSynchronizationContext();

            //return  Task.Factory.StartNew(() =>
            //{

            //    var label = new Label();
            //    label.AutoSize = true;
            //    label.Text = image.imageName;

            //    var progressBar = new ProgressBar();

            //    image.progress = new Progress<DownloadProgressChangedEventArgs>();
            //    image.progress.ProgressChanged += (s, e) =>
            //    {
            //        progressBar.Value = e.ProgressPercentage;
            //    };


            //    var panel = new FlowLayoutPanel();
            //    panel.AutoSize = true;
            //    panel.Controls.Add(progressBar);
            //    panel.Controls.Add(label);


            //    progressTable.Controls.Add(panel);
            //    progressTable.Refresh();

            //}, CancellationToken.None, TaskCreationOptions.PreferFairness, ui);
            
        }
    

        private async void button1_Click(object sender, EventArgs e)
        {

            EnableButtons(false);

            await DownloadWallpapers(this.themeCheckBoxList.CheckedItems.Cast<Theme>());

            EnableButtons(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < themeCheckBoxList.Items.Count; i++)
            {
                themeCheckBoxList.SetItemChecked(i, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < themeCheckBoxList.Items.Count; i++)
            {
                themeCheckBoxList.SetItemChecked(i, false);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            //checkedListBox1.Visible = false;

            var panel = new FlowLayoutPanel();
            panel.AutoSize = true;
            panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            var label = new Label();
            label.Text = "filenamelakjfoajwofijwfoijweaofjawf.jgp";
            var progressBar = new ProgressBar();
            panel.Controls.Add(progressBar);
            panel.Controls.Add(label);
            progressTable.Controls.Add(panel);
            EnableButtons(false);
            var client = new WebClient();
            var dir = @"c:\testPlace\";
            var progress = new Progress<DownloadProgressChangedEventArgs>();
            Directory.CreateDirectory(dir);
            progress.ProgressChanged += (s, eventProgress) =>
            {
                progressBar.Value = eventProgress.ProgressPercentage;

                
            };


            client.DownloadProgressChanged += (s, crazy) =>
                {
                    progressBar.Value = crazy.ProgressPercentage;
                };
            using (client)
            {
                await client.DownloadFileTaskAsync("http://thepaperwall.com/wallpapers/people/big/big_584778739bace9b64fb91975340190ed2f64a51d.jpg", dir + "file.jpg", progress);


            }

            EnableButtons(true);
        }








    }


}
