using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Shu.Utility;

namespace Shu.BLL
{
    public class EKImage
    {
        /// <summary>
        /// 添加水印并替换原图
        /// </summary>
        /// <param name="imagepath">图片路径</param>
        /// <param name="watermark">水印信息</param>
        /// <param name="width">生成图片的宽的上限，0为保持原图</param>
        /// <param name="height">生成图片的高的上限，0为保持原图</param>
        public static void AddWatermark(string imagepath, Watermark watermark, int Width, int Height)
        {
            System.Drawing.Imaging.ImageFormat xObject;
            string ext = EKFileUpload.getExtend(imagepath);
            ext = ext.ToLower();
            switch (ext)
            {
                case ".gif":
                    xObject = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case ".bmp":
                    xObject = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
                case ".png":
                    xObject = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                default:
                    xObject = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
            }

            Bitmap xBitmap = new Bitmap(imagepath);

            System.Drawing.Image bitmap;
            System.Drawing.Graphics g;
            CreateThumbnail(Width, Height, xBitmap, out bitmap, out g);
            //添加水印
            if (watermark != null)
            {
                int TempWidth = bitmap.Width;
                int TempHeight = bitmap.Height;

                if (watermark.MarkType == "text")
                {
                    //声明字体对象 
                    Font cFont = null;
                    //用来测试水印文本长度得尺子 
                    SizeF size = new SizeF();

                    int[] sizes = new int[] { watermark.Size, 60, 48, 40, 36, 32, 30, 28, 24, 22, 20, 18, 16, 14, 12, 8, 6, 4 };

                    //探测出一个适合图片大小得字体大小，以适应水印文字大小得自适应 
                    for (int i = 0; i < 18; i++)
                    {
                        if (sizes[i] == 0)
                        {
                            continue;
                        }
                        //创建一个字体对象 
                        cFont = new Font(watermark.FontFamily, sizes[i], FontStyle.Regular);
                        //是否加粗、倾斜
                        if (watermark.TextBlod && watermark.TextItalic)
                        {
                            cFont = new Font(watermark.FontFamily, sizes[i], FontStyle.Bold | FontStyle.Italic);
                        }
                        else if (watermark.TextBlod)
                        {
                            cFont = new Font(watermark.FontFamily, sizes[i], FontStyle.Bold);
                        }
                        else if (watermark.TextItalic)
                        {
                            cFont = new Font(watermark.FontFamily, sizes[i], FontStyle.Italic);
                        }

                        //测量文本大小 
                        size = g.MeasureString(watermark.Text, cFont);
                        //匹配第一个符合要求得字体大小 
                        if ((ushort)size.Width < (ushort)TempWidth)
                        {
                            break;
                        }
                    }

                    Brush brush = new SolidBrush(Color.FromArgb(Convert.ToInt32(watermark.Transparency * 255), watermark.TextColor));

                    //添加水印 文字
                    g.DrawString(watermark.Text, cFont, brush, watermark.Position(watermark.Place, new SizeF(TempWidth, TempHeight), size));
                }
                else if (watermark.MarkType == "image")
                {
                    //获得水印图像 
                    System.Drawing.Image markImg = System.Drawing.Image.FromFile(EKFileUpload.FilePath + watermark.ImgPath);

                    //创建颜色矩阵 
                    float[][] ptsArray ={  
                                                       new float[] {1, 0, 0, 0, 0}, 
                                                       new float[] {0, 1, 0, 0, 0}, 
                                                       new float[] {0, 0, 1, 0, 0}, 
                                                       new float[] {0, 0, 0, watermark.Transparency, 0}, //注意：此处为0.0f为完全透明，1.0f为完全不透明 
                                                       new float[] {0, 0, 0, 0, 1}};
                    ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
                    //新建一个Image属性 
                    ImageAttributes imageAttributes = new ImageAttributes();
                    //将颜色矩阵添加到属性 
                    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
                     ColorAdjustType.Default);

                    //原图过小
                    if (markImg.Width > TempWidth || markImg.Height > TempHeight)
                    {
                        System.Drawing.Image.GetThumbnailImageAbort callb = null;
                        //对水印图片生成缩略图,缩小到原图得1/4 
                        System.Drawing.Image new_img = markImg.GetThumbnailImage(TempWidth / 4, markImg.Height * TempWidth / 4 / markImg.Width, callb, new System.IntPtr());

                        //添加水印图片
                        g.DrawImage(new_img, watermark.Position(watermark.Place, new Size(TempWidth, TempHeight), new_img.Size), 0, 0, new_img.Width, new_img.Height, GraphicsUnit.Pixel, imageAttributes);
                        //释放缩略图 
                        new_img.Dispose();
                    }
                    else
                    {
                        //添加水印图片
                        g.DrawImage(markImg, watermark.Position(watermark.Place, new Size(TempWidth, TempHeight), markImg.Size), 0, 0, markImg.Width, markImg.Height, GraphicsUnit.Pixel, imageAttributes);
                    }
                }
            }
            //释放原图对象
            
