using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Data;
using Shu.Utility;

namespace Shu.BLL
{
    /// <summary>
    /// 操作HTML内容类
    /// </summary>
    public class EKHtml
    {

        public EKHtml()
        {
        }

        #region 图片操作


        /// <summary>
        /// 获取代码中,第一张图片路径.
        /// </summary>
        /// <param name="html">代码</param>
        /// <returns></returns>
        public static string GetHtmlFirstImgUrl(string html)
        {
            MatchCollection mc = Regex.Matches(html, "<img.+?src=\"(?<url>.+?)\".+?>", RegexOptions.IgnoreCase);
            if (mc.Count == 0)
            {
                return "";
            }
            return mc[0].Groups["url"].Value;
        }

        /// <summary>
        /// 获取代码中,第一张图片路径.
        /// </summary>
        /// <param name="html">代码</param>
        /// <param name="defaultStr">默认值</param>
        /// <returns></returns>
        public static string GetHtmlFirstImgUrl(string html, string defaultStr)
        {
            MatchCollection mc = Regex.Matches(html, "<img.+?src=\"(?<url>.+?)\".+?>", RegexOptions.IgnoreCase);
            if (mc.Count == 0)
            {
                return defaultStr;
            }
            return mc[0].Groups["url"].Value;
        }

        /// <summary>
        /// 获取代码中,多张图片路径.返回格式: 路径1|路径2|路径3
        /// </summary>
        /// <param name="html">代码</param>
        /// <param name="defaultStr">默认值</param>
        /// <returns></returns>
        public static string GetHtmlImgUrls(string html, string defaultStr)
        {
            MatchCollection mc = Regex.Matches(html, "<img.+?src=\"(?<url>.+?)\".+?>", RegexOptions.IgnoreCase);
            if (mc.Count == 0)
            {
                return defaultStr;
            }

            string strTemp = "";
            foreach (Match match in mc)
            {
                strTemp += match.Groups["url"].Value + "|";
            }
            return EKGetString.RemoveEnd(strTemp, "|");
        }

        /// <summary>
        /// 第一张图片加链接，链接到指定页
        /// </summary>
        /// <param name="html">html代码</param>
        /// <param name="urlLink">指定页面链接</param>
        /// <returns></returns>
        public static string AddHtmlFirstImgLink(string html, string urlLink)
        {
            MatchCollection mc = Regex.Matches(html, "<img.+?src=\"(?<url>.+?)\".+?>", RegexOptions.IgnoreCase);
            if (mc.Count == 0)
            {
                return html;
            }

            html = html.Replace(mc[0].Value, "<a href=\"" + urlLink + "\">" + mc[0].Value + "</a>");

            return html;
        }

        #endregion

        #region 内容操作

        /// <summary>
        /// 保存远程图片,替换图片链接为本地,返回替换后内容
        /// </summary>
        /// <param name="html">html代码</param>
        /// <returns></returns>
        public static string SaveImage(string html)
        {
            return SaveImage(html, DateTime.Now, "");
        }

        /// <summary>
        /// 保存远程图片,替换图片链接为本地,返回替换后内容
        /// </summary>
        /// <param name="html">html代码</param>
        /// <param name="webRoot">补全图片访问域名。 例：http://www.abc.com</param>
        /// <returns></returns>
        public static string SaveImage(string html, string webRoot)
        {
            return SaveImage(html, DateTime.Now, webRoot);
        }

        /// <summary>
        /// 保存远程图片,替换图片链接为本地,返回替换后内容
        /// </summary>
        /// <param name="html">html代码</param>
        /// <param name="dt">生成时间</param>
        /// <param name="webRoot">补全图片访问域名。 例：http://www.abc.com</param>
        /// <returns></returns>
        public static string SaveImage(string html, DateTime dt, string webRoot)
        {
            return SaveImage(html, dt, "", webRoot);
        }

