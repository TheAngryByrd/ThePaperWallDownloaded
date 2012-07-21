using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallpaperDownloader
{
  

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
            
            button1.Enabled = false;

            await Task.Factory.StartNew(() => Thread.Sleep(3000));

            button1.Enabled = true;
        }

        

        
    }


}
