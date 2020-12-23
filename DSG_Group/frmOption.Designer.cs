
namespace DSG_Group
{
    partial class frmOption
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
            this.tabcontSetting = new System.Windows.Forms.TabControl();
            this.pageRunParam = new System.Windows.Forms.TabPage();
            this.groupUpdata = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.bntUpdata = new System.Windows.Forms.Button();
            this.txtDis = new System.Windows.Forms.TextBox();
            this.labDis = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.labValue = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.labKey = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.labUpdateGroup = new System.Windows.Forms.Label();
            this.groupRunPatams = new System.Windows.Forms.GroupBox();
            this.datagridRunParam = new System.Windows.Forms.DataGridView();
            this.combRunGroup = new System.Windows.Forms.ComboBox();
            this.labGroup = new System.Windows.Forms.Label();
            this.pagecontParam = new System.Windows.Forms.TabPage();
            this.pageManualUpdata = new System.Windows.Forms.TabPage();
            this.pageExeNoSetting = new System.Windows.Forms.TabPage();
            this.tabcontSetting.SuspendLayout();
            this.pageRunParam.SuspendLayout();
            this.groupUpdata.SuspendLayout();
            this.groupRunPatams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridRunParam)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcontSetting
            // 
            this.tabcontSetting.Controls.Add(this.pageRunParam);
            this.tabcontSetting.Controls.Add(this.pagecontParam);
            this.tabcontSetting.Controls.Add(this.pageManualUpdata);
            this.tabcontSetting.Controls.Add(this.pageExeNoSetting);
            this.tabcontSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcontSetting.Location = new System.Drawing.Point(0, 0);
            this.tabcontSetting.Name = "tabcontSetting";
            this.tabcontSetting.SelectedIndex = 0;
            this.tabcontSetting.Size = new System.Drawing.Size(899, 462);
            this.tabcontSetting.TabIndex = 0;
            // 
            // pageRunParam
            // 
            this.pageRunParam.Controls.Add(this.groupUpdata);
            this.pageRunParam.Controls.Add(this.groupRunPatams);
            this.pageRunParam.Location = new System.Drawing.Point(4, 22);
            this.pageRunParam.Name = "pageRunParam";
            this.pageRunParam.Padding = new System.Windows.Forms.Padding(3);
            this.pageRunParam.Size = new System.Drawing.Size(891, 436);
            this.pageRunParam.TabIndex = 0;
            this.pageRunParam.Text = "运行参数";
            this.pageRunParam.UseVisualStyleBackColor = true;
            // 
            // groupUpdata
            // 
            this.groupUpdata.Controls.Add(this.button2);
            this.groupUpdata.Controls.Add(this.bntUpdata);
            this.groupUpdata.Controls.Add(this.txtDis);
            this.groupUpdata.Controls.Add(this.labDis);
            this.groupUpdata.Controls.Add(this.txtValue);
            this.groupUpdata.Controls.Add(this.labValue);
            this.groupUpdata.Controls.Add(this.txtKey);
            this.groupUpdata.Controls.Add(this.labKey);
            this.groupUpdata.Controls.Add(this.txtGroup);
            this.groupUpdata.Controls.Add(this.labUpdateGroup);
            this.groupUpdata.Location = new System.Drawing.Point(607, 30);
            this.groupUpdata.Name = "groupUpdata";
            this.groupUpdata.Size = new System.Drawing.Size(257, 381);
            this.groupUpdata.TabIndex = 1;
            this.groupUpdata.TabStop = false;
            this.groupUpdata.Text = "修改";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bntUpdata
            // 
            this.bntUpdata.Location = new System.Drawing.Point(30, 315);
            this.bntUpdata.Name = "bntUpdata";
            this.bntUpdata.Size = new System.Drawing.Size(75, 23);
            this.bntUpdata.TabIndex = 9;
            this.bntUpdata.Text = "修改";
            this.bntUpdata.UseVisualStyleBackColor = true;
            // 
            // txtDis
            // 
            this.txtDis.Location = new System.Drawing.Point(87, 166);
            this.txtDis.Multiline = true;
            this.txtDis.Name = "txtDis";
            this.txtDis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDis.Size = new System.Drawing.Size(139, 110);
            this.txtDis.TabIndex = 8;
            // 
            // labDis
            // 
            this.labDis.AutoSize = true;
            this.labDis.Location = new System.Drawing.Point(40, 169);
            this.labDis.Name = "labDis";
            this.labDis.Size = new System.Drawing.Size(41, 12);
            this.labDis.TabIndex = 7;
            this.labDis.Text = "描述：";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(87, 130);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(139, 21);
            this.txtValue.TabIndex = 6;
            // 
            // labValue
            // 
            this.labValue.AutoSize = true;
            this.labValue.Location = new System.Drawing.Point(52, 133);
            this.labValue.Name = "labValue";
            this.labValue.Size = new System.Drawing.Size(29, 12);
            this.labValue.TabIndex = 5;
            this.labValue.Text = "值：";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(87, 94);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(139, 21);
            this.txtKey.TabIndex = 4;
            // 
            // labKey
            // 
            this.labKey.AutoSize = true;
            this.labKey.Location = new System.Drawing.Point(28, 97);
            this.labKey.Name = "labKey";
            this.labKey.Size = new System.Drawing.Size(53, 12);
            this.labKey.TabIndex = 3;
            this.labKey.Text = "关键字：";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(87, 58);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(139, 21);
            this.txtGroup.TabIndex = 2;
            // 
            // labUpdateGroup
            // 
            this.labUpdateGroup.AutoSize = true;
            this.labUpdateGroup.Location = new System.Drawing.Point(52, 61);
            this.labUpdateGroup.Name = "labUpdateGroup";
            this.labUpdateGroup.Size = new System.Drawing.Size(29, 12);
            this.labUpdateGroup.TabIndex = 1;
            this.labUpdateGroup.Text = "组：";
            // 
            // groupRunPatams
            // 
            this.groupRunPatams.Controls.Add(this.datagridRunParam);
            this.groupRunPatams.Controls.Add(this.combRunGroup);
            this.groupRunPatams.Controls.Add(this.labGroup);
            this.groupRunPatams.Location = new System.Drawing.Point(26, 30);
            this.groupRunPatams.Name = "groupRunPatams";
            this.groupRunPatams.Size = new System.Drawing.Size(550, 381);
            this.groupRunPatams.TabIndex = 0;
            this.groupRunPatams.TabStop = false;
            this.groupRunPatams.Text = "参数列表";
            // 
            // datagridRunParam
            // 
            this.datagridRunParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridRunParam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.datagridRunParam.Location = new System.Drawing.Point(3, 66);
            this.datagridRunParam.Name = "datagridRunParam";
            this.datagridRunParam.RowTemplate.Height = 23;
            this.datagridRunParam.Size = new System.Drawing.Size(544, 312);
            this.datagridRunParam.TabIndex = 2;
            this.datagridRunParam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridRunParam_CellClick);
            // 
            // combRunGroup
            // 
            this.combRunGroup.FormattingEnabled = true;
            this.combRunGroup.Location = new System.Drawing.Point(104, 26);
            this.combRunGroup.Name = "combRunGroup";
            this.combRunGroup.Size = new System.Drawing.Size(159, 20);
            this.combRunGroup.TabIndex = 1;
            this.combRunGroup.SelectedValueChanged += new System.EventHandler(this.combRunGroup_SelectedValueChanged);
            // 
            // labGroup
            // 
            this.labGroup.AutoSize = true;
            this.labGroup.Location = new System.Drawing.Point(69, 29);
            this.labGroup.Name = "labGroup";
            this.labGroup.Size = new System.Drawing.Size(29, 12);
            this.labGroup.TabIndex = 0;
            this.labGroup.Text = "组：";
            // 
            // pagecontParam
            // 
            this.pagecontParam.Location = new System.Drawing.Point(4, 22);
            this.pagecontParam.Name = "pagecontParam";
            this.pagecontParam.Padding = new System.Windows.Forms.Padding(3);
            this.pagecontParam.Size = new System.Drawing.Size(891, 436);
            this.pagecontParam.TabIndex = 1;
            this.pagecontParam.Text = "控制参数";
            this.pagecontParam.UseVisualStyleBackColor = true;
            // 
            // pageManualUpdata
            // 
            this.pageManualUpdata.Location = new System.Drawing.Point(4, 22);
            this.pageManualUpdata.Name = "pageManualUpdata";
            this.pageManualUpdata.Padding = new System.Windows.Forms.Padding(3);
            this.pageManualUpdata.Size = new System.Drawing.Size(891, 436);
            this.pageManualUpdata.TabIndex = 2;
            this.pageManualUpdata.Text = "手工维护";
            this.pageManualUpdata.UseVisualStyleBackColor = true;
            // 
            // pageExeNoSetting
            // 
            this.pageExeNoSetting.Location = new System.Drawing.Point(4, 22);
            this.pageExeNoSetting.Name = "pageExeNoSetting";
            this.pageExeNoSetting.Padding = new System.Windows.Forms.Padding(3);
            this.pageExeNoSetting.Size = new System.Drawing.Size(891, 436);
            this.pageExeNoSetting.TabIndex = 3;
            this.pageExeNoSetting.Text = "程序号设置";
            this.pageExeNoSetting.UseVisualStyleBackColor = true;
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 462);
            this.Controls.Add(this.tabcontSetting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOption";
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.frmOption_Load);
            this.tabcontSetting.ResumeLayout(false);
            this.pageRunParam.ResumeLayout(false);
            this.groupUpdata.ResumeLayout(false);
            this.groupUpdata.PerformLayout();
            this.groupRunPatams.ResumeLayout(false);
            this.groupRunPatams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridRunParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcontSetting;
        private System.Windows.Forms.TabPage pageRunParam;
        private System.Windows.Forms.GroupBox groupRunPatams;
        private System.Windows.Forms.GroupBox groupUpdata;
        private System.Windows.Forms.TabPage pagecontParam;
        private System.Windows.Forms.TabPage pageManualUpdata;
        private System.Windows.Forms.TabPage pageExeNoSetting;
        private System.Windows.Forms.DataGridView datagridRunParam;
        private System.Windows.Forms.ComboBox combRunGroup;
        private System.Windows.Forms.Label labGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bntUpdata;
        private System.Windows.Forms.TextBox txtDis;
        private System.Windows.Forms.Label labDis;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label labValue;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label labKey;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label labUpdateGroup;
    }
}