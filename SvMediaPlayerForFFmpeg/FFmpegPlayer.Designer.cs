namespace MediaPlayerForFFmpeg
{
    partial class FFmpegPlayer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFmpegPlayer));
            this.panelControlCtr = new DevExpress.XtraEditors.PanelControl();
            this.labelControlCTm = new DevExpress.XtraEditors.LabelControl();
            this.labelControlDTm = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditRate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonCapture = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMarkOut = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMarkIn = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonStop = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonPlayPause = new DevExpress.XtraEditors.SimpleButton();
            this.imageListBtnIcon = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxShow = new System.Windows.Forms.PictureBox();
            this.timerShow = new System.Windows.Forms.Timer(this.components);
            this.mytrackbar1 = new mytrackbar.mytrackbar();
            this.panelControlWave = new DevExpress.XtraEditors.PanelControl();
            this.panelControlVideo = new DevExpress.XtraEditors.PanelControl();
            this.panelControlB = new DevExpress.XtraEditors.PanelControl();
            this.panelControlT = new DevExpress.XtraEditors.PanelControl();
            this.panelControlR = new DevExpress.XtraEditors.PanelControl();
            this.panelControlL = new DevExpress.XtraEditors.PanelControl();
            this.timerShowWavBar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCtr)).BeginInit();
            this.panelControlCtr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlVideo)).BeginInit();
            this.panelControlVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlL)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlCtr
            // 
            this.panelControlCtr.Controls.Add(this.labelControlCTm);
            this.panelControlCtr.Controls.Add(this.labelControlDTm);
            this.panelControlCtr.Controls.Add(this.comboBoxEditRate);
            this.panelControlCtr.Controls.Add(this.simpleButtonCapture);
            this.panelControlCtr.Controls.Add(this.simpleButtonMarkOut);
            this.panelControlCtr.Controls.Add(this.simpleButtonMarkIn);
            this.panelControlCtr.Controls.Add(this.simpleButtonStop);
            this.panelControlCtr.Controls.Add(this.simpleButtonPlayPause);
            this.panelControlCtr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControlCtr.Location = new System.Drawing.Point(0, 382);
            this.panelControlCtr.Name = "panelControlCtr";
            this.panelControlCtr.Size = new System.Drawing.Size(666, 34);
            this.panelControlCtr.TabIndex = 0;
            // 
            // labelControlCTm
            // 
            this.labelControlCTm.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControlCTm.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControlCTm.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlCTm.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlCTm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControlCTm.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControlCTm.LineVisible = true;
            this.labelControlCTm.Location = new System.Drawing.Point(444, 2);
            this.labelControlCTm.Name = "labelControlCTm";
            this.labelControlCTm.Size = new System.Drawing.Size(110, 30);
            this.labelControlCTm.TabIndex = 13;
            this.labelControlCTm.Text = "00:00:00:00";
            // 
            // labelControlDTm
            // 
            this.labelControlDTm.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControlDTm.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControlDTm.Appearance.ForeColor = System.Drawing.Color.Olive;
            this.labelControlDTm.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlDTm.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlDTm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControlDTm.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControlDTm.LineVisible = true;
            this.labelControlDTm.Location = new System.Drawing.Point(554, 2);
            this.labelControlDTm.Name = "labelControlDTm";
            this.labelControlDTm.Size = new System.Drawing.Size(110, 30);
            this.labelControlDTm.TabIndex = 14;
            this.labelControlDTm.Text = "00:00:00:00";
            // 
            // comboBoxEditRate
            // 
            this.comboBoxEditRate.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBoxEditRate.EditValue = "1倍速";
            this.comboBoxEditRate.Location = new System.Drawing.Point(318, 2);
            this.comboBoxEditRate.Name = "comboBoxEditRate";
            this.comboBoxEditRate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEditRate.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEditRate.Properties.AutoHeight = false;
            this.comboBoxEditRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditRate.Properties.Items.AddRange(new object[] {
            "1.5倍速",
            "1倍速",
            "2倍速",
            "3倍速",
            "4倍速",
            "5倍速"});
            this.comboBoxEditRate.Properties.Sorted = true;
            this.comboBoxEditRate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBoxEditRate.Size = new System.Drawing.Size(54, 30);
            this.comboBoxEditRate.TabIndex = 15;
            this.comboBoxEditRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditRate_SelectedIndexChanged);
            // 
            // simpleButtonCapture
            // 
            this.simpleButtonCapture.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonCapture.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonCapture.Image")));
            this.simpleButtonCapture.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonCapture.Location = new System.Drawing.Point(283, 2);
            this.simpleButtonCapture.Name = "simpleButtonCapture";
            this.simpleButtonCapture.Size = new System.Drawing.Size(35, 30);
            this.simpleButtonCapture.TabIndex = 4;
            this.simpleButtonCapture.Click += new System.EventHandler(this.simpleButtonCapture_Click);
            // 
            // simpleButtonMarkOut
            // 
            this.simpleButtonMarkOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonMarkOut.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMarkOut.Image")));
            this.simpleButtonMarkOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.simpleButtonMarkOut.Location = new System.Drawing.Point(179, 2);
            this.simpleButtonMarkOut.Name = "simpleButtonMarkOut";
            this.simpleButtonMarkOut.Size = new System.Drawing.Size(104, 30);
            this.simpleButtonMarkOut.TabIndex = 3;
            this.simpleButtonMarkOut.Text = "00:00:00:00";
            this.simpleButtonMarkOut.Click += new System.EventHandler(this.simpleButtonMarkOut_Click);
            // 
            // simpleButtonMarkIn
            // 
            this.simpleButtonMarkIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonMarkIn.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMarkIn.Image")));
            this.simpleButtonMarkIn.Location = new System.Drawing.Point(69, 2);
            this.simpleButtonMarkIn.Name = "simpleButtonMarkIn";
            this.simpleButtonMarkIn.Size = new System.Drawing.Size(110, 30);
            this.simpleButtonMarkIn.TabIndex = 2;
            this.simpleButtonMarkIn.Text = "00:00:00:00";
            this.simpleButtonMarkIn.Click += new System.EventHandler(this.simpleButtonMarkIn_Click);
            // 
            // simpleButtonStop
            // 
            this.simpleButtonStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonStop.Image")));
            this.simpleButtonStop.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonStop.Location = new System.Drawing.Point(37, 2);
            this.simpleButtonStop.Name = "simpleButtonStop";
            this.simpleButtonStop.Size = new System.Drawing.Size(32, 30);
            this.simpleButtonStop.TabIndex = 1;
            this.simpleButtonStop.Click += new System.EventHandler(this.simpleButtonStop_Click);
            // 
            // simpleButtonPlayPause
            // 
            this.simpleButtonPlayPause.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonPlayPause.ImageIndex = 0;
            this.simpleButtonPlayPause.ImageList = this.imageListBtnIcon;
            this.simpleButtonPlayPause.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonPlayPause.Location = new System.Drawing.Point(2, 2);
            this.simpleButtonPlayPause.Name = "simpleButtonPlayPause";
            this.simpleButtonPlayPause.Size = new System.Drawing.Size(35, 30);
            this.simpleButtonPlayPause.TabIndex = 0;
            this.simpleButtonPlayPause.Click += new System.EventHandler(this.simpleButtonPlayPause_Click);
            // 
            // imageListBtnIcon
            // 
            this.imageListBtnIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBtnIcon.ImageStream")));
            this.imageListBtnIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBtnIcon.Images.SetKeyName(0, "Play24.png");
            this.imageListBtnIcon.Images.SetKeyName(1, "Pause24.png");
            // 
            // pictureBoxShow
            // 
            this.pictureBoxShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxShow.Location = new System.Drawing.Point(17, 37);
            this.pictureBoxShow.Name = "pictureBoxShow";
            this.pictureBoxShow.Size = new System.Drawing.Size(632, 308);
            this.pictureBoxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxShow.TabIndex = 2;
            this.pictureBoxShow.TabStop = false;
            this.pictureBoxShow.SizeChanged += new System.EventHandler(this.pictureBoxShow_SizeChanged);
            // 
            // timerShow
            // 
            this.timerShow.Interval = 50;
            this.timerShow.Tick += new System.EventHandler(this.timerShow_Tick);
            // 
            // mytrackbar1
            // 
            this.mytrackbar1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mytrackbar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mytrackbar1.Location = new System.Drawing.Point(0, 361);
            this.mytrackbar1.Name = "mytrackbar1";
            this.mytrackbar1.Size = new System.Drawing.Size(666, 21);
            this.mytrackbar1.TabIndex = 5;
            this.mytrackbar1.oeBarMouseMove += new mytrackbar.CBarMouseMove(this.cTrackBarMain_oeBarMouseMove);
            // 
            // panelControlWave
            // 
            this.panelControlWave.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlWave.Location = new System.Drawing.Point(0, 0);
            this.panelControlWave.Name = "panelControlWave";
            this.panelControlWave.Size = new System.Drawing.Size(28, 361);
            this.panelControlWave.TabIndex = 4;
            this.panelControlWave.SizeChanged += new System.EventHandler(this.panelControlWave_SizeChanged);
            // 
            // panelControlVideo
            // 
            this.panelControlVideo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControlVideo.Appearance.Options.UseBackColor = true;
            this.panelControlVideo.Controls.Add(this.pictureBoxShow);
            this.panelControlVideo.Controls.Add(this.panelControlB);
            this.panelControlVideo.Controls.Add(this.panelControlT);
            this.panelControlVideo.Controls.Add(this.panelControlR);
            this.panelControlVideo.Controls.Add(this.panelControlL);
            this.panelControlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlVideo.Location = new System.Drawing.Point(0, 0);
            this.panelControlVideo.Margin = new System.Windows.Forms.Padding(2);
            this.panelControlVideo.Name = "panelControlVideo";
            this.panelControlVideo.Size = new System.Drawing.Size(666, 382);
            this.panelControlVideo.TabIndex = 3;
            this.panelControlVideo.SizeChanged += new System.EventHandler(this.panelControlVideo_SizeChanged);
            // 
            // panelControlB
            // 
            this.panelControlB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControlB.Location = new System.Drawing.Point(17, 345);
            this.panelControlB.Margin = new System.Windows.Forms.Padding(2);
            this.panelControlB.Name = "panelControlB";
            this.panelControlB.Size = new System.Drawing.Size(632, 35);
            this.panelControlB.TabIndex = 8;
            // 
            // panelControlT
            // 
            this.panelControlT.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControlT.Appearance.Options.UseBackColor = true;
            this.panelControlT.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlT.Location = new System.Drawing.Point(17, 2);
            this.panelControlT.Margin = new System.Windows.Forms.Padding(2);
            this.panelControlT.Name = "panelControlT";
            this.panelControlT.Size = new System.Drawing.Size(632, 35);
            this.panelControlT.TabIndex = 6;
            // 
            // panelControlR
            // 
            this.panelControlR.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControlR.Appearance.Options.UseBackColor = true;
            this.panelControlR.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControlR.Location = new System.Drawing.Point(649, 2);
            this.panelControlR.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.panelControlR.Margin = new System.Windows.Forms.Padding(2);
            this.panelControlR.Name = "panelControlR";
            this.panelControlR.Size = new System.Drawing.Size(15, 378);
            this.panelControlR.TabIndex = 5;
            // 
            // panelControlL
            // 
            this.panelControlL.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControlL.Appearance.Options.UseBackColor = true;
            this.panelControlL.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlL.Location = new System.Drawing.Point(2, 2);
            this.panelControlL.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.panelControlL.Margin = new System.Windows.Forms.Padding(2);
            this.panelControlL.Name = "panelControlL";
            this.panelControlL.Size = new System.Drawing.Size(15, 378);
            this.panelControlL.TabIndex = 3;
            // 
            // timerShowWavBar
            // 
            this.timerShowWavBar.Interval = 50;
            this.timerShowWavBar.Tick += new System.EventHandler(this.timerShowWavBar_Tick);
            // 
            // FFmpegPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.panelControlWave);
            this.Controls.Add(this.mytrackbar1);
            this.Controls.Add(this.panelControlVideo);
            this.Controls.Add(this.panelControlCtr);
            this.Name = "FFmpegPlayer";
            this.Size = new System.Drawing.Size(666, 416);
            this.Load += new System.EventHandler(this.FFmpegPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCtr)).EndInit();
            this.panelControlCtr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlVideo)).EndInit();
            this.panelControlVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlCtr;
        private DevExpress.XtraEditors.SimpleButton simpleButtonStop;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPlayPause;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCapture;
        private DevExpress.XtraEditors.LabelControl labelControlCTm;
        private DevExpress.XtraEditors.LabelControl labelControlDTm;
        private System.Windows.Forms.PictureBox pictureBoxShow;
        private System.Windows.Forms.ImageList imageListBtnIcon;
        private System.Windows.Forms.Timer timerShow;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditRate;
        private DevExpress.XtraEditors.PanelControl panelControlVideo;
        private System.Windows.Forms.Timer timerShowWavBar;
        public DevExpress.XtraEditors.SimpleButton simpleButtonMarkOut;
        public DevExpress.XtraEditors.SimpleButton simpleButtonMarkIn;
        private DevExpress.XtraEditors.PanelControl panelControlL;
        private DevExpress.XtraEditors.PanelControl panelControlR;
        private DevExpress.XtraEditors.PanelControl panelControlB;
        private DevExpress.XtraEditors.PanelControl panelControlT;
        private mytrackbar.mytrackbar mytrackbar1;
        private DevExpress.XtraEditors.PanelControl panelControlWave;
    }
}
