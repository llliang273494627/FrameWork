
namespace DSG_Group
{
    partial class frmPSW
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
            this.labPwd = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.bntSignIn = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labPwd
            // 
            this.labPwd.AutoSize = true;
            this.labPwd.Location = new System.Drawing.Point(51, 40);
            this.labPwd.Name = "labPwd";
            this.labPwd.Size = new System.Drawing.Size(65, 12);
            this.labPwd.TabIndex = 0;
            this.labPwd.Text = "管理密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(122, 37);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(185, 21);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.Text = "37639808";
            // 
            // bntSignIn
            // 
            this.bntSignIn.Location = new System.Drawing.Point(77, 88);
            this.bntSignIn.Name = "bntSignIn";
            this.bntSignIn.Size = new System.Drawing.Size(75, 23);
            this.bntSignIn.TabIndex = 2;
            this.bntSignIn.Text = "登录";
            this.bntSignIn.UseVisualStyleBackColor = true;
            this.bntSignIn.Click += new System.EventHandler(this.bntSignIn_Click);
            // 
            // bntCancel
            // 
            this.bntCancel.Location = new System.Drawing.Point(210, 88);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(75, 23);
            this.bntCancel.TabIndex = 3;
            this.bntCancel.Text = "取消";
            this.bntCancel.UseVisualStyleBackColor = true;
            this.bntCancel.Click += new System.EventHandler(this.bntCancel_Click);
            // 
            // frmPSW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(356, 163);
            this.Controls.Add(this.bntCancel);
            this.Controls.Add(this.bntSignIn);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.labPwd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPSW";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labPwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button bntSignIn;
        private System.Windows.Forms.Button bntCancel;
    }
}