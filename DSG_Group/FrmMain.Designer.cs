
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
            this.bntSystemSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bntSystemClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntSystemSetting
            // 
            this.bntSystemSetting.BackColor = System.Drawing.Color.Transparent;
            this.bntSystemSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntSystemSetting.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntSystemSetting.ForeColor = System.Drawing.Color.Transparent;
            this.bntSystemSetting.Location = new System.Drawing.Point(584, 7);
            this.bntSystemSetting.Name = "bntSystemSetting";
            this.bntSystemSetting.Size = new System.Drawing.Size(75, 28);
            this.bntSystemSetting.TabIndex = 1;
            this.bntSystemSetting.Text = "系统配置";
            this.bntSystemSetting.UseVisualStyleBackColor = false;
            this.bntSystemSetting.Click += new System.EventHandler(this.bntSystemSetting_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "胎压初始化系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(233, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "历史查询";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(350, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "日志查询";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(467, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "数据导出";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // bntSystemClear
            // 
            this.bntSystemClear.BackColor = System.Drawing.Color.Transparent;
            this.bntSystemClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntSystemClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntSystemClear.ForeColor = System.Drawing.Color.Transparent;
            this.bntSystemClear.Location = new System.Drawing.Point(701, 7);
            this.bntSystemClear.Name = "bntSystemClear";
            this.bntSystemClear.Size = new System.Drawing.Size(75, 28);
            this.bntSystemClear.TabIndex = 6;
            this.bntSystemClear.Text = "系统复位";
            this.bntSystemClear.UseVisualStyleBackColor = false;
            this.bntSystemClear.Click += new System.EventHandler(this.bntSystemClear_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1009, 711);
            this.Controls.Add(this.bntSystemClear);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntSystemSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.Text = "东风乘用车  胎压检测初始化系统";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntSystemSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bntSystemClear;
    }
}