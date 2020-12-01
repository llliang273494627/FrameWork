using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ZXing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Threading;
using ZXing.Common;

namespace GACNew_VCU_Writer
{
    public delegate void ResultPrintDelegate();

    public partial class Form1 : Form
    {
        //public ResultPrintDelegate resultPrintDelegate = null;

        private string partNum;
        private string hardware;
        private string software;
        private string date;
        private string sw;
        private string hw;
        private string codeTxt;
        private string num;
        private string vin;
        private string sign;

        public Form1(DataGridViewRow dgvr1)
        {
            InitializeComponent();
        }
        /// <summary>
        ///  获取打印的信息
        /// </summary>
        /// <param name="CodeText">追溯条码</param>
        /// <param name="PartNum">零件号</param>
        /// <param name="Software">软件版本</param>
        /// <param name="Hardware">硬件型号</param>
        /// <param name="SW">SW</param>
        /// <param name="HW">HW</param>
        /// <param name="Date">时间</param>
        public Form1(string PartNum, string Software, string Hardware, string SW, string HW ,string Date,string CodeText,string num,string vin,string sign)
        {
            this.partNum = PartNum;
            this.hardware = Hardware;
            this.software = Software;
            this.date = Date;
            this.sw = SW;
            this.hw = HW;
            this.codeTxt =" "+CodeText.Replace("@@","+");
            this.num = num;
            this.vin = vin;
            this.sign = sign;

            InitializeComponent();
            Change();
            //this.resultPrintDelegate = new ResultPrintDelegate(this.PrintResult);
        }


