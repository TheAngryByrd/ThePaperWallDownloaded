﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

            var themeService = new ThemeService(new StringReader(WallpaperResource.Wallpaper));
            var themes = themeService.GetThemes();
            this.checkedListBox1.Items.AddRange(themes.Cast<object>().ToArray());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
            
            button1.Enabled = false;
            
            List<Task> downloads = new List<Task>();

            SemaphoreSlim semaphore = new SemaphoreSlim(2, 3); ;
          
            foreach (Theme obj in this.checkedListBox1.CheckedItems)
            {
                await semaphore.WaitAsync();

                var program = new Core.Program();
                var task = Task.Run(async () =>{
                    try
                    {
                        await program.Run(obj.Name, obj.FeedUrl);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                   
                });
                downloads.Add(task);

            }

            await Task.WhenAll(downloads);

            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        

        
    }


}
