namespace mytrackbar
{
    partial class mytrackbar
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
            this.pictureBoxPin = new System.Windows.Forms.PictureBox();
            this.labelEnd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxETD = new System.Windows.Forms.PictureBox();
            this.pictureBoxSTD = new System.Windows.Forms.PictureBox();
            this.panelOSS = new System.Windows.Forms.Panel();
            this.panelOSE = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxETD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSTD)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPin
            // 
            this.pictureBoxPin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxPin.BackColor = System.Drawing.Color.Yellow;
            this.pictureBoxPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPin.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pictureBoxPin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxPin.Location = new System.Drawing.Point(8, -10);
            this.pictureBoxPin.Name = "pictureBoxPin";
            this.pictureBoxPin.Size = new System.Drawing.Size(5, 87);
            this.pictureBoxPin.TabIndex = 35;
            this.pictureBoxPin.TabStop = false;
            this.pictureBoxPin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPin_MouseMove);
            // 
            // labelEnd
            // 
            this.labelEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEnd.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEnd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelEnd.Location = new System.Drawing.Point(500, -10);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(5, 87);
            this.labelEnd.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(-10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(537, 1);
            this.label3.TabIndex = 34;
            this.label3.Tag = "0";
            this.label3.Text = "label3";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 1);
            this.label1.TabIndex = 27;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlText;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(505, 1);
            this.label2.TabIndex = 19;
            this.label2.Text = "label2";
            // 
            // pictureBoxETD
            // 
            this.pictureBoxETD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxETD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxETD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxETD.Location = new System.Drawing.Point(100, 0);
            this.pictureBoxETD.Name = "pictureBoxETD";
            this.pictureBoxETD.Size = new System.Drawing.Size(95, 41);
            this.pictureBoxETD.TabIndex = 39;
            this.pictureBoxETD.TabStop = false;
            this.pictureBoxETD.Tag = "0";
            this.pictureBoxETD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxETD_MouseClick);
            // 
            // pictureBoxSTD
            // 
            this.pictureBoxSTD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxSTD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxSTD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxSTD.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSTD.Name = "pictureBoxSTD";
            this.pictureBoxSTD.Size = new System.Drawing.Size(100, 41);
            this.pictureBoxSTD.TabIndex = 40;
            this.pictureBoxSTD.TabStop = false;
            this.pictureBoxSTD.Tag = "0";
            this.pictureBoxSTD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSTD_MouseClick);
            // 
            // panelOSS
            // 
            this.panelOSS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOSS.BackColor = System.Drawing.Color.Black;
            this.panelOSS.Location = new System.Drawing.Point(0, 40);
            this.panelOSS.Name = "panelOSS";
            this.panelOSS.Size = new System.Drawing.Size(85, 12);
            this.panelOSS.TabIndex = 32;
            this.panelOSS.Tag = "0";
            // 
            // panelOSE
            // 
            this.panelOSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOSE.BackColor = System.Drawing.Color.Black;
            this.panelOSE.Location = new System.Drawing.Point(417, 40);
            this.panelOSE.Name = "panelOSE";
            this.panelOSE.Size = new System.Drawing.Size(85, 12);
            this.panelOSE.TabIndex = 33;
            this.panelOSE.Tag = "0";
            // 
            // mytrackbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.pictureBoxPin);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxETD);
            this.Controls.Add(this.pictureBoxSTD);
            this.Controls.Add(this.panelOSS);
            this.Controls.Add(this.panelOSE);
            this.Name = "mytrackbar";
            this.Size = new System.Drawing.Size(505, 52);
            this.Load += new System.EventHandler(this.mytrackbar_Load);
            this.SizeChanged += new System.EventHandler(this.mytrackbar_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mytrackbar_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxETD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPin;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxETD;
        private System.Windows.Forms.PictureBox pictureBoxSTD;
        private System.Windows.Forms.Panel panelOSS;
        private System.Windows.Forms.Panel panelOSE;





    }
}
