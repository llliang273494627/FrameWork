namespace GACNew_VCU_Writer
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.btnPrintCode = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbSign = new System.Windows.Forms.Label();
            this.lbNum = new System.Windows.Forms.Label();
            this.PBData = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbHW = new System.Windows.Forms.Label();
            this.pl0 = new System.Windows.Forms.Panel();
            this.lbHardware = new System.Windows.Forms.Label();
            this.lbSoftware = new System.Windows.Forms.Label();
            this.PartName = new System.Windows.Forms.Label();
            this.lbSW = new System.Windows.Forms.Label();
            this.lbVIN = new System.Windows.Forms.Label();
            this.lbPartNum = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ovalShape1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBData)).BeginInit();
            this.pl0.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(7, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 24;
            this.button2.Text = "打印阅览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPrintCode
            // 
            this.btnPrintCode.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrintCode.Location = new System.Drawing.Point(157, 329);
            this.btnPrintCode.Name = "btnPrintCode";
            this.btnPrintCode.Size = new System.Drawing.Size(99, 37);
            this.btnPrintCode.TabIndex = 25;
            this.btnPrintCode.Text = "条码打印";
            this.btnPrintCode.UseVisualStyleBackColor = true;
            this.btnPrintCode.Click += new System.EventHandler(this.btnPrintCode_Click);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 230);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lbSign);
            this.panel3.Controls.Add(this.lbNum);
            this.panel3.Controls.Add(this.PBData);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lbHW);
            this.panel3.Controls.Add(this.pl0);
            this.panel3.Controls.Add(this.lbSW);
            this.panel3.Controls.Add(this.lbVIN);
            this.panel3.Controls.Add(this.lbPartNum);
            this.panel3.Controls.Add(this.lbDate);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.shapeContainer1);
            this.panel3.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 225);
            this.panel3.TabIndex = 7;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lbSign
            // 
            this.lbSign.AutoSize = true;
            this.lbSign.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbSign.Location = new System.Drawing.Point(429, 47);
            this.lbSign.Name = "lbSign";
            this.lbSign.Size = new System.Drawing.Size(20, 20);
            this.lbSign.TabIndex = 28;
            this.lbSign.Text = "1";
            this.lbSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Font = new System.Drawing.Font("宋体", 21F, System.Drawing.FontStyle.Bold);
            this.lbNum.Location = new System.Drawing.Point(493, 51);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(57, 28);
            this.lbNum.TabIndex = 26;
            this.lbNum.Text = "A18";
            this.lbNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBData
            // 
            this.PBData.Location = new System.Drawing.Point(7, 98);
            this.PBData.Name = "PBData";
            this.PBData.Size = new System.Drawing.Size(565, 60);
            this.PBData.TabIndex = 21;
            this.PBData.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "----------------------------------------------------------";
            // 
            // lbHW
            // 
            this.lbHW.AutoSize = true;
            this.lbHW.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHW.Location = new System.Drawing.Point(314, 203);
            this.lbHW.Name = "lbHW";
            this.lbHW.Size = new System.Drawing.Size(35, 16);
            this.lbHW.TabIndex = 9;
            this.lbHW.Text = "HW:";
            // 
            // pl0
            // 
            this.pl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl0.Controls.Add(this.lbHardware);
            this.pl0.Controls.Add(this.lbSoftware);
            this.pl0.Controls.Add(this.PartName);
            this.pl0.Location = new System.Drawing.Point(4, 5);
            this.pl0.Name = "pl0";
            this.pl0.Size = new System.Drawing.Size(248, 80);
            this.pl0.TabIndex = 8;
            this.pl0.Paint += new System.Windows.Forms.PaintEventHandler(this.pl0_Paint);
            // 
            // lbHardware
            // 
            this.lbHardware.AutoSize = true;
            this.lbHardware.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHardware.Location = new System.Drawing.Point(4, 30);
            this.lbHardware.Name = "lbHardware";
            this.lbHardware.Size = new System.Drawing.Size(93, 16);
            this.lbHardware.TabIndex = 6;
            this.lbHardware.Text = "硬件型号：";
            // 
            // lbSoftware
            // 
            this.lbSoftware.AutoSize = true;
            this.lbSoftware.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSoftware.ForeColor = System.Drawing.Color.Black;
            this.lbSoftware.Location = new System.Drawing.Point(4, 57);
            this.lbSoftware.Name = "lbSoftware";
            this.lbSoftware.Size = new System.Drawing.Size(93, 16);
            this.lbSoftware.TabIndex = 7;
            this.lbSoftware.Text = "软件版本：";
            // 
            // PartName
            // 
            this.PartName.AutoSize = true;
            this.PartName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartName.Location = new System.Drawing.Point(4, 4);
            this.PartName.Name = "PartName";
            this.PartName.Size = new System.Drawing.Size(178, 16);
            this.PartName.TabIndex = 5;
            this.PartName.Text = "零件名称：整车控制器";
            // 
            // lbSW
            // 
            this.lbSW.AutoSize = true;
            this.lbSW.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSW.Location = new System.Drawing.Point(67, 203);
            this.lbSW.Name = "lbSW";
            this.lbSW.Size = new System.Drawing.Size(35, 16);
            this.lbSW.TabIndex = 8;
            this.lbSW.Text = "SW:";
            // 
            // lbVIN
            // 
            this.lbVIN.AutoSize = true;
            this.lbVIN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbVIN.Location = new System.Drawing.Point(297, 64);
            this.lbVIN.Name = "lbVIN";
            this.lbVIN.Size = new System.Drawing.Size(71, 16);
            this.lbVIN.TabIndex = 7;
            this.lbVIN.Text = "NO.0001";
            // 
            // lbPartNum
            // 
            this.lbPartNum.AutoSize = true;
            this.lbPartNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPartNum.Location = new System.Drawing.Point(180, 181);
            this.lbPartNum.Name = "lbPartNum";
            this.lbPartNum.Size = new System.Drawing.Size(76, 16);
            this.lbPartNum.TabIndex = 2;
            this.lbPartNum.Text = "零件号：";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDate.Location = new System.Drawing.Point(297, 38);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(98, 16);
            this.lbDate.TabIndex = 6;
            this.lbDate.Text = "2018/12/21";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(297, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "联合汽车电子有限公司";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ovalShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(594, 225);
            this.shapeContainer1.TabIndex = 29;
            this.shapeContainer1.TabStop = false;
            // 
            // ovalShape1
            // 
            this.ovalShape1.BackColor = System.Drawing.Color.Transparent;
            this.ovalShape1.Location = new System.Drawing.Point(486, 34);
            this.ovalShape1.Name = "ovalShape1";
            this.ovalShape1.Size = new System.Drawing.Size(45, 45);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(616, 383);
            this.Controls.Add(this.btnPrintCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBData)).EndInit();
            this.pl0.ResumeLayout(false);
            this.pl0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label manufacture;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPrintCode;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.PictureBox PBData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbHW;
        private System.Windows.Forms.Panel pl0;
        private System.Windows.Forms.Label lbHardware;
        private System.Windows.Forms.Label lbSoftware;
        private System.Windows.Forms.Label PartName;
        private System.Windows.Forms.Label lbSW;
        private System.Windows.Forms.Label lbVIN;
        private System.Windows.Forms.Label lbPartNum;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSign;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShape1;
    }
}

