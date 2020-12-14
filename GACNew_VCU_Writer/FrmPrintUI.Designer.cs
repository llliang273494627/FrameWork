
namespace GACNew_VCU_Writer
{
    partial class FrmPrintUI
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
            this.bntPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.bntSaveFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bntPrint
            // 
            this.bntPrint.Enabled = false;
            this.bntPrint.Location = new System.Drawing.Point(367, 21);
            this.bntPrint.Name = "bntPrint";
            this.bntPrint.Size = new System.Drawing.Size(75, 23);
            this.bntPrint.TabIndex = 5;
            this.bntPrint.Text = "打印";
            this.bntPrint.UseVisualStyleBackColor = true;
            this.bntPrint.Click += new System.EventHandler(this.bntPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // bntSaveFile
            // 
            this.bntSaveFile.AutoSize = true;
            this.bntSaveFile.Location = new System.Drawing.Point(153, 21);
            this.bntSaveFile.Name = "bntSaveFile";
            this.bntSaveFile.Size = new System.Drawing.Size(87, 23);
            this.bntSaveFile.TabIndex = 6;
            this.bntSaveFile.Text = "测试生成样式";
            this.bntSaveFile.UseVisualStyleBackColor = true;
            this.bntSaveFile.Click += new System.EventHandler(this.bntSaveFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Location = new System.Drawing.Point(12, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 259);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrintUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 369);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bntSaveFile);
            this.Controls.Add(this.bntPrint);
            this.Name = "FrmPrintUI";
            this.Text = "FrmPrintUI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bntPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button bntSaveFile;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}