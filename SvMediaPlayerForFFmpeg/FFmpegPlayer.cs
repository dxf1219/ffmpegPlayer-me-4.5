using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace MediaPlayerForFFmpeg
{

    /// <summary>
    /// 定义一个事件委托类型，表示进行图片获取，并保存在C:\temp.jpg
    /// </summary>
    public delegate void cMediaPlayCaptureRemark(long llTmC, string lsJpgFile, string lsRemark);

    /// <summary>
    /// 媒体播放器类
    /// </summary>
    public partial class FFmpegPlayer : UserControl
    {
        public FFmpegPlayer()
        {
            InitializeComponent();
        }

        #region 播放器参数
        /// <summary>
        /// 播放器指针
        /// </summary>
        public IntPtr ipMedia = IntPtr.Zero;
        public IntPtr ipWav = IntPtr.Zero;
        /// <summary>
        /// 当前播放的文件
        /// </summary>
        public string currentFile = "";
        public string currentWav = "";
        /// <summary>
        /// 当前时间
        /// </summary>
        public long ilTmC = 0;
        public string isTmc = "00:00:00:00";

        /// <summary>
        /// 时长
        /// </summary>
        public long ilTmD = 0;
        public string isTmd = "00:00:00:00";

        public long ilTmSS = 0;
        public long ilTmSE = 0;

        /// <summary>
        /// 帧率
        /// </summary>
        float iflFps = 25;

        //图像参数
        int clipw = 1920; //宽度
        int cliph = 1080; //高度

        /// <summary>
        /// 读取标志
        /// </summary>
        bool iboolisLoad = false;
        bool iboolisStop = false;
        bool iboolisPlay = false;
              
        /// <summary>
        /// 临时文件路径
        /// </summary>
        public string isTempDir = "C:\\DBoxTemp\\";

        /// <summary>
        /// 显示音频数
        /// </summary>
        public int iWaveNum = 2;
        /// <summary>
        /// 音柱宽
        /// </summary>
        int iWaveWidth = 15;

        #endregion

        /// <summary>
        /// 含备注的捕获
        /// </summary>
        public event cMediaPlayCaptureRemark OncMediaPlayCaptureRemark;

        /// <summary>
        /// 设置视频窗口的显示位置和大小
        /// </summary>
        /// <param name="clipw"></param>
        /// <param name="cliph"></param>
        private void of_CtrSetPicShowSize(int clipw, int cliph)
        {
            try
            {
                //获得视频宽高比（宽/高）
                double clipr = (double)(clipw) / (double)(cliph);
                //获得容器的大小
                int contenth = this.pictureBoxShow.Parent.Size.Height;
                int contentw = this.pictureBoxShow.Parent.Size.Width;
                double contentr = (double)(contentw) / (double)(contenth);
                //说明容器宽度小了，或者高度张了，那么就以容器宽度为标准
                //高度根据比例进行计算，并获得高度的
                if (contentr <= clipr)
                {
                    int pshoww = contentw;
                    int pshowh = (int)((double)(contentw) / clipr);
                    int pshowx = 0;
                    int pshowy = (contenth - pshowh) / 2;
                    //pictureBoxShow.Size = new Size(pshoww, pshowh);
                    //pictureBoxShow.Location = new Point(pshowx, pshowy);
                    panelControlT.Height = panelControlB.Height = pshowy;
                    panelControlL.Width = panelControlR.Width = pshowx;
                }
                if (contentr > clipr)
                {
                    int pshoww = (int)((double)(contenth) * clipr); ;
                    int pshowh = contenth;
                    int pshowx = (contentw - pshoww) / 2;
                    int pshowy = 0;
                    //pictureBoxShow.Size = new Size(pshoww, pshowh);
                    //pictureBoxShow.Location = new Point(pshowx, pshowy);      
                    panelControlT.Height = panelControlB.Height = pshowy;
                    panelControlL.Width = panelControlR.Width = pshowx;
                }               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

        /// <summary>
        /// 获得播放速率
        /// </summary>
        /// <returns></returns>
        public int of_GetRate()
        {
            if (comboBoxEditRate.Text == "1倍速")
            {
                return 1;
            }
            if (comboBoxEditRate.Text == "1.5倍速")
            {
                return 0;
            }
            if (comboBoxEditRate.Text == "2倍速")
            {
                return 2;
            }
            if (comboBoxEditRate.Text == "3倍速")
            {
                return 3;
            }
            if (comboBoxEditRate.Text == "4倍速")
            {
                return 4;
            }
            if (comboBoxEditRate.Text == "5倍速")
            {
                return 5;
            }
            return 1;
        }

        /// <summary>
        /// 获得文件xml的对应值
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string of_FileXmlValue(XmlDocument doc, string lsClass, int StreamNo, string key)
        {
            try
            {
                if (lsClass == "General")
                {
                    XmlNodeList lNodes = doc.GetElementsByTagName(lsClass);
                    XmlNode xG = lNodes[0];
                    for (int i = 0; i < xG.ChildNodes.Count; i++)
                    {
                        string Ckey = xG.ChildNodes[i].Attributes["Name"].Value;
                        if (Ckey == key)
                        {
                            return xG.ChildNodes[i].InnerText;
                        }
                    }
                    return "";
                }
                else
                {
                    XmlNodeList lNodes = doc.GetElementsByTagName(lsClass);
                    if (lNodes.Count == 0) return "";
                    XmlNode xAV = lNodes[0];
                    int lCount = xAV.ChildNodes.Count;
                    if (lCount == 0) return "";
                    XmlNode xAVRow = xAV.ChildNodes[StreamNo];
                    for (int i = 0; i < xAVRow.ChildNodes.Count; i++)
                    {
                        string Ckey = xAVRow.ChildNodes[i].Attributes["Name"].Value;
                        if (Ckey == key)
                        {
                            return xAVRow.ChildNodes[i].InnerText;
                        }
                    }
                    return "";
                }
            }
            catch (Exception ex)
            { MessageBox.Show("ExError: MediaInfoRead:" + ex.Message + ex.StackTrace); }
            return "";
        }

        private void FFmpegPlayer_Load(object sender, EventArgs e)
        {
            panelControlT.Height = panelControlB.Height = 0;
            panelControlL.Width = panelControlR.Width = 0;
         
            //加载音柱
            initWaves();
        }
        /// <summary>
        /// 初始化音柱
        /// </summary>
        public void initWaves()
        {
            panelControlWave.Controls.Clear();
            panelControlWave.Width = iWaveNum * iWaveWidth;
            for (int i = iWaveNum - 1; i >= 0; i--)
            {
                myWaveBar.MyWaveBar cWaveBar = new myWaveBar.MyWaveBar();
                panelControlWave.Controls.Add(cWaveBar);
                cWaveBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                cWaveBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                cWaveBar.Dock = System.Windows.Forms.DockStyle.Left;
                cWaveBar.Location = new System.Drawing.Point(0, 0);
                cWaveBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                cWaveBar.Name = "cWaveBar" + i.ToString();
                cWaveBar.Size = new System.Drawing.Size(15, panelControlWave.Height);
                cWaveBar.TabIndex = 0;
                cWaveBar.Visible = false;
            }
        }

        /// <summary>
        /// 读取视频
        /// </summary>
        /// <param name="lsFilePath"></param>
        public void of_VideoLoad(string lsFilePath)
        {
            
            try
            {
                iboolisLoad = false;
                try
                {
                    string ffmpeg = Application.StartupPath + "\\" + "ffmpeg.exe";
                    Process p = new Process();

                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.FileName = ffmpeg;

                    p.StartInfo.CreateNoWindow = true;

                    p.StartInfo.Arguments = " -i \"" + lsFilePath + "\"";
                    p.Start();
                    string output = p.StandardError.ReadToEnd();

                    p.WaitForExit();

                    output = output.Substring(output.IndexOf("Video:"));
                    string[] strs = output.Split(',');
                    string wh = "", dar = "", fps = "";
                    foreach (string s in strs)
                    {
                        if (s.Contains("x") && s.Contains("[SAR") && wh == "")
                        {
                            wh = s;
                            wh = wh.Substring(0, wh.IndexOf("[SAR"));
                            wh = wh.Replace(" ", "");

                            if (s.Contains("DAR "))
                            {
                                dar = s;
                                dar = dar.Substring(dar.IndexOf("DAR ") + 4);
                                if (dar.Contains(" "))
                                {
                                    dar = dar.Substring(0, dar.IndexOf(" "));
                                }
                                if (dar.Contains("]"))
                                {
                                    dar = dar.Substring(0, dar.IndexOf("]"));
                                }
                            }
                            int darW = 0, darH = 0;
                            try
                            {
                                darW = Convert.ToInt32(dar.Substring(0, dar.IndexOf(":")));
                                darH = Convert.ToInt32(dar.Substring(dar.IndexOf(":") + 1));
                            }
                            catch
                            {
                                darW = 0;
                                darH = 0;
                            }
                            if (darH != 0 && darW != 0)
                            {
                                clipw = darW;
                                cliph = darH;
                            }
                            else
                            {
                                clipw = Convert.ToInt32(wh.Substring(0, wh.IndexOf("x")));
                                cliph = Convert.ToInt32(wh.Substring(wh.IndexOf("x") + 1));
                            }
                        }
                        if (s.Contains("fps") && fps == "")
                        {
                            fps = s;
                            fps = fps.Replace("fps", "");
                            fps = fps.Replace(" ", "");
                            iflFps = (float)Convert.ToDouble(fps);
                        }
                    }
                    //MessageBox.Show(wh + ";" + fps);
                }
                catch
                {
                    cliph = 1080; 
                    clipw = 1920;
                    iflFps = 25;
                }
                if(iflFps==0)
                    iflFps = 25;
              
                of_CtrSetPicShowSize(clipw, cliph);
                of_VideoLoadOther(lsFilePath);               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

        /// <summary>
        /// 读取视频
        /// </summary>
        /// <param name="lsFilePath"></param>
        public void of_VideoLoadOther(string lsFilePath)
        {
            try
            {
                iboolisLoad = false;
                currentWav = "";
                if (ipWav != IntPtr.Zero)
                {
                    ClassFFmpeg.ff_play_stop(ipWav);
                    ClassFFmpeg.ff_destory(ipWav);
                    ipWav = IntPtr.Zero;
                }
                if (ipMedia != IntPtr.Zero)
                {
                    ClassFFmpeg.ff_play_stop(ipMedia);
                    ClassFFmpeg.ff_destory(ipMedia);
                    ipMedia = IntPtr.Zero;
                }
                comboBoxEditRate.SelectedIndex = 1;
                ipMedia = ClassFFmpeg.ff_new();

                //设置播放器窗口
                int i_bool = initPicBoxSizePosition(pictureBoxShow.Width, pictureBoxShow.Height, pictureBoxShow.Location.X, pictureBoxShow.Location.Y);
                //int i_bool = initPicBoxSizePosition(panelControlVideo.Width, panelControlVideo.Height, 0, 0);
                if (i_bool != 0)
                {
                    MessageBox.Show("初始化播放器失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
              
                //打开文件开始播放
                currentFile = lsFilePath;
                i_bool = ClassFFmpeg.ff_open_file(ipMedia, lsFilePath);
                if (i_bool != 0)
                {
                    MessageBox.Show("加载视频视频", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //设置速率
                i_bool = ClassFFmpeg.ff_set_play_speed(ipMedia, of_GetRate());
                if (i_bool != 0)
                {
                    MessageBox.Show("切换播放倍速失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                iboolisPlay = true;
                iboolisStop = false;
                //更改图标
                this.simpleButtonPlayPause.ImageIndex = 1;
                //显示音量
                timerShowWavBar.Start();

                //开始显示
                timerShow.Start();
                //设置完成
                iboolisLoad = true;
              
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

        /// <summary>
        /// 读取视频音频
        /// </summary>
        /// <param name="lsFilePath"></param>
        public void of_VideoWave(string lsFilePath,string lsWave)
        {
            try
            {
                iboolisLoad = false;
                currentWav = "";
                if (ipWav != IntPtr.Zero)
                {
                    ClassFFmpeg.ff_play_stop(ipWav);
                    ClassFFmpeg.ff_destory(ipWav);
                    ipWav = IntPtr.Zero;
                }
                if (ipMedia != IntPtr.Zero)
                {
                    ClassFFmpeg.ff_play_stop(ipMedia);
                    ClassFFmpeg.ff_destory(ipMedia);
                    ipMedia = IntPtr.Zero;
                }
                comboBoxEditRate.SelectedIndex = 1;
                ipMedia = ClassFFmpeg.ff_new();
                ipWav = ClassFFmpeg.ff_new();

                //设置播放器窗口              
                //int i_bool = initPicBoxSizePosition(pictureBoxShow.Width, pictureBoxShow.Height, pictureBoxShow.Location.X, pictureBoxShow.Location.Y);
                int i_bool = initPicBoxSizePosition(panelControlVideo.Width, panelControlVideo.Height, 0, 0);
                if (i_bool != 0)
                {
                    if (i_bool == -1)
                        MessageBox.Show("初始化播放器失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (i_bool == -2)
                        MessageBox.Show("初始化音频失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                //打开文件开始播放
                currentFile = lsFilePath;
                currentWav = lsWave;
                i_bool = ClassFFmpeg.ff_open_file(ipMedia, lsFilePath);
                if (i_bool != 0)
                {
                    MessageBox.Show("加载视频失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                i_bool = ClassFFmpeg.ff_open_file(ipWav, lsWave);
                if (i_bool != 0)
                {
                    MessageBox.Show("加载音频失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //设置速率
                i_bool = ClassFFmpeg.ff_set_play_speed(ipMedia, of_GetRate());
                if (i_bool != 0)
                {
                    MessageBox.Show("切换播放倍速失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                i_bool = ClassFFmpeg.ff_set_play_speed(ipWav, of_GetRate());
                if (i_bool != 0)
                {
                    MessageBox.Show("切换播放倍速失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                iboolisPlay = true;
                iboolisStop = false;
                //更改图标
                this.simpleButtonPlayPause.ImageIndex = 1;
                //显示音量
                timerShowWavBar.Start();

                //开始显示
                timerShow.Start();
                //设置完成
                iboolisLoad = true;

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void of_VideoDispose()
        {
            try
            {
                if (iboolisLoad)
                {
                    currentWav = "";
                    if (ipWav != IntPtr.Zero)
                    {
                        ClassFFmpeg.ff_play_stop(ipWav);
                        ClassFFmpeg.ff_destory(ipWav);
                        ipWav = IntPtr.Zero;
                    }
                    if (ipMedia != IntPtr.Zero)
                    {
                        ClassFFmpeg.ff_play_stop(ipMedia);
                        ClassFFmpeg.ff_destory(ipMedia);
                        ipMedia = IntPtr.Zero;
                    }
                    timerShow.Stop();
                    timerShowWavBar.Stop();
                    ClassFFmpeg.ff_quit();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

       

        /// <summary>
        /// 进行定位
        /// </summary>
        /// <param name="ldTmc"></param>
        public void of_SetPosition(double ldTmc)
        {
            if (!iboolisLoad || ipMedia == IntPtr.Zero) return;         
            long llTmc = (long)(ldTmc * 1000);
            llTmc=(long)(llTmc/40);
            ClassFFmpeg.ff_seek_frame(ipMedia,llTmc);
            if (ipWav != IntPtr.Zero)
            {
                double s = (double)llTmc * (double)40 / (double)1000;
                ClassFFmpeg.ff_seek_time(ipWav, s);
            }
        }

        /// <summary>
        /// 设置开始时间
        /// </summary>
        /// <param name="llTm"></param>
        public void of_SetSS(long llTm)
        {
            if (iboolisLoad == false) return;
            if (ilTmD <= 0) return;
            this.ilTmSS = llTm;
            this.simpleButtonMarkIn.Text = of_CtrTimecodeBySec((double)llTm / (double)1000);
            this.mytrackbar1.of_SetSPosition((double)llTm / (double)ilTmD);
            
        }

        /// <summary>
        /// 设置选择结束时间
        /// </summary>
        /// <param name="llTm"></param>
        public void of_SetSE(long llTm)
        {
            if (iboolisLoad == false) return;
            if (ilTmD <= 0) return;
            this.ilTmSE = llTm;
            this.simpleButtonMarkOut.Text = of_CtrTimecodeBySec((double)llTm / (double)1000);
            this.mytrackbar1.of_SetEPosition((double)llTm / (double)ilTmD);
        }

        private void timerShowWavBar_Tick(object sender, EventArgs e)
        {
            try
            {
                timerShowWavBar.Interval = 50;
                if (!iboolisLoad || ipMedia == IntPtr.Zero) return;

                int Wave_num = 0;
                float[] Waves = new float[iWaveNum];
                if (ipWav == IntPtr.Zero)
                {
                    int ibool = ClassFFmpeg.ff_get_audio_volume(ipMedia, iWaveNum, ref Wave_num, Waves);
                    if (ibool == 0)
                    {
                        for (int i = 0; i < iWaveNum; i++)
                        {
                            myWaveBar.MyWaveBar cWaveBar = (myWaveBar.MyWaveBar)panelControlWave.Controls.Find("cWaveBar" + i.ToString(), false)[0];

                            if (i >= Wave_num)
                            {
                                cWaveBar.of_SetPosition(0);
                            }
                            else
                            {
                                //最大音量150，默认显示调低设为200最大
                                double wave = (double)Waves[i] / (double)200;
                                cWaveBar.of_SetPosition(wave);
                            }
                            cWaveBar.Visible = true;
                        }
                    }
                }
                else
                {
                    int ibool = ClassFFmpeg.ff_get_audio_volume(ipWav, iWaveNum, ref Wave_num, Waves);
                    if (ibool == 0)
                    {
                        for (int i = 0; i < iWaveNum; i++)
                        {
                            myWaveBar.MyWaveBar cWaveBar = (myWaveBar.MyWaveBar)panelControlWave.Controls.Find("cWaveBar" + i.ToString(), false)[0];

                            if (i >= Wave_num)
                            {
                                cWaveBar.of_SetPosition(0);
                            }
                            else
                            {
                                //最大音量150，默认显示调低设为200最大
                                double wave = (double)Waves[i] / (double)200;
                                cWaveBar.of_SetPosition(wave);
                            }
                            cWaveBar.Visible = true;
                        }
                    }
                }

              

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

        private void of_ClearWave()
        {
            for (int i = 0; i < iWaveNum; i++)
            {
                myWaveBar.MyWaveBar cWaveBar = (myWaveBar.MyWaveBar)panelControlWave.Controls.Find("cWaveBar" + i.ToString(), false)[0];
                cWaveBar.of_SetPosition(0);
                cWaveBar.Visible = true;
            }
        }
        /// <summary>
        /// 开始显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerShow_Tick(object sender, EventArgs e)
        {
            try
            {
                timerShow.Interval = 50;
                if (!iboolisLoad || ipMedia == IntPtr.Zero) return;         
                long ltmC = ClassFFmpeg.ff_get_current_frame_number(ipMedia) * 40; //当前时间(ms)
                long ltmD = (ClassFFmpeg.ff_get_total_frames_number(ipMedia)-1) * 40; //节目时间长度(ms)
               
                if (ltmD <= 0)
                    return;

                double P = (double)(ltmC) / (double)(ltmD);

                this.mytrackbar1.of_SetPosition(P);

                ilTmC = ltmC;
                ilTmD = ltmD;
                //获得帧率，在1秒后还获得不了帧率的就自动设置为25                
                //暂设帧率为25
                //iflFps = 25;
                //根据帧率进行数据显示
                if (iflFps != 0)
                {
                    this.labelControlCTm.Text = of_CtrTimecodeBySec((double)ilTmC / (double)1000);
                    this.isTmc = of_CtrTimecodeBySec((double)ilTmC / (double)1000);
                    this.labelControlDTm.Text = of_CtrTimecodeBySec((double)ilTmD / (double)1000);
                    this.isTmd = of_CtrTimecodeBySec((double)ilTmD / (double)1000);
                }
                //初始化显示出点就为时长
                if (this.simpleButtonMarkIn.Text == "00:00:00:00")
                {
                    this.simpleButtonMarkOut.Text = this.labelControlDTm.Text;
                    this.ilTmSE = this.ilTmD;
                }
                //已经播放到最后了就自动停止
                if (ilTmC > 0)
                {
                    if (ilTmC >= ilTmD)
                    {
                        ClassFFmpeg.ff_play_pause(ipMedia);
                       
                        //更改图标
                        this.simpleButtonPlayPause.ImageIndex = 0;
                        iboolisStop = false;
                    }
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message + ex.StackTrace); }
        }

        /// <summary>
        /// 移动
        /// </summary>
        private void cTrackBarMain_oeBarMouseMove()
        {
            if (!iboolisLoad || ipMedia == IntPtr.Zero) return;
            double p = this.mytrackbar1.of_GetPosition();
            double lCp = p * (double)ilTmD;
            long Cp_frame = (long)(lCp / 40);
            double s = (double)Cp_frame * (double)40 / (double)1000;
            timerShow.Stop();
            timerShowWavBar.Stop();
            ClassFFmpeg.ff_seek_frame(ipMedia, Cp_frame);
            //ClassFFmpeg.ff_seek_time(ipMedia, s);
            if (ipWav != IntPtr.Zero)
            {              
                ClassFFmpeg.ff_seek_time(ipWav, s);
            }
            //Thread.Sleep(100);
            timerShow.Interval = 800;
            timerShowWavBar.Interval = 800;
            timerShow.Start();
            timerShowWavBar.Start();
            //ClassFFmpeg.ff_seek_time(ipMedia, 20); 
        }

        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonPlayPause_Click(object sender, EventArgs e)
        {
            if (iboolisLoad == false) return;
            if (iboolisStop)
            {
                if (currentWav == "")
                    of_VideoLoadOther(currentFile);
                else
                    of_VideoWave(currentFile, currentWav);
                iboolisStop = false;
                iboolisPlay = true;
                //更改图标
                this.simpleButtonPlayPause.ImageIndex = 1;
            }
            else
            {
                ClassFFmpeg.ff_play_pause(ipMedia);
                if (ipWav != IntPtr.Zero)
                {
                    ClassFFmpeg.ff_play_pause(ipWav);
                }
                //设置速率              
                int i_bool = ClassFFmpeg.ff_set_play_speed(ipMedia, of_GetRate());
                if (i_bool != 0)
                {
                    MessageBox.Show("切换播放倍速失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (ipWav != IntPtr.Zero)
                {
                    i_bool = ClassFFmpeg.ff_set_play_speed(ipWav, of_GetRate());
                    if (i_bool != 0)
                    {
                        MessageBox.Show("切换播放倍速失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (iboolisPlay)
                {
                    timerShowWavBar.Start();
                    //更改图标
                    this.simpleButtonPlayPause.ImageIndex = 0;
                    iboolisPlay = false;
                    return;
                }
                if (!iboolisPlay)
                {

                    //更改图标
                    this.simpleButtonPlayPause.ImageIndex = 1;
                    iboolisPlay = true;
                    return;
                }

            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonStop_Click(object sender, EventArgs e)
        {
            if (iboolisLoad == false) return;
            timerShowWavBar.Stop();
            of_ClearWave();
            if (ipWav != IntPtr.Zero)
            {
                ClassFFmpeg.ff_play_stop(ipWav);
                ClassFFmpeg.ff_destory(ipWav);
                ipWav = IntPtr.Zero;
            }
            ClassFFmpeg.ff_play_stop(ipMedia);
            ClassFFmpeg.ff_destory(ipMedia);
            ipMedia = IntPtr.Zero;
           
            //pictureBoxShow.Refresh();
            
            iboolisStop = true;           
            //更改图标
            this.simpleButtonPlayPause.ImageIndex = 0;
            iboolisPlay = false;
        }

        /// <summary>
        /// Mark in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonMarkIn_Click(object sender, EventArgs e)
        {
            if (iboolisLoad == false) return;
            if (ilTmD <= 0) return;
            this.ilTmSS = this.ilTmC;
            this.simpleButtonMarkIn.Text = of_CtrTimecodeBySec((double)ilTmC / (double)1000);
            this.mytrackbar1.of_SetSPosition((double)ilTmC / (double)ilTmD);
        }

        /// <summary>
        /// Mark Out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonMarkOut_Click(object sender, EventArgs e)
        {
            if (iboolisLoad == false) return;
            if (ilTmD <= 0) return;
            this.ilTmSE = this.ilTmC;
            this.simpleButtonMarkOut.Text = of_CtrTimecodeBySec((double)ilTmC / (double)1000);
            this.mytrackbar1.of_SetEPosition((double)ilTmC / (double)ilTmD);
        }

        /// <summary>
        /// Capture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonCapture_Click(object sender, EventArgs e)
        {
            if (iboolisLoad == false) return;
            if (iboolisStop) return;
            if (ilTmD <= 0) return;
            string lsTp = isTempDir + "\\FFmpeg.jpg";
            int i_bool = ClassFFmpeg.ff_save_image(ipMedia, lsTp);
            if (i_bool != 0)
            {
                MessageBox.Show("截帧失败，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //传递数据到外部
            if (OncMediaPlayCaptureRemark!=null)
                OncMediaPlayCaptureRemark(ilTmC, lsTp, "");
        }

       
        private void comboBoxEditRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iboolisLoad == false) return;
            if (iboolisStop) return;
            int i_bool= ClassFFmpeg.ff_set_play_speed(ipMedia,of_GetRate());
            if (i_bool != 0)
            {
                MessageBox.Show("切换播放倍速失败","错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            if (ipWav != IntPtr.Zero)
            {
                i_bool = ClassFFmpeg.ff_set_play_speed(ipWav, of_GetRate());
                if (i_bool != 0)
                {
                    MessageBox.Show("切换播放倍速失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        /// <summary>
        /// 设置播放显示区域
        /// </summary>
        /// <param name="picboxW"></param>
        /// <param name="picboxH"></param>
        /// <param name="picboxX"></param>
        /// <param name="picboxY"></param>
        private void setPicBoxSizePosition(int picboxW, int picboxH, int picboxX, int picboxY)
        {
            try
            {
                picboxW = panelControlVideo.Width - panelControlL.Width - panelControlR.Width;
                picboxH = panelControlVideo.Height - panelControlT.Height - panelControlB.Height;
                if (!iboolisLoad || ipMedia == IntPtr.Zero) return;
                //设置显示区域宽度为偶数，防止显示问题
                if (picboxW % 2 == 1)
                    picboxW -= 1;

                //是否显示
                if (picboxW <= 0 || picboxH <= 0)
                {
                    pictureBoxShow.Visible = false;
                    pictureBoxShow.Refresh();
                }
                else
                {
                    if (pictureBoxShow.Visible == false)
                    {
                        pictureBoxShow.Visible = true;
                        pictureBoxShow.Refresh();
                    }       
                    Rectangle r = pictureBoxShow.RectangleToScreen(new Rectangle(new Point(picboxX, picboxY), new Size(picboxW, picboxH)));
                    panelControlL.Refresh(); panelControlL.Refresh(); panelControlR.Refresh(); panelControlT.Refresh();
                    ClassFFmpeg.ff_video_resize(ipMedia, r.Right, r.Left, r.Top, r.Bottom);                   
                }
            }
            catch
            { 
            }
        }

        private int initPicBoxSizePosition(int picboxW, int picboxH, int picboxX, int picboxY)
        {
            try
            {
                //设置显示区域宽度为偶数，防止显示问题
                if (picboxW % 2 == 1)
                    picboxW -= 1;

                //是否显示
                if (picboxW <= 0 || picboxH <= 0)
                {
                    pictureBoxShow.Visible = false;
                    pictureBoxShow.Refresh();
                }
                else
                {
                    if (pictureBoxShow.Visible == false)
                    {
                        pictureBoxShow.Visible = true;
                        pictureBoxShow.Refresh();
                    }
                    Rectangle r = pictureBoxShow.RectangleToScreen(new Rectangle(new Point(picboxX, picboxY), new Size(picboxW, picboxH)));
                    if (ipWav != IntPtr.Zero)
                    {
                        int i_bool = ClassFFmpeg.ff_init(ipMedia, this.pictureBoxShow.Handle, r.Right, r.Left, r.Top, r.Bottom, 1);
                        if (i_bool != 0)
                        {
                            return -1;
                        }

                        i_bool = ClassFFmpeg.ff_init(ipWav, IntPtr.Zero, 0, 0, 0, 0, 2);
                        if (i_bool != 0)
                        {
                            return -2;
                        }
                    }
                    else
                    {
                        int i_bool = ClassFFmpeg.ff_init(ipMedia, this.pictureBoxShow.Handle, r.Right, r.Left, r.Top, r.Bottom, 0);
                        if (i_bool != 0)
                        {
                            return -1;
                        }
                    }
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }
              
        private void panelControlVideo_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxShow.Visible = false;
            of_CtrSetPicShowSize(clipw, cliph);
            pictureBoxShow.Refresh();
            panelControlVideo.Refresh();
            pictureBoxShow.Visible = true;
        }



        #region 帧数转换

        /// <summary>
        /// 帧数转换为 时间格式帧结尾的字符串
        /// </summary>
        /// <param name="frameNum"></param>
        /// <returns></returns>
        private string FrameToTimeString(int frameNum)
        {

            int frameAtStringEnd = frameNum % 25; // 取时间格式 00：00：00：00的最后两位帧数
            string timeLength = TimeSpan.FromSeconds(frameNum / 25).ToString();
            timeLength = timeLength + ":" + frameAtStringEnd.ToString("00");
            return timeLength;
        }
        /// <summary>
        /// 将标准时间格式转化为帧数
        /// </summary>
        /// <param name="time">表示时间的字符串</param>
        /// <returns></returns>
        public int ConvertFrame(string time)
        {
            if (time.Split(':')[0] == "  ")
            {
                time = "00:" + time.Split(':')[1] + ":" + time.Split(':')[2] + ":" + time.Split(':')[3];
            }
            if (time.Split(':')[1] == "  ")
            {
                time = time.Split(':')[0] + ":00:" + time.Split(':')[2] + ":" + time.Split(':')[3];
            }
            if (time.Split(':')[2] == "  ")
            {
                time = time.Split(':')[0] + ":" + time.Split(':')[1] + ":00:" + time.Split(':')[3];
            }
            if (time.Split(':')[3] == "")
            {
                time = time.Split(':')[0] + ":" + time.Split(':')[1] + ":" + time.Split(':')[2] + ":00";
            }
            if (time == "  :  :  :")
            {
                return 0;
            }
            int time_h = Convert.ToInt32(time.Split(':')[0]) * 3600 * 25;
            int time_m = Convert.ToInt32(time.Split(':')[1]) * 60 * 25;
            int time_s = Convert.ToInt32(time.Split(':')[2]) * 25;
            int time_f = Convert.ToInt32(time.Split(':')[3]);
            int time_all = time_h + time_m + time_s + time_f;
            return time_all;
        }


        public double ConvertSecByFrame(long lframe)
        {
            double sec = lframe * 40f / 1000f;
            return sec;
        }

        /// <summary>
        /// 根据输入秒数换算显示为时间码
        /// </summary>
        /// <param name="llFrame"></param>
        /// <returns></returns>
        public string of_CtrTimecodeBySec(double ldSec)
        {
            try
            {
                if (ldSec <= 0)
                { return "00:00:00:00"; }

                long llYs = 0;
                string lsH = "";
                string lsM = "";
                string lsS = "";
                string lsF = "";
                double ldDf = ldSec * iflFps;
                long llFrame = (long)(Math.Ceiling(ldDf));
                double lFramePerSec = Math.Ceiling(iflFps);
                long D = System.Math.DivRem(llFrame, (long)(3600 * lFramePerSec * 24), out llYs);
                if (D > 0)
                {
                    MessageBox.Show("你输入的时间大于1天，请更换节目！", "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "00:00:00:00";
                }

                long H = System.Math.DivRem(llFrame, (long)(3600 * lFramePerSec), out llYs);
                if (H > 0)
                {
                    long llH = (100 + H);
                    lsH = llH.ToString().Substring(1, 2);
                }
                else { lsH = "00"; }

                long M = System.Math.DivRem(llYs, (long)(60 * lFramePerSec), out llYs);
                if (M > 0)
                {
                    long llM = (100 + M);
                    lsM = llM.ToString().Substring(1, 2);
                }
                else { lsM = "00"; }

                long S = System.Math.DivRem(llYs, (long)(lFramePerSec), out llYs);
                if (S > 0)
                {
                    long llS = (100 + S);
                    lsS = llS.ToString().Substring(1, 2);
                }
                else { lsS = "00"; }

                llYs = 100 + llYs;
                lsF = llYs.ToString().Substring(1, 2);

                return lsH + ":" + lsM + ":" + lsS + ":" + lsF;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + ee.StackTrace);
            }
            return "00:00:00:00";
        }

        #endregion

        private void panelControlWave_SizeChanged(object sender, EventArgs e)
        {

            //setPicBoxSizePosition(panelControlVideo.Width, panelControlVideo.Height, 0, 0);
           
        }

        private void pictureBoxShow_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBoxShow.Width + panelControlL.Width + panelControlR.Width + 5 < panelControlVideo.Width)
            {
                int picboxW = panelControlVideo.Width - panelControlL.Width - panelControlR.Width;
                int picboxH = panelControlVideo.Height - panelControlT.Height - panelControlB.Height;
                pictureBoxShow.Size = new Size(picboxW, picboxH);                
            }
            setPicBoxSizePosition(pictureBoxShow.Width, pictureBoxShow.Height, pictureBoxShow.Location.X, pictureBoxShow.Location.Y);
          
         
        }

       

    }
}
