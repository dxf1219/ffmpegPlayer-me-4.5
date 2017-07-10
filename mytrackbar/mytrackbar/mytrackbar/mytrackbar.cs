using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mytrackbar
{

    //定义一个事件委托类型，注意不是事件 
    public delegate void CBarMouseMove();


     public partial class mytrackbar : UserControl
    {
         public mytrackbar()
        {
            InitializeComponent();
        }

        #region 控件用变量
        public double idp = 0;
        public double iSdp = 0;
        public double iEdp = 0;
        public double iOSdp = 0;
        public double iOEdp = 0;
        public int iiLen = 0;
        #endregion

        /// <summary>
        /// 设置开始选择段
        /// </summary>
        /// <param name="p"></param>
        public void of_SetSPosition(double STdpre)
        {
            try
            {
                //获得长度
                iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
                if (iiLen <= 0) iiLen = 0;
                this.iSdp = STdpre;
                int liX = (int)(STdpre * iiLen);
                this.pictureBoxSTD.Width = liX;
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message + ee.StackTrace); }
        }

        /// <summary>
        /// 设置结束选择段
        /// </summary>
        /// <param name="p"></param>
        public void of_SetEPosition(double ETdpre)
        {
            try
            {
                //获得长度
                iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
                if (iiLen <= 0) iiLen = 0;
                this.iEdp = ETdpre;
                int liX = (int)(ETdpre * iiLen);
                //设计结束点的位置
                this.pictureBoxETD.Location = new Point(liX, this.pictureBoxETD.Location.Y);
                this.pictureBoxETD.Width = iiLen - liX;
                //设置最后指示位
                this.labelEnd.Location = new Point(iiLen, this.labelEnd.Location.Y);
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message + ee.StackTrace); }
        }

        /// <summary>
        /// 设置当前的位置
        /// </summary>
        /// <param name="llCurrentFrame"></param>
        public void of_SetPosition(double CTdpre)
        {
            try
            {
                //获得长度
                iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
                if (iiLen <= 0) iiLen = 0;
                this.idp = CTdpre;
                int liX = (int)(CTdpre * iiLen);
                int liY = this.pictureBoxPin.Location.Y;
                this.pictureBoxPin.Location = new Point(liX, liY);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + ee.StackTrace);
            }
        }

        /// <summary>
        /// 原始的位置
        /// </summary>
        /// <param name="STdpre"></param>
        public void of_SetOSPosition(double Tdpre)
        {
            try
            {
                //获得长度
                iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
                if (iiLen <= 0) iiLen = 0;
                this.iOSdp = Tdpre;
                int liX = (int)(Tdpre * iiLen);
                this.panelOSS.Width = liX;
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message + ee.StackTrace); }
        }

        /// <summary>
        /// 原始的位置
        /// </summary>
        /// <param name="STdpre"></param>
        public void of_SetOEPosition(double Tdpre)
        {
            try
            {
                //获得长度
                iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
                if (iiLen <= 0) iiLen = 0;
                this.iOEdp = Tdpre;
                int liX = (int)(Tdpre * iiLen);
                //设计结束点的位置
                this.panelOSE.Location = new Point(liX, this.panelOSE.Location.Y);
                this.panelOSE.Width = iiLen - liX;
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message + ee.StackTrace); }
        }

        /// <summary>
        /// 根据bar的位置返回当前帧数
        /// </summary>
        /// <returns></returns>
        public double of_GetPosition()
        {
            try
            {
                iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
                return (double)(this.pictureBoxPin.Location.X) / (double)(this.iiLen);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + ee.StackTrace);
            }
            return 0;
        }

     

        /// <summary>
        /// 定义一个事件
        /// </summary>
        public event CBarMouseMove oeBarMouseMove;


        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mytrackbar_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int Len = this.Width;
            double p = (double)x / (double)Len;
            of_SetPosition(p);
            if (oeBarMouseMove != null)
            {
                oeBarMouseMove();
            }
        }

        /// <summary>
        /// 进行控件初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void mytrackbar_Load(object sender, EventArgs e)
        {
            try
            {
                this.of_SetSPosition(0);
                this.of_SetEPosition(1);
                this.of_SetPosition(0);
                this.of_SetOSPosition(0);
                this.of_SetOEPosition(1);
                this.MouseClick += new MouseEventHandler(mytrackbar_MouseClick);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }



        /// <summary>
        /// 尺寸改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mytrackbar_SizeChanged(object sender, EventArgs e)
        {
            //指针按比列改动
            this.of_SetPosition(this.idp);
            this.of_SetSPosition(this.iSdp);
            this.of_SetEPosition(this.iEdp);
            this.of_SetOSPosition(this.iOSdp);
            this.of_SetOEPosition(this.iOEdp);
        }

        private void pictureBoxPin_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //设置位置
                if (Control.MouseButtons.ToString() != "Left") return;
                int liX = this.pictureBoxPin.Location.X + e.X;
                int liY = this.pictureBoxPin.Location.Y;
                if (liX < 0) return;
                if (liX > this.Size.Width - this.pictureBoxPin.Size.Width) return;
                this.pictureBoxPin.Location = new Point(liX, liY);
                this.Refresh();
                //获得比列
                this.idp = this.of_GetPosition();
                //调用一个可以在外部定义的事件
                this.oeBarMouseMove();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + ee.StackTrace);
            }
        }

        private void pictureBoxSTD_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int Len = this.Width;
            double p = (double)x / (double)Len;
            of_SetPosition(p);
            if (oeBarMouseMove != null)
            {
                oeBarMouseMove();
            }
        }

        private void pictureBoxETD_MouseClick(object sender, MouseEventArgs e)
        {

            int x = pictureBoxETD.Location.X + e.X;
            int Len = this.Width;
            double p = (double)x / (double)Len;
            of_SetPosition(p);
            if (oeBarMouseMove != null)
            {
                oeBarMouseMove();
            }
        }

        //#region 控件用方法

        ///// <summary>
        ///// 设置开始的
        ///// </summary>
        ///// <param name="p"></param>
        //public void of_SetSPosition(double p)
        //{
        //    try
        //    {
        //        //获得长度
        //        iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
        //        if (iiLen <= 0) iiLen = 0;
        //        this.iSdp = p;
        //        int liX = (int)(p * iiLen);
        //        int liY = this.pictureBoxPinS.Location.Y;
        //        this.pictureBoxPinS.Location = new Point(liX, liY);
        //        this.of_SetPc();
        //    }
        //    catch (Exception ee)
        //    { MessageBox.Show(ee.Message + ee.StackTrace); }
        //}

        ///// <summary>
        ///// 设置开始的
        ///// </summary>
        ///// <returns></returns>
        //public double of_GetSPosition()
        //{
        //    try
        //    {
        //        iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
        //        return (double)(this.pictureBoxPinS.Location.X) / (double)(this.iiLen);

        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //    return 0;
        //}

        ///// <summary>
        ///// 设置结束的
        ///// </summary>
        ///// <param name="p"></param>
        //public void of_SetEPosition(double p)
        //{
        //    try
        //    {
        //        //获得长度
        //        iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
        //        if (iiLen <= 0) iiLen = 0;
        //        this.iEdp = p;
        //        int liX = (int)(p * iiLen);
        //        int liY = this.pictureBoxPinE.Location.Y;
        //        this.pictureBoxPinE.Location = new Point(liX, liY);
        //        this.of_SetPc();
        //    }
        //    catch (Exception ee)
        //    { MessageBox.Show(ee.Message + ee.StackTrace); }
        //}

        ///// <summary>
        ///// 设置结束的
        ///// </summary>
        ///// <returns></returns>
        //public double of_GetEPosition()
        //{
        //    try
        //    {
        //        iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
        //        return (double)(this.pictureBoxPinE.Location.X) / (double)(this.iiLen);

        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //    return 0;
        //}

        ///// <summary>
        ///// 设置当前的位置
        ///// </summary>
        ///// <param name="llCurrentFrame"></param>
        //public void of_SetPosition(double p)
        //{
        //    try
        //    {
        //        //获得长度
        //        iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
        //        if (iiLen <= 0) iiLen = 0;
        //        this.idp = p;
        //        int liX = (int)(p * iiLen);
        //        int liY = this.pictureBoxPin.Location.Y;
        //        this.pictureBoxPin.Location = new Point(liX, liY);
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //}

        ///// <summary>
        ///// 根据bar的位置返回当前帧数
        ///// </summary>
        ///// <returns></returns>
        //public double of_GetPosition()
        //{
        //    try
        //    {
        //        iiLen = this.Size.Width - this.pictureBoxPin.Size.Width;
        //        return (double)(this.pictureBoxPin.Location.X) / (double)(this.iiLen);

        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //    return 0;
        //}

        ///// <summary>
        ///// 根据输入的帧数换算显示为时间码
        ///// </summary>
        ///// <param name="llFrame"></param>
        ///// <returns></returns>
        //public string of_TimecodeByF(long llFrame)
        //{
        //    try
        //    {
        //        long llYs = 0;
        //        string lsH = "";
        //        string lsM = "";
        //        string lsS = "";
        //        string lsF = "";
        //        double lFramePerSec = Math.Ceiling(iFramePerSec);
        //        long D = System.Math.DivRem(llFrame, (long)(3600 * lFramePerSec * 24), out llYs);
        //        if (D > 0)
        //        {
        //            MessageBox.Show("你输入的时间大于1天，请更换节目！", "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return "00:00:00:00";
        //        }

        //        long H = System.Math.DivRem(llFrame, (long)(3600 * lFramePerSec), out llYs);
        //        if (H > 0)
        //        {
        //            long llH = (100 + H);
        //            lsH = llH.ToString().Substring(1, 2);
        //        }
        //        else { lsH = "00"; }

        //        long M = System.Math.DivRem(llYs, (long)(60 * lFramePerSec), out llYs);
        //        if (M > 0)
        //        {
        //            long llM = (100 + M);
        //            lsM = llM.ToString().Substring(1, 2);
        //        }
        //        else { lsM = "00"; }

        //        long S = System.Math.DivRem(llYs, (long)(lFramePerSec), out llYs);
        //        if (S > 0)
        //        {
        //            long llS = (100 + S);
        //            lsS = llS.ToString().Substring(1, 2);
        //        }
        //        else { lsS = "00"; }

        //        llYs = 100 + llYs;
        //        lsF = llYs.ToString().Substring(1, 2);

        //        return lsH + ":" + lsM + ":" + lsS + ":" + lsF;
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //    return "00:00:00:00";
        //}

        ///// <summary>
        ///// 根据输入的帧数换算显示天数和剩余的帧数
        ///// </summary>
        ///// <param name="llFrame"></param>
        ///// <returns></returns>
        //public long of_GetDaysByF(long llFrame,out long frames)
        //{
        //    try
        //    {
        //        double lFramePerSec = Math.Ceiling(iFramePerSec);
        //        frames = 0;
        //        long D = System.Math.DivRem(llFrame, (long)(3600 * lFramePerSec * 24), out frames);
        //        if (D > 0)
        //        {
        //           return D;
        //        }
        //        else if (D == 0)
        //        {
        //            frames = llFrame;
        //            return 0;
        //        }
        //        return D;
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //        frames = -1;
        //        return -1;
        //    }

        //}

        ///// <summary>
        ///// 根据输入的时间码换算为帧数
        ///// </summary>
        ///// <param name="llFrame"></param>
        ///// <returns></returns>
        //public long of_FramesByT(string lsTimecode)
        //{
        //    try
        //    {
        //        long ll_frameNo = 0;
        //        if (lsTimecode.Length < 11) return -1;
        //        double lFramePerSec = Math.Ceiling(iFramePerSec);
        //        long llH = long.Parse(lsTimecode.Substring(0, 2));
        //        long llm = long.Parse(lsTimecode.Substring(3, 2));
        //        long lls = long.Parse(lsTimecode.Substring(6, 2));
        //        long llf = long.Parse(lsTimecode.Substring(9, 2));
        //        ll_frameNo = (3600 * llH + 60 * llm + lls) * (long)(lFramePerSec) + llf;
        //        return ll_frameNo;
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //    return 0;
        //}



        ///// <summary>
        ///// 设置巴条显示的总的帧的长度，并显示标尺
        ///// </summary>
        ///// <param name="llFrames"></param>
        //public void of_SetTimeCodeLen(long llFrames)
        //{
        //    try
        //    {
        //        //根据输入的帧长度，显示每个标尺
        //        ilFrames = llFrames;
        //        long llFF = llFrames / 4;
        //        this.labelF.Text = this.of_TimecodeByF(llFF);
        //        long llMF = (long)(llFrames * 0.5);
        //        this.labelM.Text = this.of_TimecodeByF(llMF);
        //        long llBF = (long)(llFrames * 0.75);
        //        this.labelB.Text = this.of_TimecodeByF(llBF);
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //}

        //#endregion

        //#region 控件用事件

        ///// <summary>
        ///// 初始化
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CMediaTrackBar_Load(object sender, EventArgs e)
        //{
        //    this.of_SetRule();
        //    this.of_SetPosition(0);
        //    this.of_SetSPosition(0);
        //    this.of_SetEPosition(1);
        //}

        ///// <summary>
        ///// 尺寸改变
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CMediaTrackBar_SizeChanged(object sender, EventArgs e)
        //{
        //    this.of_SetRule();

        //}

        /////// <summary>
        /////// 定义一个事件
        /////// </summary>
        ////public event CBarSMouseMove oeBarSMouseMove;

        /////// <summary>
        /////// 定义一个事件
        /////// </summary>
        ////public event CBarEMouseMove oeBarEMouseMove;

        /////// <summary>
        /////// 定义一个事件
        /////// </summary>
        ////public event CBarMouseMove oeBarMouseMove;

        ///// <summary>
        ///// 针
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void pictureBoxPin_MouseMove(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        //设置位置
        //        if (Control.MouseButtons.ToString() != "Left") return;
        //        int liX = this.pictureBoxPin.Location.X + e.X;
        //        int liY = this.pictureBoxPin.Location.Y;
        //        if (liX < 0) return;
        //        if (liX > this.Size.Width - this.pictureBoxPin.Size.Width) return;
        //        this.pictureBoxPin.Location = new Point(liX, liY);
        //        this.Refresh();
        //        //获得比列
        //        this.idp = this.of_GetPosition();
        //        //调用一个可以在外部定义的事件
        //        this.oeBarMouseMove();
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(ee.Message + ee.StackTrace);
        //    }
        //}

        //#endregion
    }
}
