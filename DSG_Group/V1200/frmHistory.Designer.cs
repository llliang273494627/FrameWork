
namespace DSG_Group.V1200
{
    partial class frmHistory
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Command4 = new System.Windows.Forms.Button();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHigh = new System.Windows.Forms.DateTimePicker();
            this.dtpLow = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MSFlexGrid1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.Label5 = new System.Windows.Forms.LinkLabel();
            this.Command2 = new System.Windows.Forms.Button();
            this.Command3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MSFlexGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Command4);
            this.groupBox1.Controls.Add(this.txtVIN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpHigh);
            this.groupBox1.Controls.Add(this.dtpLow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件选择";
            // 
            // Command4
            // 
            this.Command4.Location = new System.Drawing.Point(671, 70);
            this.Command4.Name = "Command4";
            this.Command4.Size = new System.Drawing.Size(75, 23);
            this.Command4.TabIndex = 12;
            this.Command4.Text = "查询";
            this.Command4.UseVisualStyleBackColor = true;
            this.Command4.Click += new System.EventHandler(this.Command4_Click_1);
            // 
            // txtVIN
            // 
            this.txtVIN.Location = new System.Drawing.Point(100, 32);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(524, 21);
            this.txtVIN.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(63, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "VID";
            // 
            // dtpHigh
            // 
            this.dtpHigh.Location = new System.Drawing.Point(424, 72);
            this.dtpHigh.Name = "dtpHigh";
            this.dtpHigh.Size = new System.Drawing.Size(200, 21);
            this.dtpHigh.TabIndex = 3;
            // 
            // dtpLow
            // 
            this.dtpLow.Location = new System.Drawing.Point(123, 72);
            this.dtpLow.Name = "dtpLow";
            this.dtpLow.Size = new System.Drawing.Size(200, 21);
            this.dtpLow.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "截止日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始日期";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MSFlexGrid1);
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(619, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结果显示";
            // 
            // MSFlexGrid1
            // 
            this.MSFlexGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MSFlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MSFlexGrid1.Location = new System.Drawing.Point(5, 19);
            this.MSFlexGrid1.Name = "MSFlexGrid1";
            this.MSFlexGrid1.RowTemplate.Height = 23;
            this.MSFlexGrid1.Size = new System.Drawing.Size(609, 274);
            this.MSFlexGrid1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.Label5);
            this.groupBox3.Controls.Add(this.Command2);
            this.groupBox3.Controls.Add(this.Command3);
            this.groupBox3.Location = new System.Drawing.Point(637, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(151, 298);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "功能";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.Location = new System.Drawing.Point(54, 106);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(52, 14);
            this.linkLabel2.TabIndex = 16;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "下一页";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label5.Location = new System.Drawing.Point(54, 53);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(52, 14);
            this.Label5.TabIndex = 15;
            this.Label5.TabStop = true;
            this.Label5.Text = "上一页";
            this.Label5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Label5_LinkClicked);
            // 
            // Command2
            // 
            this.Command2.Location = new System.Drawing.Point(46, 169);
            this.Command2.Name = "Command2";
            this.Command2.Size = new System.Drawing.Size(75, 23);
            this.Command2.TabIndex = 14;
            this.Command2.Text = "导    出";
            this.Command2.UseVisualStyleBackColor = true;
            // 
            // Command3
            // 
            this.Command3.Location = new System.Drawing.Point(46, 212);
            this.Command3.Name = "Command3";
            this.Command3.Size = new System.Drawing.Size(75, 23);
            this.Command3.TabIndex = 13;
            this.Command3.Text = "取    消";
            this.Command3.UseVisualStyleBackColor = true;
            this.Command3.Click += new System.EventHandler(this.Command3_Click);
            // 
            // frmHistoryV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHistoryV2";
            this.Text = "显示历史记录";
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MSFlexGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHigh;
        private System.Windows.Forms.DateTimePicker dtpLow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Command4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView MSFlexGrid1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel Label5;
        private System.Windows.Forms.Button Command2;
        private System.Windows.Forms.Button Command3;
    }
}