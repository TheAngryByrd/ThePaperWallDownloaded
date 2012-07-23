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
using Core.Models;

namespace WallpaperDownloader
{
  

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var themeService = new ThemeService(WallpaperResource.Wallpaper);
            var themes = themeService.GetThemes();
            this.themeCheckBoxList.Items.AddRange(themes.Cast<object>().ToArray());
        }

        private void EnableButtons(bool enabled)
        {
            BtnGetWallPaper.Enabled = enabled;
            uncheckAll.Enabled = enabled;
            checkAll.Enabled = enabled;
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            EnableButtons(false);
           
            
            //List<Task> downloads = new List<Task>();

            //SemaphoreSlim semaphore = new SemaphoreSlim(2, 3); ;
          
            //foreach (Theme obj in this.themeCheckBoxList.CheckedItems)
            //{
            //    await semaphore.WaitAsync();

            //    var program = new Core.Program();
            //    var task = Task.Run(async () =>{
            //        try
            //        {
            //            await program.Run(obj.Name, obj.FeedUrl);
            //        }
            //        finally
            //        {
            //            semaphore.Release();
            //        }
                   
            //    });
            //    downloads.Add(task);

            //}

            //await Task.WhenAll(downloads);

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
