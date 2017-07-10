using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFmpegDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            fFmpegPlayer1.of_VideoDispose();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fFmpegPlayer1.of_VideoLoad(textBox1.Text.Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                if (File.Exists(textBox2.Text))
                    fFmpegPlayer1.of_VideoWave(textBox1.Text, textBox2.Text);
                else
                    fFmpegPlayer1.of_VideoLoad(textBox1.Text);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fFmpegPlayer1.iWaveNum = 2;
            fFmpegPlayer1.initWaves();
        }
    }
}
