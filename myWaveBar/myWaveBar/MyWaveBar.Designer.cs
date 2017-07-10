namespace myWaveBar
{
    partial class MyWaveBar
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
            this.panelBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.Lime;
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBar.Location = new System.Drawing.Point(0, 101);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(6, 100);
            this.panelBar.TabIndex = 1;
            this.panelBar.Tag = "0";
            // 
            // MyWaveBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelBar);
            this.Name = "MyWaveBar";
            this.Size = new System.Drawing.Size(6, 201);
            this.Load += new System.EventHandler(this.MyWaveBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBar;
    }
}