            xBitmap.Dispose();
            //保存图片
            ImageSave(imagepath,bitmap, xObject);

            g.Dispose();

            bitmap.Dispose();
        }
        
        /// <summary>
        /// 生成缩略图并替换原图
        /// </summary>
        /// <param name="imagepath">原图路径，也是缩略图保存路径</param>
        /// <param name="Width">缩略图的宽</param>
        /// <param name="Height">缩略图的高</param>
        public static void CreateThumbnail(string imagepath, int Width, int Height)
        {
            //获取图片格式
            System.Drawing.Imaging.ImageFormat xObject;
            string ext = EKFileUpload.getExtend(imagepath);
            ext = ext.ToLower();
            switch (ext)
            {
                case ".gif":
                    xObject = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case ".bmp":
                    xObject = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
                case ".png":
                    xObject = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                default:
                    xObject = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
            }
            //获取原图对象
            Bitmap xBitmap = new Bitmap(imagepath);

            //生成缩略图对象
            System.Drawing.Image bitmap;
            System.Drawing.Graphics g;
            CreateThumbnail(Width, Height, xBitmap, out bitmap, out g);
            //释放原图对象
            xBitmap.Dispose();
            //保存缩略图
            ImageSave(imagepath, bitmap, xObject);

            g.Dispose();

            bitmap.Dispose();
        }

