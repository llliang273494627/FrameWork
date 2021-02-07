
namespace DSGTest.Common.Frms
{
    partial class frmShowLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowLog));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.bntLockLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // bntLockLog
            // 
            this.bntLockLog.Location = new System.Drawing.Point(273, 34);
            this.bntLockLog.Name = "bntLockLog";
            this.bntLockLog.Size = new System.Drawing.Size(75, 23);
            this.bntLockLog.TabIndex = 1;
            this.bntLockLog.Text = "查看日志";
            this.bntLockLog.UseVisualStyleBackColor = true;
            this.bntLockLog.Click += new System.EventHandler(this.bntLockLog_Click);
            // 
            // frmShowLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 221);
            this.Controls.Add(this.bntLockLog);
            this.Controls.Add(this.monthCalendar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowLog";
            this.Text = "日志查询";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button bntLockLog;
    }
}