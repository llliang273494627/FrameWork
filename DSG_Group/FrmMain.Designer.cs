
namespace DSG_Group
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tosMenu = new System.Windows.Forms.ToolStrip();
            this.tslabSystemState = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tsbntSystemSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.tosMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tosMenu
            // 
            this.tosMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslabSystemState,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.tsbntSystemSetting,
            this.toolStripButton5});
            this.tosMenu.Location = new System.Drawing.Point(0, 0);
            this.tosMenu.Name = "tosMenu";
            this.tosMenu.Size = new System.Drawing.Size(712, 25);
            this.tosMenu.TabIndex = 0;
            this.tosMenu.Text = "toolStrip1";
            // 
            // tslabSystemState
            // 
            this.tslabSystemState.Name = "tslabSystemState";
            this.tslabSystemState.Size = new System.Drawing.Size(92, 22);
            this.tslabSystemState.Text = "胎压初始化系统";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton1.Text = "历史查询";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton2.Text = "日志查询";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton3.Text = "数据导出";
            // 
            // tsbntSystemSetting
            // 
            this.tsbntSystemSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbntSystemSetting.Image")));
            this.tsbntSystemSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbntSystemSetting.Name = "tsbntSystemSetting";
            this.tsbntSystemSetting.Size = new System.Drawing.Size(76, 22);
            this.tsbntSystemSetting.Text = "系统配置";
            this.tsbntSystemSetting.Click += new System.EventHandler(this.tsbntSystemSetting_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton5.Text = "系统复位";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(712, 511);
            this.Controls.Add(this.tosMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "东风乘用车  胎压检测初始化系统";
            this.tosMenu.ResumeLayout(false);
            this.tosMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tosMenu;
        private System.Windows.Forms.ToolStripLabel tslabSystemState;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton tsbntSystemSetting;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}