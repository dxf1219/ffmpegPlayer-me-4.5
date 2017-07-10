using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myWaveBar
{
    public partial class MyWaveBar: UserControl
    {
        public MyWaveBar()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设置当前位置
        /// </summary>
        /// <param name="Cpre"></param>
        public void of_SetPosition(double Cpre)
        {
            try
            {
                //获得长度
                int h = (int)(Cpre * this.Size.Height);
                this.panelBar.Height = h;
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message + ee.StackTrace); }
        }



        private void MyWaveBar_Load(object sender, EventArgs e)
        {
            this.of_SetPosition(0);
        }
    }
}
