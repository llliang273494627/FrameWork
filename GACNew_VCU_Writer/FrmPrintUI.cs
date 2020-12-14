using GACNew_VCU_Writer.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GACNew_VCU_Writer
{
    public partial class FrmPrintUI : Form
    {
        public FrmPrintUI()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int currentY = 0;
            //打印文档
            Graphics g = e.Graphics;//获得绘图对象
            if (currentY < 330)
            {
                //新建位图存放打印部分
                Bitmap bmp = new Bitmap(750, 320);
                //将表格转换为位图
                //pictureBox1.DrawToBitmap(bmp, new Rectangle(20, 0, 700, 320));
                bmp = pictureBox1.Image as Bitmap;

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.DrawImage(bmp, new Rectangle(1, currentY, 900, 250), new Rectangle(1, currentY, 1900, 500), GraphicsUnit.Pixel);
            }
        }

        private void bntPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        public async void bntSaveFile_Click(object sender, EventArgs e)
        {
            var bitmap = await ServiceApi.GetQRCodeBitmap("test");
            if (bitmap != null)
                pictureBox1.Image = bitmap;
            else { MessageBox.Show("请求接口失败！"); }
        }
    }
}
