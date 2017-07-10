using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button_load_Click(object sender, EventArgs e)
        {
            try
            {
                fFmpegPlayer1.of_VideoLoad(textBox_mediaFile.Text.Trim());
                this.Text = textBox_mediaFile.Text.Trim();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
           

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fFmpegPlayer1.of_VideoDispose();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog openMediaFile = new System.Windows.Forms.OpenFileDialog();
                openMediaFile.Title = "选择视频文件";
                openMediaFile.Filter = "所有文件(*.*)|*.*";
                if (openMediaFile.ShowDialog(this) == DialogResult.OK)
                {
                    string currFileName = openMediaFile.FileName;
                   
                    fFmpegPlayer1.of_VideoLoad(currFileName);
                    this.Text = currFileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





    }
}