        /// <summary>
        /// 生成缩略图对象
        /// </summary>
        /// <param name="Width">缩略图的宽</param>
        /// <param name="Height">缩略图的高</param>
        /// <param name="xBitmap">原图对象</param>
        /// <param name="bitmap">缩略图对象</param>
        /// <param name="g">缩略图画板</param>
        private static void CreateThumbnail(int Width, int Height, Bitmap xBitmap, out System.Drawing.Image bitmap, out System.Drawing.Graphics g)
        {
            int PhotoHeight = xBitmap.Height;
            int PhotoWidth = xBitmap.Width;
            int TempHeight = PhotoHeight;
            int TempWidth = PhotoWidth;
            if (Width != 0 && Height != 0)
            {
                if (PhotoWidth > Width)//图片宽度大于设定宽度
                {
                    TempWidth = Width;
                    TempHeight = PhotoHeight / PhotoWidth * Width;
                    if (TempHeight > Height)
                    {
                        TempWidth = TempWidth / TempHeight * Height;
                        TempHeight = Height;
                    }
                }
                else
                {
                    if (PhotoHeight > Height)
                    {
                        TempHeight = Height;
                        TempWidth = PhotoWidth / PhotoHeight * Height;
                    }
                }
            }
            bitmap = new System.Drawing.Bitmap(TempWidth, TempHeight);
            //新建一个画板   
            g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度   
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //清空一下画布
            g.Clear(Color.Empty);
            //在指定位置画图
            g.DrawImage(xBitmap, new System.Drawing.Rectangle(0, 0, TempWidth, TempHeight), new System.Drawing.Rectangle(0, 0, xBitmap.Width, xBitmap.Height), System.Drawing.GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="imagepath">保存路径</param>
        /// <param name="bitmap">图片内容</param>
        /// <param name="xObject">图片格式</param>
        private static void ImageSave(string imagepath,System.Drawing.Image bitmap, System.Drawing.Imaging.ImageFormat xObject)
        {
            // 以下代码为保存图片时,设置压缩质量
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 255;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            //获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象.
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICI = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.ToLower().Equals("jpeg"))
                {
                    jpegICI = arrayICI[x];
                    //设置JPEG编码
                    break;
                }
            }

            if (jpegICI != null)
            {
                //System.Web.HttpContext.Current.Response.Write("a");
                EKFile.DeleteFile(imagepath);
                EKFileUpload.doCreatrDir(imagepath);
                bitmap.Save(imagepath, jpegICI, encoderParams);
            }
            else
            {
                //System.Web.HttpContext.Current.Response.Write("b");
                EKFile.DeleteFile(imagepath);
                EKFileUpload.doCreatrDir(imagepath);
                bitmap.Save(imagepath, xObject);
            }
        }
    }
    

    /// <summary>
    /// 水印类
    /// </summary>
    public class Watermark
    {
        private string _markType = "";
        private string _text = "";
        private string _imgPath = "";
        private int _markX = 0;
        private int _markY = 0;
        private string _place = "右下";
        private float _transparency = 1;
        private string _fontFamily = "宋体";
        private Color _textColor = Color.Black;
        private bool _textBlod = false;
        private bool _textItalic = false;
        private int _size = 0;

        #region
        //水印类型，text 文字，image 图片
        public string MarkType
        {
            get { return _markType; }
            set { _markType = value; }
        }
        //水印文字
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        //水印图片路径
        public string ImgPath
        {
            get { return _imgPath; }
            set { _imgPath = value; }
        }
        //水印横向坐标
        public int MarkX
        {
            get { return _markX; }
            set { _markX = value; }
        }
        //水印纵向坐标
        public int MarkY
        {
            get { return _markY; }
            set { _markY = value; }
        }
        //透明度
        public float Transparency
        {
            get { return _transparency; }
            set { _transparency = value; }
        }
        //字体
        public string FontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }
        //颜色
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
        //是否加粗
        public bool TextBlod
        {
            get { return _textBlod; }
            set { _textBlod = value; }
        }
        //是否倾斜
        public bool TextItalic
        {
            get { return _textItalic; }
            set { _textItalic = value; }
        }
        //水印文字大小
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        //水印位置
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }
        #endregion

        public Watermark()
        {
        }

        public Watermark(string marktype, string text, string imgpath)
        {
            _markType = marktype;
            _text = text;
            _imgPath = imgpath;
        }

        public Watermark(string marktype, string text, string imgpath, string place, float transparency, string fontfamily, Color textcolor, bool textblod, bool textitalic, int size)
        {
            _markType = marktype;
            _text = text;
            _imgPath = imgpath;
            _place = place;
            _transparency = transparency;
            _fontFamily = fontfamily;
            _textColor = textcolor;
            _textBlod = textblod;
            _textItalic = textitalic;
            _size = size;
        }

        /// <summary>
        /// 将16进制颜色代码转成Color类
        /// </summary>
        /// <param name="color">16进制颜色代码</param>
        /// <returns></returns>
        public Color ToColor(string color)
        {

            int red, green, blue = 0;
            char[] rgb;
            color = color.TrimStart('#');
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            switch (color.Length)
            {
                case 3:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[0].ToString(), 16);
                    green = Convert.ToInt32(rgb[1].ToString() + rgb[1].ToString(), 16);
                    blue = Convert.ToInt32(rgb[2].ToString() + rgb[2].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                case 6:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[1].ToString(), 16);
                    green = Convert.ToInt32(rgb[2].ToString() + rgb[3].ToString(), 16);
                    blue = Convert.ToInt32(rgb[4].ToString() + rgb[5].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                default:
                    return Color.FromName(color);

            }
        }

        /// <summary>
        /// 水印位置
        /// </summary>
        /// <param name="place">水印位置选项</param>
        /// <param name="image">图片大小</param>
        /// <param name="watermark">水印大小</param>
        /// <returns>水印位置坐标</returns>
        public PointF Position(string place, SizeF image, SizeF watermark)
        {
            PointF pointf = new PointF();
            switch (place)
            {
                case "左上":
                    pointf.X = 3;
                    pointf.Y = 3;
                    break;
                case "左下":
                    pointf.X = 3;
                    pointf.Y = image.Height - watermark.Height - 3;
                    break;
                case "居中":
                    pointf.X = (image.Width - watermark.Width) / 2;
                    pointf.Y = (image.Height - watermark.Height) / 2;
                    break;
                case "右上":
                    pointf.X = image.Width - watermark.Width - 3;
                    pointf.Y = 3;
                    break;
                default:
                    pointf.X = image.Width - watermark.Width - 3;
                    pointf.Y = image.Height - watermark.Height - 3;
                    break;
            }
            return pointf;
        }

        /// <summary>
        /// 水印位置
        /// </summary>
        /// <param name="place">水印位置选项</param>
        /// <param name="image">图片大小</param>
        /// <param name="watermark">水印大小</param>
        /// <returns>水印位置及大小</returns>
        public Rectangle Position(string place, Size image, Size watermark)
        {
            Rectangle rectangle = new Rectangle();
            switch (place)
            {
                case "左上":
                    rectangle.Location = new Point(0, 0);
                    break;
                case "左下":
                    rectangle.Location = new Point(0, image.Height - watermark.Height);
                    break;
                case "居中":
                    rectangle.Location = new Point((image.Width - watermark.Width) / 2, (image.Height - watermark.Height) / 2);
                    break;
                case "右上":
                    rectangle.Location = new Point(image.Width - watermark.Width, 0);
                    break;
                default:
                    rectangle.Location = new Point(image.Width - watermark.Width, image.Height - watermark.Height);
                    break;
            }
            rectangle.Size = watermark;
            return rectangle;
        }

    }
}
