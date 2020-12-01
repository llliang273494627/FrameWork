namespace GACNew_VCU_Writer
{
    partial class WinPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinPrintForm));
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrePrint = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pinrtarea = new System.Windows.Forms.GroupBox();
            this.groupPrint = new System.Windows.Forms.GroupBox();
            this.hm = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.erweima = new System.Windows.Forms.PictureBox();
            this.Rjbb = new System.Windows.Forms.Label();
            this.Ljmc = new System.Windows.Forms.Label();
            this.Cxps = new System.Windows.Forms.Label();
            this.tm = new System.Windows.Forms.Label();
            this.pinrtarea.SuspendLayout();
            this.groupPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erweima)).BeginInit();
            this.SuspendLayout();
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(311, 214);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrePrint
            // 
            this.btnPrePrint.Location = new System.Drawing.Point(222, 214);
            this.btnPrePrint.Name = "btnPrePrint";
            this.btnPrePrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrePrint.TabIndex = 7;
            this.btnPrePrint.Text = "打印预览";
            this.btnPrePrint.UseVisualStyleBackColor = true;
            this.btnPrePrint.Click += new System.EventHandler(this.btnPrePrint_Click);
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
            // pinrtarea
            // 
            this.pinrtarea.Controls.Add(this.groupPrint);
            this.pinrtarea.Location = new System.Drawing.Point(16, 20);
            this.pinrtarea.Name = "pinrtarea";
            this.pinrtarea.Size = new System.Drawing.Size(423, 171);
            this.pinrtarea.TabIndex = 9;
            this.pinrtarea.TabStop = false;
            this.pinrtarea.Text = "TCU标签";
            // 
            // groupPrint
            // 
            this.groupPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupPrint.BackColor = System.Drawing.Color.White;
            this.groupPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupPrint.Controls.Add(this.hm);
            this.groupPrint.Controls.Add(this.date);
            this.groupPrint.Controls.Add(this.erweima);
            this.groupPrint.Controls.Add(this.Rjbb);
            this.groupPrint.Controls.Add(this.Ljmc);
            this.groupPrint.Controls.Add(this.Cxps);
            this.groupPrint.Controls.Add(this.tm);
            this.groupPrint.Location = new System.Drawing.Point(36, 38);
            this.groupPrint.Margin = new System.Windows.Forms.Padding(0);
            this.groupPrint.Name = "groupPrint";
            this.groupPrint.Padding = new System.Windows.Forms.Padding(0);
            this.groupPrint.Size = new System.Drawing.Size(350, 119);
            this.groupPrint.TabIndex = 1;
            this.groupPrint.TabStop = false;
            this.groupPrint.Paint += new System.Windows.Forms.PaintEventHandler(this.groupPrint_Paint);
            // 
            // hm
            // 
            this.hm.AutoSize = true;
            this.hm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hm.Location = new System.Drawing.Point(266, 96);
            this.hm.Name = "hm";
            this.hm.Size = new System.Drawing.Size(32, 16);
            this.hm.TabIndex = 6;
            this.hm.Text = "AAA";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.date.Location = new System.Drawing.Point(28, 98);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(28, 14);
            this.date.TabIndex = 5;
            this.date.Text = "AAA";
            // 
            // erweima
            // 
            this.erweima.Location = new System.Drawing.Point(31, 52);
            this.erweima.Name = "erweima";
            this.erweima.Size = new System.Drawing.Size(284, 26);
            this.erweima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.erweima.TabIndex = 4;
            this.erweima.TabStop = false;
            // 
            // Rjbb
            // 
            this.Rjbb.AutoSize = true;
            this.Rjbb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rjbb.Location = new System.Drawing.Point(37, 33);
            this.Rjbb.Name = "Rjbb";
            this.Rjbb.Size = new System.Drawing.Size(160, 16);
            this.Rjbb.TabIndex = 3;
            this.Rjbb.Text = "WBASCWDRERTT0192111";
            // 
            // Ljmc
            // 
            this.Ljmc.AutoSize = true;
            this.Ljmc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ljmc.Location = new System.Drawing.Point(242, 15);
            this.Ljmc.Name = "Ljmc";
            this.Ljmc.Size = new System.Drawing.Size(56, 16);
            this.Ljmc.TabIndex = 2;
            this.Ljmc.Text = "GD5-V0";
            // 
            // Cxps
            // 
            this.Cxps.AutoSize = true;
            this.Cxps.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cxps.Location = new System.Drawing.Point(37, 15);
            this.Cxps.Name = "Cxps";
            this.Cxps.Size = new System.Drawing.Size(32, 16);
            this.Cxps.TabIndex = 1;
            this.Cxps.Text = "A56";
            // 
            // tm
            // 
            this.tm.AutoSize = true;
            this.tm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tm.Location = new System.Drawing.Point(71, 81);
            this.tm.Name = "tm";
            this.tm.Size = new System.Drawing.Size(160, 16);
            this.tm.TabIndex = 0;
            this.tm.Text = "WBASCWDRERTT0192111";
            // 
            // WinPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 273);
            this.Controls.Add(this.pinrtarea);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrePrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WinPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VCU标签打印";
            this.Load += new System.EventHandler(this.WinPrintForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WinPrintForm_Paint);
            this.pinrtarea.ResumeLayout(false);
            this.groupPrint.ResumeLayout(false);
            this.groupPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erweima)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrePrint;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox pinrtarea;
        private System.Windows.Forms.GroupBox groupPrint;
        private System.Windows.Forms.PictureBox erweima;
        private System.Windows.Forms.Label Rjbb;
        private System.Windows.Forms.Label Ljmc;
        private System.Windows.Forms.Label Cxps;
        private System.Windows.Forms.Label tm;
        private System.Windows.Forms.Label hm;
        private System.Windows.Forms.Label date;
    }
}