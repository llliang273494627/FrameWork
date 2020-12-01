using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using GACNew_VCU_Writer;
using System.Drawing.Drawing2D;
using Zen.Barcode;
using GACNew_VCU_Writer_BLL;

namespace GACNew_VCU_Writer
{
    public partial class WinPrintForm : Form
    {
        public WinPrintForm()
        {
            InitializeComponent();
        }

        public WinPrintForm(Object tag)
        {
            InitializeComponent();
            this.Tag = tag;
        }

        private void WinPrintForm_Paint(object sender, PaintEventArgs e)
        {

        }


        PrintInfo PrtInfo = null;
        private void WinPrintForm_Load(object sender, EventArgs e)
        {
            Print();
            //btnPrint_Click(sender, e);
        }

        private void Print()
        {
            this.printDocument1.OriginAtMargins = false;//启用页边距            
            this.pageSetupDialog1.EnableMetric = true; //以毫米为单位
            this.printDialog1.PrinterSettings.PrinterName =  System.Configuration.ConfigurationSettings.AppSettings["print1"];
            string printname = printDocument1.PrinterSettings.PrinterName;
            PrintPageSize page = new PrintPageSize();
            page.SetPrintForm(printname, "dianchibiaoqian", 700, 200);
            foreach (PaperSize ps in printDocument1.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName.Equals("dianchibiaoqian"))
                    printDocument1.DefaultPageSettings.PaperSize = ps;
            }
            PrtInfo = (PrintInfo)this.Tag;
            dataBind(PrtInfo);
            //btnPrint_Click(this.btnPrint, new EventArgs());
        }

        private void dataBind(PrintInfo info)
        {
            //生成二维码
            //CodeQrBarcodeDraw qrcode = BarcodeDrawFactory.CodeQr;
            //Image img = qrcode.Draw("Hello World", qrcode.GetDefaultMetrics(40));

            //Code128BarcodeDraw barcode128 = BarcodeDrawFactory.Code128WithChecksum;
            //Image img = barcode128.Draw("12345678901234567", 40);
            //this.erweima.Image = img;
            if (info.Barcode != "")
            {
                //生成二维码
                //MemoryStream ms = GetQRCode(info.Barcode);
                //this.erweima.Image = Image.FromStream(ms);

                //生成条码
                Code128BarcodeDraw barcode128 = BarcodeDrawFactory.Code128WithChecksum;
                Image img = barcode128.Draw(info.Barcode, 40);
                this.erweima.Image = img;
            }

            this.Cxps.Text = info.OptionCode;
            this.Ljmc.Text = info.PartsName;
            this.Rjbb.Text = info.SoftWareVersion;
            this.tm.Text = "+" + info.Barcode;
            this.date.Text = DateTime.Now + "";
            this.hm.Text = "NO." + info.Number;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public MemoryStream GetQRCode(string strContent)
        {
            MemoryStream ms = new MemoryStream();
            ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平   
            string Content = strContent;//待编码内容  
            QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域               
            int ModuleSize = 12;//大小  
            var encoder = new QrEncoder(Ecl);
            QrCode qr;
            if (encoder.TryEncode(Content, out qr))//对内容进行编码，并保存生成的矩阵  
            {
                var render = new GraphicsRenderer(new FixedModuleSize(ModuleSize, QuietZones));
                render.WriteToStream(qr.Matrix, ImageFormat.Png, ms);
            }
            return ms;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {          
            Bitmap _NewBitmap = new Bitmap(this.groupPrint.Width, this.groupPrint.Height);
            groupPrint.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            //设置高质量,低速度呈现平滑程度
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);
        }

        private void groupPrint_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(groupPrint.BackColor); 
        }





        public static double MillimetersToPixelsWidth(double length) //length是毫米，1厘米=10毫米
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(p.Handle);
            IntPtr hdc = g.GetHdc();
            int width = GetDeviceCaps(hdc, 4);     // HORZRES 
            int pixels = GetDeviceCaps(hdc, 8);     // BITSPIXEL
            g.ReleaseHdc(hdc);
            return (((double)pixels / (double)width) * (double)length);
        }
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int Index);

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrePrint_Click(object sender, EventArgs e)
        {
            string printname = printDocument1.PrinterSettings.PrinterName;
            PrintPageSize page = new PrintPageSize();
            page.SetPrintForm(printname, "dianchibiaoqian", 700, 200);
            foreach (PaperSize ps in printDocument1.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName.Equals("dianchibiaoqian"))
                    printDocument1.DefaultPageSettings.PaperSize = ps;
            }
            this.printPreviewDialog1.ShowDialog(); 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.btnPrint.Text = "打印中..";
            this.btnPrint.Enabled = false;
            System.Threading.Thread.Sleep(200);

            PrintController printController = new StandardPrintController();
            printDocument1.PrintController = printController;
            this.printDocument1.Print();

            this.btnPrint.Enabled = true;
            this.btnPrint.Text = "打印";

            this.Close();
        }
    }
}
