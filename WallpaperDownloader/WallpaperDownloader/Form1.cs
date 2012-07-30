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
using System.Collections.Concurrent;
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
        private List<Theme> _themes;
        private bool _canShow = false;

        public virtual void Init()
        {
            InitializeComponent();

        
            _themes = _themeService.GetThemes();
            this.themeCheckBoxList.Items.AddRange(_themes.Cast<object>().ToArray());
        }

        protected override void SetVisibleCore(bool value)
        {
            if (_canShow)
            {
                base.SetVisibleCore(value);
            }
            else
            {
                base.SetVisibleCore(false);
            }
        }

        

        public Form1(IThemeService themeService, IPaperWallRssParser paperWallRssParser, IImageFilter imageFilter, IAsyncDownloadManager asyncDownloadManager)
        {
            this._themeService = themeService;
            this._paperWallRssParser = paperWallRssParser;
            this._imageFilter = imageFilter;
            this._downloadManager = asyncDownloadManager;
            Init();
            DownloadTimer_Tick(this, null);
            


        }

        private void EnableButtons(bool enabled)
        {
            BtnGetWallPaper.Enabled = enabled;
            uncheckAll.Enabled = enabled;
            checkAll.Enabled = enabled;
        }

        public async Task DownloadWallpapers(string mainWallpaperDir, IEnumerable<Theme> selectedThemes)
        {


            List<PWImage> imageList = await _paperWallRssParser.GetImages(selectedThemes);
            var alreadyDownloadedImages = new List<FileInfo>();
            foreach (var theme in selectedThemes)
            {
                var wallPaperThemePath = Path.Combine(mainWallpaperDir, theme.Name);
                var dir = Directory.CreateDirectory(wallPaperThemePath);
                alreadyDownloadedImages.AddRange(dir.EnumerateFiles());

            }
            imageList =_imageFilter.RemovePreviouslyDownloadedImages(imageList, alreadyDownloadedImages);




            await _downloadManager.DownloadImages(mainWallpaperDir, imageList, SetupProgress, TaskScheduler.FromCurrentSynchronizationContext());

                notifyIcon1.BalloonTipText = string.Format("{0} images downloaded", imageList.Count);
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "WallpapersDownloaded";
                notifyIcon1.ShowBalloonTip(500);
            
        }



        private void SetupProgress(PWImage image, string dir)
        {
            progressTable.SuspendLayout();
            var label = new Label();
            label.AutoSize = true;
            label.Text = dir;

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
            progressTable.ResumeLayout();
    
        }
    

        private async void button1_Click(object sender, EventArgs e)
        {
            await DownloadEvent();

            
        }

        private async Task DownloadEvent()
        {

            EnableButtons(false);
            await DownloadWallpapers(@"c:\wallpapers", this.themeCheckBoxList.CheckedItems.Cast<Theme>());
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



        private async void DownloadTimer_Tick(object sender, EventArgs e)
        {
            EnableButtons(false);
            await DownloadWallpapers(@"c:\wallpapers", _themes);
            EnableButtons(true);
        }


        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

            e.Cancel = true; // this cancels the close event.
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this._canShow = true;
            this.Show();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

    }


}