        /// <summary>
        /// 保存远程图片,替换图片链接为本地,返回替换后内容
        /// </summary>
        /// <param name="html">html代码</param>
        /// <param name="dt">生成时间</param>
        /// <param name="reg">图片正则表达式</param>
        /// <param name="webRoot">补全图片访问域名。 例：http://www.abc.com</param>
        /// <returns></returns>
        public static string SaveImage(string html,DateTime dt,string reg, string webRoot)
        {
            System.Net.WebClient WC = new System.Net.WebClient();

            //是否保存远程图片
            if (1 == 1)
            {
                //<img.+?src=\"(?<url>.+?)\".+?>
                string reg_img = "<img.+?src=\"(?<url>.+?)\".+?>";
                if (reg != "")
                {
                    reg_img = reg;
                }
                MatchCollection mc = Regex.Matches(html, reg_img, RegexOptions.IgnoreCase);

                string imgUrl = "";
                string imgfix = "jpg";
                //格式 盘：/UploadPath/webfile/201001/01/
                string savePath = "/" + MS_ConfigBLL.UploadPath + "/" + "webfile/" + dt.ToString("yyyyMM") + "/" + dt.ToString("dd") + "/";
                //格式 时分秒毫秒
                string imgName = "";
                string imgNewUrl = "";
                foreach (Match math in mc)
                {
                    imgName = DateTime.Now.ToString("HHmmssfff");
                    imgUrl = math.Groups["url"].Value;
                    if (imgUrl.StartsWith("http://") || imgUrl.StartsWith("https://") || imgUrl.StartsWith("www."))
                    {
                        Uri uri = new Uri(imgUrl);
                        if (EKFile.ExistFile(EKFile.GetMapPath(uri.AbsolutePath)))
                        {
                            //本地存在，下次循环
                            continue;
                        }

                        //后缀
                        string[] tempAry = imgUrl.Split('.');
                        if (tempAry.Length > 0)
                        {
                            imgfix = tempAry[tempAry.Length - 1];
                        }

                        imgNewUrl = savePath + imgName + "." + imgfix;
                        if (!EKFile.ExistsDirectory(EKFile.GetMapPath("/") + savePath))
                        {
                            EKFile.CreateDirectory(EKFile.GetMapPath("/") + savePath);
                        }

                        try
                        {
                            WC.DownloadFile(imgUrl, EKFile.GetMapPath("/") + imgNewUrl);
                            WC.Dispose();
                            //保存成功，则替换内容中图片链接
                            html = html.Replace(imgUrl, webRoot + imgNewUrl);
                        }
                        catch (Exception err)
                        {
                            new MS_LogBLL().AddLogAdmin(MS_LogBLL.LogLevel.ERROR, "保存远程图片错误" + err.Message);
                            return html;
                        }
                    }
                }
            }

            return html;
        }

        /// <summary>
        /// 图片添加绝对地址．补全地址 src="/img/abc.jpg" 转成 src="http://www.abc.com/img/abc.jpg"
        /// </summary>
        /// <param name="html">HTML源代码</param>
        /// <param name="webRoot">补全图片访问域名。 例：http://www.abc.com</param>
        /// <returns></returns>
        public static string ImageWebRoot(string html, string webRoot)
        {
            return ImageWebRoot(html, webRoot, "");
        }

        /// <summary>
        /// 图片添加绝对地址．补全地址 src="/img/abc.jpg" 转成 src="http://www.abc.com/img/abc.jpg"
        /// </summary>
        /// <param name="html">HTML源代码</param>
        /// <param name="webRoot">补全图片访问域名。 例：http://www.abc.com</param>
        /// <param name="reg">图片正则表达式</param>
        /// <returns></returns>
        public static string ImageWebRoot(string html, string webRoot,string reg)
        {
            //<img[\\s\\S]+?src=\"(?<url>.+?)\".+?>
            //<img.+?src=\"(?<url>.+?)\".+?>
            //<img[\s\S]+?src=\"(?<url>.+?)\">
            string reg_img = "<img.+?src=\"(?<url>.+?)\".+?>";
            if (reg != "")
            {
                reg_img = reg;
            }
            MatchCollection mc = Regex.Matches(html, reg_img, RegexOptions.IgnoreCase);
            //格式 时分秒毫秒
            string imgUrl = "";
            List<string> imgUrlList = new List<string>();
            foreach (Match math in mc)
            {
                imgUrl = math.Groups["url"].Value;
                //已经替换过相同的图片.不做处理
                if (!imgUrlList.Contains(imgUrl))
                {
                    if (imgUrl.StartsWith("http://") || imgUrl.StartsWith("https://") || imgUrl.StartsWith("www."))
                    {
                        //已存在，不处理
                    }
                    else
                    {
                        html = html.Replace(imgUrl, webRoot + imgUrl);
                        imgUrlList.Add(imgUrl);
                    }
                }
            }
            return html;
        }

        /// <summary>
        /// 去除A标签。不包括标签里内容。
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RemoveA(string html)
        {
            //去掉a标签 @"<a[^>]*?>.*?</a>"
            html = Regex.Replace(html, @"<a[^>]*?>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</a>", "", RegexOptions.IgnoreCase);
            return html;

            /*
            //去掉font标签
            html = Regex.Replace(html, @"<font[^>]*?>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</font>", "", RegexOptions.IgnoreCase);
             */
        }

        /// <summary>
        /// 去除指定标签。不包括标签里内容。
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RemoveLabel(string html, string label)
        {
            //去掉a标签 @"<a[^>]*?>.*?</a>"
            html = Regex.Replace(html, @"<" + label + "[^>]*?>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</" + label + ">", "", RegexOptions.IgnoreCase);
            return html;
        }

        //    //内容分页
        //    string separator = "<div style=\"page-break-after: always\">\r\n\t<span style=\"display: none\">&nbsp;</span></div>";
        //    string[] contentAry = m_contents[0].Content.Split(new[] { separator }, StringSplitOptions.None);
        //    //查找其他类型内容分页符
        //    if (contentAry.Length == 1)
        //    {
        //        separator = "<div style=\"page-break-after: always\"><span style=\"display: none\">&nbsp;</span></div>";
        //        contentAry = m_contents[j - 1].Content.Split(new[] { separator }, StringSplitOptions.None);
        //    }

        #endregion

    }
}