        public void PrintResult()
        {
            try
            {
                this.printDocument1.Print();
                //Thread.Sleep(1000);
                //this.Close();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        #region 接收窗口传入参数
        /// <summary>
        /// 接收窗口传入参值
        /// </summary>
        /// <param name="str"></param>
        public void Change()
        {
            try
            {
                this.lbPartNum.Text = "零件号：" + partNum;
                this.lbHardware.Text = "硬件型号：" + hardware;
                this.lbSoftware.Text = "软件版本：" + software;
                this.lbSW.Text = "SW:"+sw;
                this.lbHW.Text = "HW:"+hw;
                this.lbDate.Text = date;
                this.lbNum.Text = num;
                this.lbVIN.Text = "NO."+vin;
                this.lbSign.Text = sign;
                //this.lbCodeTxt.Text = codeTxt;//二维码内容

                //barcode.ShowCode39StartStop = false;
                //barcode.Visible = true;

                CreatCode(codeTxt);

                //二维码内容
                //if (string.IsNullOrEmpty(codeTxt))//如果CodeTxt没有内容
                //{
                //    MessageBox.Show("二维码内容为空，未能正确加载！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                //}
                //GenByZXingNet(codeTxt);
            }
            catch (Exception)
            {
                MessageBox.Show("打印功能出现问题！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }
        #endregion

        /// <summary>
        /// 生成条形码
        /// </summary>
        private void CreatCode(string text)
        {
            //barcode.Location = new Point(0, 0);

            //barcode.Height = 150;
            //barcode.Width = 300;

            //barcode.Data = this.codeTxt;

            BarcodeWriter writer = new BarcodeWriter();
            
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_128;
            
            EncodingOptions options = new EncodingOptions()
            {
                Width = this.PBData.Width,
                Height = this.PBData.Height,
                //Margin = 10
            };
            writer.Options = options;
            Bitmap map = writer.Write(text.Replace("@@","+"));
            this.PBData.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PBData.Image = map;

            GetViewText(map,text.Replace("@@","+"));

        }

        private void GetViewText(Bitmap p_Bitmap, string p_ViewText)
        {
            Font font = new Font("华为宋体", 12);
            Graphics _Graphics = Graphics.FromImage(p_Bitmap);
            SizeF _DrawSize = _Graphics.MeasureString(p_ViewText.Replace("@@", "+"), font);
            if (_DrawSize.Height > p_Bitmap.Height - 10 || _DrawSize.Width > p_Bitmap.Width)
            {
                _Graphics.Dispose();
                return;
            }

            int _StarX = this.PBData.Width / 2 - (int)_DrawSize.Width/2;
            int _StarY = p_Bitmap.Height - (int)_DrawSize.Height;
            _Graphics.FillRectangle(Brushes.White, new Rectangle(0, _StarY, p_Bitmap.Width, (int)_DrawSize.Height));
            _Graphics.DrawString(string.Join("", new string[] { p_ViewText.Replace("@@", "+") }), font, Brushes.Black, _StarX, _StarY);//文字在图片的中间位置
        }

        /// <summary>
        /// 接收参数信息生成实例
        /// </summary>
        public void index()
        {
            try
            {
            //    this.PartName.Text = "零件名称：" + dgvr.Cells[1].Value.ToString();
            //    this.lbPartNum.Text = "零件号：" + dgvr.Cells[2].Value.ToString();
            //    this.lbHardware.Text = "硬件型号：" + dgvr.Cells[3].Value.ToString();
            //    if (dgvr.Cells[8].Value.ToString() != "1")
            //    {
            //        this.lbSoftware.Text = "软件版本：" + dgvr.Cells[4].Value.ToString();
            //    }
            //    else
            //    {
            //        this.lbSoftware.Visible = false;//隐藏
            //        this.lbPartNum.Location = new Point(3, 35);
            //        this.lbHardware.Location = new Point(3, 64);
            //    }
            //    this.lbSW.Text = dgvr.Cells[5].Value.ToString();
            //    this.lbHW.Text = dgvr.Cells[6].Value.ToString();
            //    this.FlowNum2.Text = dgvr.Cells[7].Value.ToString();
            //    this.lbCodeTxt.Text = dgvr.Cells[9].Value.ToString();//二维码内容
            //    //二维码内容
            //    if (string.IsNullOrEmpty(dgvr.Cells[9].Value.ToString()))
            //    {
            //        MessageBox.Show("二维码内容为空，未能正确加载！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                    return ;
            //    }
            //    GenByZXingNet(dgvr.Cells[9].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("打印功能出现问题！！！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">二维码信息</param>
        /// <returns>图片</returns>
        private Bitmap GenByZXingNet(string msg)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//编码问题
            writer.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.H);
            const int codeSizeInPixels = 150;   //设置图片长宽
            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 0;//设置边框
            ZXing.Common.BitMatrix bm = writer.Encode(msg);
            Bitmap img = writer.Write(bm);
            //pictureBox1.Image = img;
            return img;
        }


        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            try
            {
                PrintResult();
                //this.Invoke(this.resultPrintDelegate, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private void btnPrintCode_Click(object sender, EventArgs e)
        {
            Print();
        }

        /// <summary>
        /// 阅览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        /// <summary>
        /// 打印文档获得绘图对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int currentY = 0;
            //打印文档
            Graphics g = e.Graphics;//获得绘图对象
            if (currentY < 330)
            {
                //新建位图存放打印部分
                Bitmap bmp = new Bitmap(750, 320);
                //将表格转换为位图
                panel3.DrawToBitmap(bmp, new Rectangle(20, 0, 700, 320));
                //打印指定位图的指定区域
                //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                g.DrawImage(bmp, new Rectangle(1, currentY, 900, 250), new Rectangle(1, currentY, 1900, 500), GraphicsUnit.Pixel);
                //g.DrawImage(bmp,new Rectangle(1,currentY,700,320),new Rectangle(1, currentY, 1500, 640), GraphicsUnit.Pixel);                                      //缩放图                                  //源图
                //g.Dispose();

                //Bitmap _NewBitmap = new Bitmap(panel3.Width, panel3.Height);
                //panel3.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
                //e.Graphics.DrawImage(_NewBitmap, new Rectangle(1, currentY, 700, 320), new Rectangle(1, currentY, 1400, 640), GraphicsUnit.Pixel);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Print();//打印
            //this.pl0.BorderStyle
        }

        //自动关闭窗体
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pl0_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pl0.ClientRectangle, Color.Black,ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawEllipse(new Pen(Color.Black, 2), 420, 32, 50, 50);
            
        }     
    }
}
