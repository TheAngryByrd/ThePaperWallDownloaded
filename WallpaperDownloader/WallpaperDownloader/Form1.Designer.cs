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
            this.BtnGetWallPaper = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.themeCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.checkAll = new System.Windows.Forms.Button();
            this.uncheckAll = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetWallPaper
            // 
            this.BtnGetWallPaper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGetWallPaper.Location = new System.Drawing.Point(437, 530);
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
            this.checkAll.Location = new System.Drawing.Point(453, 13);
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
            this.uncheckAll.Location = new System.Drawing.Point(453, 42);
            this.uncheckAll.Name = "uncheckAll";
            this.uncheckAll.Size = new System.Drawing.Size(75, 23);
            this.uncheckAll.TabIndex = 3;
            this.uncheckAll.Text = "Unselect All";
            this.uncheckAll.UseVisualStyleBackColor = true;
            this.uncheckAll.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(453, 163);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.panel1.Size = new System.Drawing.Size(419, 540);
            this.panel1.TabIndex = 6;
            // 
            // progressTable
            // 
            this.progressTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressTable.AutoScroll = true;
            this.progressTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.progressTable.Location = new System.Drawing.Point(169, 3);
            this.progressTable.Name = "progressTable";
            this.progressTable.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.progressTable.Size = new System.Drawing.Size(231, 530);
            this.progressTable.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(540, 565);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.uncheckAll);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.BtnGetWallPaper);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGetWallPaper;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox themeCheckBoxList;
        private System.Windows.Forms.Button checkAll;
        private System.Windows.Forms.Button uncheckAll;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.TableLayoutPanel progressTable;
      
    }
}

