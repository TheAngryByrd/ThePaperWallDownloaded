using System.Windows.Forms;
namespace WallpaperDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnGetWallPaper = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.themeCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.checkAll = new System.Windows.Forms.Button();
            this.uncheckAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressTable = new System.Windows.Forms.TableLayoutPanel();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetWallPaper
            // 
            this.BtnGetWallPaper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGetWallPaper.Location = new System.Drawing.Point(489, 530);
            this.BtnGetWallPaper.Name = "BtnGetWallPaper";
            this.BtnGetWallPaper.Size = new System.Drawing.Size(91, 23);
            this.BtnGetWallPaper.TabIndex = 0;
            this.BtnGetWallPaper.Text = "GetWallPapers";
            this.BtnGetWallPaper.UseVisualStyleBackColor = true;
            this.BtnGetWallPaper.UseWaitCursor = true;
            this.BtnGetWallPaper.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // themeCheckBoxList
            // 
            this.themeCheckBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.themeCheckBoxList.FormattingEnabled = true;
            this.themeCheckBoxList.Location = new System.Drawing.Point(0, 0);
            this.themeCheckBoxList.Name = "themeCheckBoxList";
            this.themeCheckBoxList.Size = new System.Drawing.Size(163, 529);
            this.themeCheckBoxList.TabIndex = 1;
            // 
            // checkAll
            // 
            this.checkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkAll.Location = new System.Drawing.Point(505, 13);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(75, 23);
            this.checkAll.TabIndex = 2;
            this.checkAll.Text = "Select All";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.Click += new System.EventHandler(this.button3_Click);
            // 
            // uncheckAll
            // 
            this.uncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uncheckAll.Location = new System.Drawing.Point(505, 42);
            this.uncheckAll.Name = "uncheckAll";
            this.uncheckAll.Size = new System.Drawing.Size(75, 23);
            this.uncheckAll.TabIndex = 3;
            this.uncheckAll.Text = "Unselect All";
            this.uncheckAll.UseVisualStyleBackColor = true;
            this.uncheckAll.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.themeCheckBoxList);
            this.panel1.Controls.Add(this.progressTable);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 540);
            this.panel1.TabIndex = 6;
            // 
            // progressTable
            // 
            this.progressTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressTable.AutoScroll = true;
            this.progressTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.progressTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.progressTable.Location = new System.Drawing.Point(169, 3);
            this.progressTable.Name = "progressTable";
            this.progressTable.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.progressTable.Size = new System.Drawing.Size(240, 530);
            this.progressTable.TabIndex = 8;
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Location = new System.Drawing.Point(533, 135);
            this.labelDownloaded.Margin = new System.Windows.Forms.Padding(3, 0, 50, 0);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(0, 13);
            this.labelDownloaded.TabIndex = 7;
            this.labelDownloaded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDownloaded.UseMnemonic = false;
            this.labelDownloaded.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(455, 371);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // DownloadTimer
            // 
            this.DownloadTimer.Enabled = true;
            this.DownloadTimer.Interval = 21600000;
            this.DownloadTimer.Tick += new System.EventHandler(this.DownloadTimer_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ThePaperWall";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(592, 565);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uncheckAll);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.BtnGetWallPaper);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);

            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private System.Windows.Forms.Button BtnGetWallPaper;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox themeCheckBoxList;
        private System.Windows.Forms.Button checkAll;
        private System.Windows.Forms.Button uncheckAll;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.TableLayoutPanel progressTable;
        private Label labelDownloaded;
        private Label label1;
        private Timer DownloadTimer;
        private NotifyIcon notifyIcon1;
      
    }
}

