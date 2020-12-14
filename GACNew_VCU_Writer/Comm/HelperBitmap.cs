﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;

namespace GACNew_VCU_Writer.Comm
{
    public class HelperBitmap
    {
       readonly static Font font = new Font("华为宋体", 12);
       readonly static Pen pen = new Pen(Color.Black, 1);

        public static Bitmap GetBitmap(EntityBitmapLHGQ entity)
        {
            Bitmap bitmap = new Bitmap(750, 320);
            Graphics gs = Graphics.FromImage(bitmap);
            Rectangle mainRec = new Rectangle(new Point(20, 10), new Size(700,300));

            // 左上边框
            var rectangle = new Rectangle(mainRec.X + 3, mainRec.Y + 3, 250, 80);
            gs.DrawRectangle(pen, rectangle);
            gs.DrawString($"零件名称：{entity.PartName}", font, Brushes.Black, rectangle.X + 3, rectangle.Y + 3);
            gs.DrawString($"硬件型号：{entity.Hardware}", font, Brushes.Black, rectangle.X + 3, rectangle.Y + 3 + 27);
            gs.DrawString($"软件版本：{entity.Software}", font, Brushes.Black, rectangle.X + 3, rectangle.Y + 3 + 27 * 2);
            // 右上边
            rectangle = new Rectangle(mainRec.X + 300, mainRec.Y + 3, 250, 80);
            gs.DrawString(entity.Company, font, Brushes.Black, rectangle.X, rectangle.Y + 3);
            gs.DrawString(entity.DateTime, font, Brushes.Black, rectangle.X, rectangle.Y + 3 + 27);
            gs.DrawString(entity.VIN, font, Brushes.Black, rectangle.X, rectangle.Y + 3 + 27 * 2);
            rectangle = new Rectangle(mainRec.X + 430, mainRec.Y + 35, 44, 44);
            gs.DrawEllipse(pen, rectangle);
            gs.DrawString(entity.Sign, font, Brushes.Black, rectangle.X + 22 - entity.Sign.Length * 6, rectangle.Y + 13);
            gs.DrawString(entity.Num, new Font("华为宋体", 21), Brushes.Black, rectangle.X + 65, rectangle.Y + 15);
            // 条码
            rectangle = new Rectangle(mainRec.X + 8, mainRec.Y + 100, 560, 60);
            var code = CreatCode(entity.CodeText, 560, 60);
            if (code != null)
                gs.DrawImage(code, rectangle);
            // 虚线及以下
            var pneline = new Pen(Color.Black, 1);
            pneline.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gs.DrawLine(pneline, mainRec.X + 7, mainRec.Y + 160, mainRec.X + 7 + 500, mainRec.Y + 160);
            gs.DrawString($"零件号：{entity.PartNum}", font, Brushes.Black, mainRec.X + 180, mainRec.Y + 180);
            gs.DrawString($"SW:{entity.SW}", font, Brushes.Black, mainRec.X + 70, mainRec.Y + 200);
            gs.DrawString($"HW:{entity.HW}", font, Brushes.Black, mainRec.X + 310, mainRec.Y + 200);
            return bitmap;
        }

        /// <summary>
        /// 生成条码
        /// </summary>
        /// <param name="text"></param>
        public static Bitmap CreatCode(string text,int width,int herght)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                    text = " ";
                EncodingOptions options = new EncodingOptions()
                {
                    Width = width,
                    Height = herght,
                };
                BarcodeWriter writer = new BarcodeWriter();
                //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
                //如果想生成可识别的可以使用 CODE_128 格式
                //writer.Format = BarcodeFormat.ITF;
                writer.Format = BarcodeFormat.CODE_128;
                writer.Options = options;
                Bitmap map = writer.Write(text.Replace("@@", "+"));
                return map;
            }
            catch (Exception ex)
            {
                Log.Error("生成条码失败！", ex);
                return null;
            }
        }
    }

    public class EntityBitmapLHGQ
    {
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PartName { get; set; } = string.Empty;

        /// <summary>
        /// 硬件型号
        /// </summary>
        public string Hardware { get; set; } = string.Empty;

        /// <summary>
        /// 软件版本
        /// </summary>
        public string Software { get; set; } = string.Empty;

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; } = string.Empty;

        /// <summary>
        /// 日期
        /// </summary>
        public string DateTime { get; set; } = string.Empty;

        public string VIN { get; set; } = string.Empty;

        public string Sign { get; set; } = string.Empty;

        public string Num { get; set; } = string.Empty;

        public string CodeText { get; set; } = string.Empty;

        public string PartNum { get; set; } = string.Empty;

        public string SW { get; set; } = string.Empty;

        public string HW { get; set; } = string.Empty;
    }
}
