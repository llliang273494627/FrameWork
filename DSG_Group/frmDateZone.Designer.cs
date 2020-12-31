
namespace DSG_Group
{
    partial class frmDateZone
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpLow = new System.Windows.Forms.DateTimePicker();
            this.dtpHigh = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSaveAs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间：";
            // 
            // dtpLow
            // 
            this.dtpLow.Location = new System.Drawing.Point(130, 46);
            this.dtpLow.Name = "dtpLow";
            this.dtpLow.Size = new System.Drawing.Size(200, 21);
            this.dtpLow.TabIndex = 1;
            // 
            // dtpHigh
            // 
            this.dtpHigh.Location = new System.Drawing.Point(130, 105);
            this.dtpHigh.Name = "dtpHigh";
            this.dtpHigh.Size = new System.Drawing.Size(200, 21);
            this.dtpHigh.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间：";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(130, 167);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSaveAs
            // 
            this.cmdSaveAs.Location = new System.Drawing.Point(255, 167);
            this.cmdSaveAs.Name = "cmdSaveAs";
            this.cmdSaveAs.Size = new System.Drawing.Size(75, 23);
            this.cmdSaveAs.TabIndex = 5;
            this.cmdSaveAs.Text = "导出";
            this.cmdSaveAs.UseVisualStyleBackColor = true;
            this.cmdSaveAs.Click += new System.EventHandler(this.cmdSaveAs_Click);
            // 
            // frmDateZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 231);
            this.Controls.Add(this.cmdSaveAs);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.dtpHigh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpLow);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDateZone";
            this.Text = "选择导出时间";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpLow;
        private System.Windows.Forms.DateTimePicker dtpHigh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSaveAs;
    }
}