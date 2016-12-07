using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Collections;
using System.Web.Caching;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Shu.Utility;

namespace Shu.BLL
{
    /// <summary>
    /// �ϴ���
    /// </summary>
    public class EKFileUpload
    {
        public static readonly string FilePath = System.Web.HttpContext.Current.Server.MapPath("~/");

        public EKFileUpload()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        #region �ϴ��ļ�

        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="files">FileUpload�ؼ�</param>
        /// <returns></returns>
        public static void FileUpLoad(HttpPostedFile files, ref string filepath)
        {
            //filepath = "";
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                if (!EKFileUpload.CheckExt(ext))
                {
                    EKMessageBox.Show("�ļ��ϴ�ʧ��,�ļ���ʽ�������ϴ���");
                }
                else
                {
                    if (filepath == "")
                    {
                        string FileName = "/" + MS_ConfigBLL.UploadPath + "/" + EKFileUpload.getMyPath() + EKFileUpload.createFileName() + "." + ext;
                        string SaveFile = EKFileUpload.FilePath + FileName;
                        EKFileUpload.doCreatrDir(SaveFile);
                        files.SaveAs(SaveFile);
                        filepath = FileName;
                    }
                    else
                    {
                        string SaveFile = filepath + "\\" + GetFileAllName(files.FileName);
                        files.SaveAs(SaveFile);
                    }
                }
            }
        }

        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="files">FileUpload�ؼ�</param>
        /// <returns></returns>
        public static void FileUpLoad(FileUpload files, ref string filepath)
        {
            //filepath = "";
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                if (!EKFileUpload.CheckExt(ext))
                {
                    EKMessageBox.Show("�ļ��ϴ�ʧ��,�ļ���ʽ�������ϴ���");
                }
                else
                {
                    if (filepath == "")
                    {
                        string FileName = "/" + MS_ConfigBLL.UploadPath + "/" + EKFileUpload.getMyPath() + EKFileUpload.createFileName() + "." + ext;
                        string SaveFile = EKFileUpload.FilePath + FileName;
                        EKFileUpload.doCreatrDir(SaveFile);
                        files.SaveAs(SaveFile);
                        filepath = FileName;
                    }
                    else
                    {
                        string SaveFile = filepath + "\\" + files.FileName;
                        files.SaveAs(SaveFile);
                    }
                    files.Dispose();
                }
            }
        }


        /// <summary>
        /// �ϴ��ļ�.����������
        /// </summary>
        /// <param name="files">FileUpload�ؼ�</param>
        /// <param name="filepath">�ļ�ȫ·��</param>
        /// <returns></returns>
        public static void FileUpLoad2(HttpPostedFile files, ref string filepath)
        {
            //filepath = "";
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                if (!EKFileUpload.CheckExt(ext))
                {
                    EKMessageBox.Show("�ļ��ϴ�ʧ��,�ļ���ʽ�������ϴ���");
                }
                else
                {
                    files.SaveAs(filepath);
                }
            }
        }

        /// <summary>
        /// �ϴ��ļ�,���û�·��
        /// </summary>
        /// <param name="files">FileUpload�ؼ�</param>
        /// <returns></returns>
        public static void FileUpLoadByAdminName(FileUpload files, ref string filepath)
        {
            filepath = "";
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                if (!EKFileUpload.CheckExt(ext)) { EKMessageBox.Show("�ļ��ϴ�ʧ��,��Ϊ�ļ���ʽ�������ϴ���"); }
                else
                {
                    long FLength = files.PostedFile.ContentLength / 1024;
                    if (FLength > MS_ConfigBLL.UploadSize) { EKMessageBox.Show("�ļ��ϴ�ʧ�ܣ���Ϊ�ϴ����ļ�������" + MS_ConfigBLL.UploadSize + "KB��"); }
                    else
                    {
                        string FileName = "/" + MS_ConfigBLL.UploadPath + "/Admin/" + MS_AdminBLL.AdminID + "/" + EKFileUpload.getMyPath() + EKFileUpload.createFileName() + "." + ext;
                        string SaveFile = EKFileUpload.FilePath + FileName;
                        EKFileUpload.doCreatrDir(SaveFile);
                        files.SaveAs(SaveFile);
                        filepath = FileName;
                    }
                }
            }
        }

        #endregion

        #region �ϴ�ͼƬ

        /// <summary>
        /// �ϴ�ͼƬ
        /// </summary>
        /// <param name="files">�ؼ�</param>
        /// <returns></returns>
        public static void ImageUpLoad(HttpPostedFile files, ref string path)
        {
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                ext = ext.ToLower();
                if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "bmp" || ext == "png")
                {
                    long FLength = files.ContentLength / 1024;
                    if (FLength > MS_ConfigBLL.UploadSize)
                    {
                        EKMessageBox.Show("�ļ��ϴ�ʧ�ܣ���Ϊ�ϴ����ļ�������" + MS_ConfigBLL.UploadSize + "KB��");
                    }
                    else
                    {
                        if (path == "")
                        {
                            string createfilename = EKFileUpload.createFileName();
                            string FileName = "/" + MS_ConfigBLL.UploadPath + "/" + EKFileUpload.getMyPath() + createfilename + "." + ext;
                            FileName.Replace("//", "/");
                            string SaveFile = EKFileUpload.FilePath + FileName;
                            EKFileUpload.doCreatrDir(SaveFile);
                            files.SaveAs(SaveFile);
                            path = FileName;
                        }
                        else
                        {
                            string SaveFile = path + "\\" + GetFileAllName(files.FileName);
                            files.SaveAs(SaveFile);
                        }
                    }
                }
                else
                {
                    EKMessageBox.Show("�ļ��ϴ�ʧ��,�ļ���ʽ�������ϴ���");
                    return;
                }
            }
        }

        /// <summary>
        /// �ϴ�ͼƬ
        /// </summary>
        /// <param name="files">FileUpload�ؼ�</param>
        /// <returns></returns>
        public static void ImageUpLoad(FileUpload files, ref string path)
        {
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                ext = ext.ToLower();
                if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "bmp" || ext == "png")
                {
                    long FLength = files.PostedFile.ContentLength / 1024;
                    if (FLength > MS_ConfigBLL.UploadSize)
                    {
                        EKMessageBox.Show("�ļ��ϴ�ʧ�ܣ���Ϊ�ϴ����ļ�������" + MS_ConfigBLL.UploadSize + "KB��");
                    }
                    else
                    {
                        if (path == "")
                        {
                            string createfilename = EKFileUpload.createFileName();
                            string FileName = "/" + MS_ConfigBLL.UploadPath + "/" + path + "/" + EKFileUpload.getMyPath() + createfilename + "." + ext;
                            FileName.Replace("//", "/");
                            string SaveFile = EKFileUpload.FilePath + FileName;
                            EKFileUpload.doCreatrDir(SaveFile);
                            files.SaveAs(SaveFile);
                            path = FileName;
                        }
                        else
                        {
                            string SaveFile = path + "\\" + files.FileName;
                            files.SaveAs(SaveFile);
                        }
                    }
                }
                else
                {
                    EKMessageBox.Show("�ļ��ϴ�ʧ��,�ļ���ʽ�������ϴ���");
                    return;
                }
            }
        }


        /// <summary>
        /// �ϴ�ͼƬ.
        /// </summary>
        /// <param name="files">�ؼ�</param>
        /// <param name="pathurl">����ͼƬȫ·��</param>
        /// <returns></returns>
        public static void ImageUpLoad2(HttpPostedFile files, ref string pathurl)
        {
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                ext = ext.ToLower();
                if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "bmp" || ext == "png")
                {
                    long FLength = files.ContentLength / 1024;
                    if (FLength > MS_ConfigBLL.UploadSize)
                    {
                        EKMessageBox.Show("�ļ��ϴ�ʧ�ܣ���Ϊ�ϴ����ļ�������" + MS_ConfigBLL.UploadSize + "KB��");
                    }
                    else
                    {
                        files.SaveAs(pathurl);
                    }
                }
                else
                {
                    EKMessageBox.Show("�ļ��ϴ�ʧ��,�ļ���ʽ�������ϴ���");
                    return;
                }
            }
        }

        /// <summary>
        /// �ϴ�ͼƬ����������ͼ
        /// </summary>
        /// <param name="files">FileUpload�ؼ�</param>
        /// <returns></returns>
        public static void ImageUpLoad(FileUpload files, Int32 ThumbnailWidth, Int32 ThumbnailHeight, ref string picpath, ref string smallpicpath)
        {
            //System.Drawing.Image xImage;
            System.Drawing.Bitmap xBitmap;
            int PhotoHeight, PhotoWidth;
            //Rectangle NewPhoto;
            System.Drawing.Imaging.ImageFormat xObject;
            string smallFileName = "";
            string smallSaveFile = "";
            picpath = "";
            smallpicpath = "";
            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                ext = ext.ToLower();
                if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "bmp" || ext == "png")
                {
                    long FLength = files.PostedFile.ContentLength / 1024;
                    if (FLength > MS_ConfigBLL.UploadSize)
                    {
                        EKMessageBox.Show("�ļ��ϴ�ʧ�ܣ���Ϊ�ϴ����ļ�������" + MS_ConfigBLL.UploadSize + "KB��");
                    }
                    else
                    {
                        string createfilename = EKFileUpload.createFileName();
                        string FileName = "/" + MS_ConfigBLL.UploadPath + "/" + EKFileUpload.getMyPath() + createfilename + "." + ext;
                        string SaveFile = EKFileUpload.FilePath + FileName;
                        EKFileUpload.doCreatrDir(SaveFile);
                        files.SaveAs(SaveFile);
                        picpath = FileName;

                        smallFileName = "/" + MS_ConfigBLL.UploadPath + "/" + EKFileUpload.getMyPath() + "small" + createfilename + "." + ext;
                        smallSaveFile = EKFileUpload.FilePath + smallFileName;
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

                        xBitmap = new Bitmap(SaveFile);//------------------

                        PhotoHeight = xBitmap.Height;
                        PhotoWidth = xBitmap.Width;
                        Int32 TempHeight = 0;
                        Int32 TempWidth = 0;
                        if (PhotoWidth <= ThumbnailWidth && PhotoHeight <= ThumbnailHeight)
                        {
                            EKFileUpload.doCreatrDir(smallSaveFile);
                            xBitmap.Save(smallSaveFile);
                        }
                        else
                        {
                            if (PhotoWidth > ThumbnailWidth)//ͼƬ��ȴ����趨���
                            {
                                TempWidth = ThumbnailWidth;
                                TempHeight = Convert.ToInt32(Convert.ToDecimal(PhotoHeight) / Convert.ToDecimal(PhotoWidth) * Convert.ToDecimal(ThumbnailWidth));
                                if (TempHeight > ThumbnailHeight)
                                {
                                    TempWidth = Convert.ToInt32(Convert.ToDecimal(TempWidth) / Convert.ToDecimal(TempHeight) * Convert.ToDecimal(ThumbnailHeight));
                                    TempHeight = ThumbnailHeight;
                                }
                            }
                            else
                            {
                                if (PhotoHeight > ThumbnailHeight)
                                {
                                    TempHeight = ThumbnailHeight;
                                    TempWidth = Convert.ToInt32(Convert.ToDecimal(PhotoWidth) / Convert.ToDecimal(PhotoHeight) * Convert.ToDecimal(ThumbnailHeight));
                                }
                            }
                            //System.Web.HttpContext.Current.Response.Write(TempHeight.ToString()+"��");
                            //System.Web.HttpContext.Current.Response.Write(TempWidth.ToString());
                            //System.Web.HttpContext.Current.Response.End();
                            if (TempHeight <= 0)
                            {
                                TempHeight = 1;
                            }
                            if (TempWidth <= 0)
                            {
                                TempWidth = 1;
                            }

                            System.Drawing.Image bitmap = new System.Drawing.Bitmap(TempWidth, TempHeight);
                            //�½�һ������   
                            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                            //���ø�������ֵ��
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            //���ø�����,���ٶȳ���ƽ���̶�   
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            //���һ�»���
                            g.Clear(Color.Empty);
                            //��ָ��λ�û�ͼ   
                            g.DrawImage(xBitmap, new System.Drawing.Rectangle(0, 0, TempWidth, TempHeight), new System.Drawing.Rectangle(1, 1, xBitmap.Width - 1, xBitmap.Height - 1), System.Drawing.GraphicsUnit.Pixel);

                            // ���´���Ϊ����ͼƬʱ,����ѹ������
                            EncoderParameters encoderParams = new EncoderParameters();
                            long[] quality = new long[1];
                            quality[0] = 95;
                            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                            encoderParams.Param[0] = encoderParam;
                            //��ð����й�����ͼ��������������Ϣ��ImageCodecInfo ����.
                            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                            ImageCodecInfo jpegICI = null;
                            for (int x = 0; x < arrayICI.Length; x++)
                            {
                                if (arrayICI[x].FormatDescription.Equals("jpeg"))
                                {
                                    jpegICI = arrayICI[x];
                                    //����JPEG����
                                    break;
                                }
                            }
                            if (jpegICI != null)
                            {
                                //System.Web.HttpContext.Current.Response.Write("a");
                                EKFileUpload.doCreatrDir(smallSaveFile);
                                bitmap.Save(smallSaveFile, jpegICI, encoderParams);
                            }
                            else
                            {
                                //System.Web.HttpContext.Current.Response.Write("b");
                                EKFileUpload.doCreatrDir(smallSaveFile);
                                bitmap.Save(smallSaveFile, xObject);
                            }
                            bitmap.Dispose();
                        }
                        xBitmap.Dispose();
                    }
                    smallpicpath = smallFileName;
                }
                else
                {
                    EKMessageBox.Show("�ļ��ϴ�ʧ��,��Ϊ�ļ���ʽ�������ϴ���");
                    return;
                }
            }
        }

        /// <summary>
        /// �ϴ�����ͼ�����ˮӡ
        /// </summary>
        /// <param name="files">FileUpload�ؼ�</param>
        /// <returns></returns>
        public static void ImageUpLoad(FileUpload files, Int32 Width, Int32 Height, Watermark watermark, ref string picpath)
        {
            //System.Drawing.Image xImage;
            System.Drawing.Bitmap xBitmap;
            int PhotoHeight, PhotoWidth;
            //Rectangle NewPhoto;
            System.Drawing.Imaging.ImageFormat xObject;
            picpath = "";

            if (files.FileName != "")
            {
                string ext = EKFileUpload.getExtend(files.FileName);
                ext = ext.ToLower();
                if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "bmp" || ext == "png")
                {
                    long FLength = files.PostedFile.ContentLength / 1024;
                    if (FLength > MS_ConfigBLL.UploadSize)
                    {
                        EKMessageBox.Show("�ļ��ϴ�ʧ�ܣ���Ϊ�ϴ����ļ�������" + MS_ConfigBLL.UploadSize + "KB��");
                    }
                    else
                    {
                        string createfilename = EKFileUpload.createFileName();
                        string FileName = "/" + MS_ConfigBLL.UploadPath + "/" + EKFileUpload.getMyPath() + createfilename + "." + ext;
                        string SaveFile = EKFileUpload.FilePath + FileName;
                        //EKFileUpload.doCreatrDir(SaveFile);
                        //files.SaveAs(SaveFile);
                        picpath = FileName.Replace("//", "/");

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

                        xBitmap = new Bitmap(files.FileContent);//------------------

                        PhotoHeight = xBitmap.Height;
                        PhotoWidth = xBitmap.Width;
                        Int32 TempHeight = 0;
                        Int32 TempWidth = 0;
                        if (PhotoWidth <= Width && PhotoHeight <= Height)
                        {
                            TempWidth = PhotoWidth;
                            TempHeight = PhotoHeight;
                        }
                        else
                        {
                            if (PhotoWidth > Width)//ͼƬ��ȴ����趨���
                            {
                                TempWidth = Width;
                                TempHeight = Convert.ToInt32(Convert.ToDecimal(PhotoHeight) / Convert.ToDecimal(PhotoWidth) * Convert.ToDecimal(Width));
                                if (TempHeight > Height)
                                {
                                    TempWidth = Convert.ToInt32(Convert.ToDecimal(TempWidth) / Convert.ToDecimal(TempHeight) * Convert.ToDecimal(Height));
                                    TempHeight = Height;
                                }
                            }
                            else
                            {
                                if (PhotoHeight > Height)
                                {
                                    TempHeight = Height;
                                    TempWidth = Convert.ToInt32(Convert.ToDecimal(PhotoWidth) / Convert.ToDecimal(PhotoHeight) * Convert.ToDecimal(Height));
                                }
                            }
                            //System.Web.HttpContext.Current.Response.Write(TempHeight.ToString()+"��");
                            //System.Web.HttpContext.Current.Response.Write(TempWidth.ToString());
                            //System.Web.HttpContext.Current.Response.End();
                            if (TempHeight <= 0)
                            {
                                TempHeight = 1;
                            }
                            if (TempWidth <= 0)
                            {
                                TempWidth = 1;
                            }
                        }

                        System.Drawing.Image bitmap = new System.Drawing.Bitmap(TempWidth, TempHeight);
                        //�½�һ������   
                        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                        //���ø�������ֵ��
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        //���ø�����,���ٶȳ���ƽ���̶�   
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        //���һ�»���
                        g.Clear(Color.Empty);
                        //��ָ��λ�û�ͼ
                        g.DrawImage(xBitmap, new System.Drawing.Rectangle(0, 0, TempWidth, TempHeight), new System.Drawing.Rectangle(1, 1, xBitmap.Width - 1, xBitmap.Height - 1), System.Drawing.GraphicsUnit.Pixel);

                        //���ˮӡ
                        if (watermark != null)
                        {
                            if (watermark.MarkType == "text")
                            {
                                //����������� 
                                Font cFont = null;
                                //��������ˮӡ�ı����ȵó��� 
                                SizeF size = new SizeF();

                                int[] sizes = new int[] { watermark.Size, 48, 32, 16, 8, 6, 4 };

                                //̽���һ���ʺ�ͼƬ��С�������С������Ӧˮӡ���ִ�С������Ӧ 
                                for (int i = 0; i < 7; i++)
                                {
                                    if (sizes[i] == 0)
                                    {
                                        continue;
                                    }
                                    //����һ��������� 
                                    cFont = new Font(watermark.FontFamily, sizes[i], FontStyle.Regular);
                                    //�Ƿ�Ӵ֡���б
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

                                    //�����ı���С 
                                    size = g.MeasureString(watermark.Text, cFont);
                                    //ƥ���һ������Ҫ��������С 
                                    if ((ushort)size.Width < (ushort)TempWidth)
                                    {
                                        break;
                                    }
                                }

                                Brush brush = new SolidBrush(Color.FromArgb(Convert.ToInt32(watermark.Transparency * 255), watermark.TextColor));

                                //���ˮӡ ����
                                g.DrawString(watermark.Text, cFont, brush, watermark.Position(watermark.Place, new SizeF(TempWidth, TempHeight), size));
                            }
                            else if (watermark.MarkType == "image")
                            {
                                //���ˮӡͼ�� 
                                System.Drawing.Image markImg = System.Drawing.Image.FromFile(EKFileUpload.FilePath + watermark.ImgPath);

                                //������ɫ���� 
                                float[][] ptsArray ={  
                                                       new float[] {1, 0, 0, 0, 0}, 
                                                       new float[] {0, 1, 0, 0, 0}, 
                                                       new float[] {0, 0, 1, 0, 0}, 
                                                       new float[] {0, 0, 0, watermark.Transparency, 0}, //ע�⣺�˴�Ϊ0.0fΪ��ȫ͸����1.0fΪ��ȫ��͸�� 
                                                       new float[] {0, 0, 0, 0, 1}};
                                ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
                                //�½�һ��Image���� 
                                ImageAttributes imageAttributes = new ImageAttributes();
                                //����ɫ������ӵ����� 
                                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
                                 ColorAdjustType.Default);

                                //ԭͼ��С
                                if (markImg.Width > TempWidth || markImg.Height > TempHeight)
                                {
                                    System.Drawing.Image.GetThumbnailImageAbort callb = null;
                                    //��ˮӡͼƬ��������ͼ,��С��ԭͼ��1/4 
                                    System.Drawing.Image new_img = markImg.GetThumbnailImage(TempWidth / 4, markImg.Height * TempWidth / 4 / markImg.Width, callb, new System.IntPtr());

                                    //���ˮӡͼƬ
                                    g.DrawImage(new_img, watermark.Position(watermark.Place, new Size(TempWidth, TempHeight), new_img.Size), 0, 0, new_img.Width, new_img.Height, GraphicsUnit.Pixel, imageAttributes);
                                    //�ͷ�����ͼ 
                                    new_img.Dispose();
                                }
                                else
                                {
                                    //���ˮӡͼƬ
                                    g.DrawImage(markImg, watermark.Position(watermark.Place, new Size(TempWidth, TempHeight), markImg.Size), 0, 0, markImg.Width, markImg.Height, GraphicsUnit.Pixel, imageAttributes);
                                }
                            }
                        }

                        // ���´���Ϊ����ͼƬʱ,����ѹ������
                        EncoderParameters encoderParams = new EncoderParameters();
                        long[] quality = new long[1];
                        quality[0] = 95;
                        EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                        encoderParams.Param[0] = encoderParam;
                        //��ð����й�����ͼ��������������Ϣ��ImageCodecInfo ����.
                        ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                        ImageCodecInfo jpegICI = null;
                        for (int x = 0; x < arrayICI.Length; x++)
                        {
                            if (arrayICI[x].FormatDescription.Equals("jpeg"))
                            {
                                jpegICI = arrayICI[x];
                                //����JPEG����
                                break;
                            }
                        }
                        if (jpegICI != null)
                        {
                            //System.Web.HttpContext.Current.Response.Write("a");
                            EKFileUpload.doCreatrDir(SaveFile);
                            bitmap.Save(SaveFile, jpegICI, encoderParams);
                        }
                        else
                        {
                            //System.Web.HttpContext.Current.Response.Write("b");
                            EKFileUpload.doCreatrDir(SaveFile);
                            bitmap.Save(SaveFile, xObject);
                        }
                        g.Dispose();

                        bitmap.Dispose();

                        xBitmap.Dispose();
                    }
                }
                //picpath = FileName;
            }
            else
            {
                EKMessageBox.Show("�ļ��ϴ�ʧ��,��Ϊ�ļ���ʽ�������ϴ���");
                return;
            }
        }

        /// <summary>
        /// ��������ͼ,Ĭ��100*100
        /// </summary>
        /// <param name="sourcePath">Դ·��</param>
        /// <param name="toPath">Ŀ��·��</param>
        /// <returns></returns>
        public static void ImageThumbs(string sourcePath, string toPath)
        {
            string[] strArr = EKFile.AllFiles(sourcePath);
            string fileName = "";

            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].Contains("Thumbs.db"))
                {
                    continue;
                }
                if (!MS_ConfigBLL.UploadImageType.ToLower().Contains(strArr[i].Split('.')[1]))
                {
                    continue;
                }
                fileName = strArr[i].Remove(0, strArr[i].ToLower().LastIndexOf("\\"));
                if (!EKFile.ExistFile(toPath + "\\" + fileName))
                {
                    if (!EKFile.ExistsDirectory(toPath))
                    {
                        EKFile.CreateDirectory(toPath);
                    }
                    ImageUpLoad(strArr[i], toPath + "\\" + fileName, 100, 100);
                }
            }
        }

        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="filePath">Դ·��</param>
        /// <param name="smallSaveFile">Ŀ��·��</param>
        /// <param name="ThumbnailWidth">����ͼ��</param>
        /// <param name="ThumbnailHeight">����ͼ��</param>
        public static void ImageUpLoad(string filePath, string smallSaveFile, Int32 ThumbnailWidth, Int32 ThumbnailHeight)
        {
            System.Drawing.Bitmap xBitmap;
            int PhotoHeight, PhotoWidth;
            System.Drawing.Imaging.ImageFormat xObject;
            if (filePath != "")
            {
                string ext = EKFileUpload.getExtend(filePath);
                ext = ext.ToLower();
                if (ext == "gif" || ext == "jpg" || ext == "jpeg" || ext == "bmp" || ext == "png")
                {
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

                    xBitmap = new Bitmap(filePath);

                    PhotoHeight = xBitmap.Height;
                    PhotoWidth = xBitmap.Width;
                    Int32 TempHeight = 0;
                    Int32 TempWidth = 0;
                    if (PhotoWidth <= ThumbnailWidth && PhotoHeight <= ThumbnailHeight)
                    {
                        EKFileUpload.doCreatrDir(smallSaveFile);
                        xBitmap.Save(smallSaveFile);
                    }
                    else
                    {
                        if (PhotoWidth > ThumbnailWidth)//ͼƬ��ȴ����趨���
                        {
                            TempWidth = ThumbnailWidth;
                            TempHeight = Convert.ToInt32(Convert.ToDecimal(PhotoHeight) / Convert.ToDecimal(PhotoWidth) * Convert.ToDecimal(ThumbnailWidth));
                            if (TempHeight > ThumbnailHeight)
                            {
                                TempWidth = Convert.ToInt32(Convert.ToDecimal(TempWidth) / Convert.ToDecimal(TempHeight) * Convert.ToDecimal(ThumbnailHeight));
                                TempHeight = ThumbnailHeight;
                            }
                        }
                        else
                        {
                            if (PhotoHeight > ThumbnailHeight)
                            {
                                TempHeight = ThumbnailHeight;
                                TempWidth = Convert.ToInt32(Convert.ToDecimal(PhotoWidth) / Convert.ToDecimal(PhotoHeight) * Convert.ToDecimal(ThumbnailHeight));
                            }
                        }
                        if (TempHeight <= 0)
                        {
                            TempHeight = 1;
                        }
                        if (TempWidth <= 0)
                        {
                            TempWidth = 1;
                        }

                        System.Drawing.Image bitmap = new System.Drawing.Bitmap(TempWidth, TempHeight);
                        //�½�һ������   
                        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
                        //���ø�������ֵ��
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        //���ø�����,���ٶȳ���ƽ���̶�   
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        //���һ�»���
                        g.Clear(Color.Empty);
                        //��ָ��λ�û�ͼ   
                        g.DrawImage(xBitmap, new System.Drawing.Rectangle(0, 0, TempWidth, TempHeight), new System.Drawing.Rectangle(1, 1, xBitmap.Width - 1, xBitmap.Height - 1), System.Drawing.GraphicsUnit.Pixel);

                        // ���´���Ϊ����ͼƬʱ,����ѹ������
                        EncoderParameters encoderParams = new EncoderParameters();
                        long[] quality = new long[1];
                        quality[0] = 80;
                        EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                        encoderParams.Param[0] = encoderParam;
                        //��ð����й�����ͼ��������������Ϣ��ImageCodecInfo ����.
                        ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                        ImageCodecInfo jpegICI = null;
                        for (int x = 0; x < arrayICI.Length; x++)
                        {
                            if (arrayICI[x].FormatDescription.Equals("jpeg"))
                            {
                                jpegICI = arrayICI[x];
                                //����JPEG����
                                break;
                            }
                        }
                        if (jpegICI != null)
                        {
                            //System.Web.HttpContext.Current.Response.Write("a");
                            EKFileUpload.doCreatrDir(smallSaveFile);
                            bitmap.Save(smallSaveFile, jpegICI, encoderParams);
                        }
                        else
                        {
                            //System.Web.HttpContext.Current.Response.Write("b");
                            EKFileUpload.doCreatrDir(smallSaveFile);
                            xBitmap.Dispose();
                            bitmap.Save(smallSaveFile, xObject);
                        }
                        bitmap.Dispose();
                    }
                    xBitmap.Dispose();
                }
                else
                {
                    //��ʽ����
                }
            }
        }

        #endregion
                
        /// <summary>
        /// ѡ����ʾ��ͬ��С��ͼƬ
        /// </summary>
        /// <param name="originalPath">ԭͼ·��</param>
        /// <param name="nullPath">null</param>
        /// <param name="size">ͼƬ�ߴ磺��large����middle��Сsmall</param>
        /// <returns></returns>
        public static string ShowPicture(string originalPath, string nullPath, PictureSize size)
        {
            string path = originalPath == "" ? nullPath : originalPath;

            switch (Convert.ToInt32(size))
            {
                case 1:
                    path = path.Insert(path.LastIndexOf('.'), "mid");
                    break;
                case 0:
                    path = path.Insert(path.LastIndexOf('.'), "small");
                    break;
                default:
                    break;
            }
            return path;
        }
        public static string ShowPicture(string originalPath, PictureSize size)
        {
            if (originalPath == "")
            {
                return "";
            }
            string path = originalPath;
            switch (Convert.ToInt32(size))
            {
                case 1:
                    path = path.Insert(path.LastIndexOf('.'), "mid");
                    break;
                case 0:
                    path = path.Insert(path.LastIndexOf('.'), "small");
                    break;
                default:
                    break;
            }
            return path;
        }

        public enum PictureSize
        {
            Large = 2, Middle = 1, Small = 0
        }

        #region �ļ���������

        /// <summary>
        /// ���������ļ�
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="str"></param>
        public static void doCreatrFile(string dirName, string str)
        {
            EKFileUpload.doCreatrDir(dirName);
            StreamWriter sw = new StreamWriter(dirName, false, System.Text.Encoding.GetEncoding("gb2312"));
            sw.WriteLine(str);
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// �����ļ���
        /// </summary>
        /// <param name="dirName"></param>
        public static void doCreatrDir(string dirName)
        {
            string[] adir = dirName.Split("/".ToCharArray());
            string DirFile = adir[0];
            for (int i = 1; i < adir.Length - 1; i++)
            {
                DirFile += "/" + adir[i];
                if (!Directory.Exists(DirFile))
                {
                    Directory.CreateDirectory(DirFile);

                }
            }
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        /// <summary>
        /// ��ȡ�ļ�������������׺
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string GetFileName(string pStr)
        {
            string strTemp = GetFileAllName(pStr);
            if(strTemp.Contains(".")){
                strTemp=strTemp.Remove(strTemp.IndexOf("."));
            }
            return strTemp;
        }

        /// <summary>
        /// ��ȡ�ļ�ȫ����������׺��
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string GetFileAllName(string pStr)
        {
            if (pStr.Contains("\\"))
            {
                pStr = pStr.Replace("\\", "/");
            }
            string[] urlArr = pStr.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// ȡ��չ��
        /// </summary>
        /// <param name="pStr"></param>
        /// <returns></returns>
        public static string getExtend(string pStr)
        {
            string[] str = pStr.Split(".".ToCharArray());
            return str[str.Length - 1];
        }

        /// <summary>
        /// ����ϴ��ļ���׺
        /// </summary>
        /// <param name="ext"></param>
        public static bool CheckExt(string ext)
        {
            ext = ext.ToUpper();
            string str = MS_ConfigBLL.UploadType.ToUpper();
            bool checkExt = false;
            string[] strArr = str.Split("|".ToCharArray());
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr.Length > 0)
                {
                    if (ext == strArr[i]) { checkExt = true; }
                }
            }
            return checkExt;
        }

        /// <summary>
        /// ����һ���ļ���
        /// </summary>
        /// <returns></returns>
        public static string createFileName()
        {
            DateTime dt = DateTime.Now;
            return dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + dt.Millisecond.ToString();
        }

        ///// <summary>
        ///// �Զ������ļ���
        ///// </summary>
        ///// <returns></returns>
        //public static string getMyPath()
        //{
        //    return DateTime.Now.Year.ToString() +"/"+ DateTime.Now.Month +"/"+ DateTime.Now.Day + "/";
        //}

        /// <summary>
        /// �Զ������ļ���
        /// </summary>
        /// <returns></returns>
        public static string getMyPath()
        {
            return DateTime.Now.ToString("yyyyMMdd") + "/";
        }

        /// <summary>
        /// ��ȡ�ļ�  ,5��14�� �޸ĳɷ���Cache��
        /// </summary>
        /// <returns></returns>
        public static string ReadFile(string dirName)
        {
            try
            {
                string Apc = System.Web.HttpContext.Current.Cache["File" + dirName] == null ? "" : System.Web.HttpContext.Current.Cache["File" + dirName].ToString();
                if (Apc == "")
                {
                    StreamReader reader = new StreamReader(dirName, System.Text.Encoding.GetEncoding("GB2312"));
                    string content = reader.ReadToEnd();
                    reader.Close();
                    reader.Dispose();
                    System.Web.HttpContext.Current.Cache.Insert("File" + dirName, content, null, DateTime.Now.AddDays(1d),
                    System.Web.Caching.Cache.NoSlidingExpiration);
                    //System.Web.HttpContext.Current.Application.Lock();
                    //System.Web.HttpContext.Current.Application["File" + dirName] = content;
                    //System.Web.HttpContext.Current.Application.UnLock();
                    return content;
                }
                else
                {
                    return Apc;
                }
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// EncodeBase64
        /// </summary>
        public static string EncodeBase64(string code)
        {
            string encode = "";
            byte[] bytes = System.Text.Encoding.GetEncoding("GB2312").GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }

        /// <summary>
        /// DecodeBase64
        /// </summary>
        public static string DecodeBase64(string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = System.Text.Encoding.GetEncoding("GB2312").GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }


        #endregion


        /// <summary>
        /// ��������Ŀ¼������ͼƬ����ͼ
        /// </summary>
        /// <param name="spath">ȫ�ļ�·��</param>
        /// <param name="isChild">��Ŀ¼�Ƿ�����</param>
        public static void CreateSImg(string spath, bool isChild)
        {
            DirectoryInfo[] ChildDirectory;//��Ŀ¼��
            FileInfo[] NewFileInfo;//��ǰ�����ļ�
            string path = spath;
            DirectoryInfo FatherDirectory = new DirectoryInfo(path); //��ǰĿ¼
            ChildDirectory = FatherDirectory.GetDirectories("*.*"); //�õ���Ŀ¼��

            //��Ŀ¼�ļ�
            NewFileInfo = FatherDirectory.GetFiles();
            foreach (FileInfo DirFile in NewFileInfo)//��ȡ�˼�Ŀ¼�µ������ļ�
            {
                if (!DirFile.FullName.ToLower().EndsWith(".jpg") && !DirFile.FullName.ToLower().EndsWith(".png") && !DirFile.FullName.ToLower().EndsWith(".gif") && !DirFile.FullName.ToLower().EndsWith(".ico") && !DirFile.FullName.ToLower().EndsWith(".bmp"))
                {
                    //���� ͼƬ ���ء�
                    continue;
                }
                string sfile = "";//С
                string mfile = "";//��

                sfile = DirFile.FullName.ToLower().Replace(EKFile.GetMapPath("/" + MS_ConfigBLL.UploadPath).ToLower(), EKFile.GetMapPath("/") + "/" + MS_ConfigBLL.UploadPath_X + "/" + MS_ConfigBLL.UploadPath);
                mfile = DirFile.FullName.ToLower().Replace(EKFile.GetMapPath("/" + MS_ConfigBLL.UploadPath).ToLower(), EKFile.GetMapPath("/") + "/" + MS_ConfigBLL.UploadPath_Z + "/" + MS_ConfigBLL.UploadPath);

                EKFile.CreateDirectory(mfile.Remove(mfile.LastIndexOf("\\")));
                EKFile.CreateDirectory(sfile.Remove(sfile.LastIndexOf("\\")));

                try
                {
                    if (DirFile.FullName.ToLower().EndsWith(".gif") || DirFile.FullName.ToLower().EndsWith(".ico"))
                    {
                        //gif�ᶯ��������ico ������
                        EKFile.CopyFile(DirFile.FullName, sfile);
                        EKFile.CopyFile(DirFile.FullName, mfile);
                    }
                    else
                    {
                        if (!File.Exists(sfile))
                        {
                            EKFileUpload.ImageUpLoad(DirFile.FullName, sfile, 150, 150);
                        }
                        if (!File.Exists(mfile))
                        {
                            EKFileUpload.ImageUpLoad(DirFile.FullName, mfile, 500, 500);
                        }
                    }
                }
                catch
                {
                    //m_new.NewsTitle = DirFile.FullName + "-----" + zfile;
                    //b_new.Add(m_new);
                    continue;
                }
            }

            //��Ŀ¼�Ƿ�����
            if (isChild)
            {
                foreach (DirectoryInfo dirInfo in ChildDirectory)//Ŀ¼
                {
                    if (dirInfo.Attributes.ToString().Contains("Hidden"))
                    {
                        continue;
                    }
                    CreateSImg(dirInfo.FullName, isChild);
                }
            }
        }

        /// <summary>
        /// ��������Ŀ¼������ͼƬ����ͼ
        /// </summary>
        /// <param name="spath"></param>
        public static void CreateSImg(string spath)
        {
            CreateSImg(spath, true);
        }

    }
}
