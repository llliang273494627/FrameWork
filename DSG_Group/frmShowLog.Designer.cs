
namespace DSG_Group
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
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.bntShowLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(61, 54);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(200, 21);
            this.dateTime.TabIndex = 0;
            // 
            // bntShowLog
            // 
            this.bntShowLog.Location = new System.Drawing.Point(300, 54);
            this.bntShowLog.Name = "bntShowLog";
            this.bntShowLog.Size = new System.Drawing.Size(75, 23);
            this.bntShowLog.TabIndex = 1;
            this.bntShowLog.Text = "查看日志";
            this.bntShowLog.UseVisualStyleBackColor = true;
            this.bntShowLog.Click += new System.EventHandler(this.bntShowLog_Click);
            // 
            // frmShowLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 314);
            this.Controls.Add(this.bntShowLog);
            this.Controls.Add(this.dateTime);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowLog";
            this.Text = "查看日志";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Button bntShowLog;
    }
}