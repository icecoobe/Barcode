using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Barcode._2D;
//using Barcode._2D.Properties;

namespace Barcode._2D
{
    public enum BarcodeType
    {
        PDF417 = 1,
        QRCODE = 2,
        DATAMATRIX = 3
    }

    public class GenerateImage
    {
        private static Bitmap GenerateBitmap(string barcodeText, int hscale, int vscale)
        {
            Pdf417lib pd = new Pdf417lib();
            pd.setText(barcodeText);
            pd.Options = Pdf417lib.PDF417_INVERT_BITMAP;
            pd.paintCode();
            Bitmap bitmap = new Bitmap(pd.BitColumns * hscale, pd.CodeRows * vscale);
            Graphics g = Graphics.FromImage(bitmap);
            sbyte[] bits = pd.OutBits;

            int cols = (pd.BitColumns - 1) / 8 + 1;

            int row = -1;
            int bitcol = 0;
            for (int i = 0; i < bits.Length; ++i)
            {
                if ((i % cols) == 0)
                {
                    row++;
                    bitcol = 0;
                }
                int value = bits[i];
                for (int j = 7; j >= 0; j--)
                {
                    int mask = (int)Math.Pow(2, j);
                    if ((value & mask) != 0)
                        g.FillRectangle(Brushes.White, bitcol * hscale, row * vscale, hscale, vscale);
                    else
                        g.FillRectangle(Brushes.Black, bitcol * hscale, row * vscale, hscale, vscale);
                    bitcol++;
                    if (bitcol == pd.BitColumns)
                        break;
                }
            }
            g.Dispose();

            return bitmap;
        }
        private static Bitmap PDF417(string Data)
        {
            Bitmap x = new Bitmap(50, 50);
            return GenerateBitmap(Data, 1, 1);
        }
        private static Bitmap DataMatrix(string Data)
        {
            DmtxImageEncoder encoder = new DmtxImageEncoder();
            DmtxImageEncoderOptions options = new DmtxImageEncoderOptions();
            options.ModuleSize = 5;
            options.MarginSize = 5;
            options.BackColor = Color.White;
            options.ForeColor = Color.Green;
            Bitmap encodedBitmap = encoder.EncodeImage(Data);
            return encodedBitmap;
        }
        private static Bitmap Qrcode(string Data)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 10;  //可改变大小
            qrCodeEncoder.QRCodeVersion = 6;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            return qrCodeEncoder.Encode(Data);
            
        }
        public static Bitmap GenerateBarcode(string Data , BarcodeType type)
        {
            switch (type) 
            {
                case BarcodeType.DATAMATRIX:
                    return DataMatrix(Data);
                case BarcodeType.PDF417:
                    return PDF417(Data);
                case BarcodeType.QRCODE:
                    return Qrcode(Data);
                default :
                    return PDF417(Data);
            }
        }
        /// <summary> 
        /// 对图片进行处理,返回一个Bitmap类别的对象 
        /// </summary> 
        /// <param name="oldBmpPath">原图片路径</param> 
        /// <param name="newWidth">新图片宽度</param> 
        /// <param name="newHeight">新图片高度</param> 
        /// <returns></returns> 
        public static Bitmap GetNewBitMap(Bitmap oldBmp, int newWidth)
        {
            int newHeight=100;
            Bitmap bmp = new Bitmap(newWidth, newHeight); // 创建新图片 
            Graphics grap = Graphics.FromImage(bmp); // 绑定画板 
            newHeight = newWidth;
            Console.WriteLine(newWidth + "=========" + newHeight);
            // 原图片的开始绘制位置,及宽和高 (控制Rectangle的组成参数,便可实现对图片的剪切) 
            Rectangle oldRect = new Rectangle(0, 0, oldBmp.Width, oldBmp.Height);

            // 绘制在新画板中的位置,及宽和高 (在这里是完全填充) 
            Rectangle newRect = new Rectangle(0, 0, newWidth, newHeight);

            // 指定新图片的画面质量 
            grap.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            // 把原图片指定位置的图像绘制到新画板中 
            grap.DrawImage(oldBmp, newRect, oldRect, GraphicsUnit.Pixel);

            /* 
              * 画图的步骤到此就已经完成了. 
              * 
              * 在绘制完成新图片后,还可以使用 Graphics对象的一些方法,为图片添加自定义的内容 
              * grap.DrawString(...);添加文字 
              * grap.DrawPie(...);添加扇形 
              * grap.DrawLine(...);添加直线 
              * ... 
              * */

            // 添加文字 
            //Brush bru = Brushes.Red; // 笔刷 
            //Font font = new Font(new FontFamily("华文行楷"), 30, FontStyle.Regular, GraphicsUnit.World); // 字体 
            //PointF pf = new PointF(3, 3); // 坐标 
            //    grap.DrawString("羊", font, bru, pf); // 填充文字 
            return bmp;
        } 
    }

}
