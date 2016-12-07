using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Shu.Utility
{
    public class EKGetPage
    {
        /// <summary>
        /// 分页类
        /// </summary>
        public EKGetPage()
        {
        }

        #region  分页字符串1 上一页 1 2 3 4 5 6 7 8 9 下一页

        /// <summary>
        /// 默认样式分页,自动获取参数,默认当前网页地址.
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页大小</param>
        /// <param name="count">总数量</param>
        /// <returns></returns>
        public static string GetPageUrl(int pageIndex, int pageSize, int count)
        {
            string strQuery = EKRequest.RemoveSameParameter("page");//去除参数page
            return GetPageUrl(strQuery, pageIndex, pageSize, count, GetPageName(), PageCss.page1);
        }

        /// <summary>
        /// 默认样式分页,自动获取参数
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页大小</param>
        /// <param name="count">总数量</param>
        /// <param name="url">网址</param>
        /// <returns></returns>
        public static string GetPageUrl(int pageIndex, int pageSize, int count, string url)
        {
            string strQuery = EKRequest.RemoveSameParameter("page");//去除参数page
            return GetPageUrl(strQuery, pageIndex, pageSize, count, url, PageCss.page1);
        }

        /// <summary>
        /// 可更换样式的分页,自动获取参数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <param name="url"></param>
        /// <param name="css"></param>
        /// <returns></returns>
        public static string GetPageUrl(int pageIndex, int pageSize, int count, string url, PageCss css)
        {
            string strQuery = EKRequest.RemoveSameParameter("page");//去除参数page
            return GetPageUrl(strQuery, pageIndex, pageSize, count, url, css);
        }

        /// <summary>
        /// 默认样式分页,样式 class="page1"
        /// </summary>
        /// <param name="strQuery">参数列表,type=1&name=abc</param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetPageUrl(string strQuery, int pageIndex, int pageSize, int count, string url)
        {
            return GetPageUrl(strQuery, pageIndex, pageSize, count, url, PageCss.page1);
        }
        
        /// <summary>
        /// 可更换样式的分页
        /// </summary>
        /// <param name="strQuery">参数列表,type=1&name=abc</param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <param name="url"></param>
        /// <param name="css"></param>
        /// <returns></returns>
        public static string GetPageUrl(string strQuery, int pageindex, int pagesize, int count, string url, PageCss css)
        {
            string cssname = css.ToString();
            int pageCount;//页数
            int pageStart;//分页开始
            int pageEnd;//分页结束

            if (count <= pagesize)
            {
                return "";
            }

            if (count % pagesize == 0)
            {
                pageCount = count / pagesize;
            }
            else
            {
                pageCount = count / pagesize + 1;
            }
            string str;
            pageStart = pageindex / 10 == 0 ? 1 : pageindex / 10 * 10;
            pageEnd = pageindex / 10 == 0 ? 9 : pageindex / 10 * 10 + 9;
            pageEnd = pageEnd > pageCount ? pageCount : pageEnd;
            if (strQuery.Trim().Length > 0)
            {
                strQuery += "&";
            }
            //处理url中自定义添加参数
            if (url.Contains("?"))
            {
                url += "&";
            }
            else
            {
                url += "?";
            }
            str = "<div class=\"" + cssname.ToString() + "\">";

            if (count != 0 && pageindex != 1)
            {
                str += "<span><a href=\"" + url + strQuery + "page=1\" title=\"首 页\" class='pagefirst'>首 页</a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled pagefirst\" title=\"首 页\">首 页</a></span>";
            }

            if (pageindex > 1)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex - 1) + "\" title=\"上一页\" class='pageback'>上一页</a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled pageback\" title=\"上一页\">上一页</a></span>";
            }


            #region 当前页前后5项

            if ((pageindex - 5) > 0)
            {
                str += "<span><a>…</a></span>";
            }
            if ((pageindex - 4) > 0)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex - 4).ToString() + "\">" + (pageindex - 4).ToString() + "</a></span>";
            }
            if ((pageindex - 3) > 0)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex - 3).ToString() + "\">" + (pageindex - 3).ToString() + "</a></span>";
            }
            if ((pageindex - 2) > 0)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex - 2).ToString() + "\">" + (pageindex - 2).ToString() + "</a></span>";
            }
            if ((pageindex - 1) > 0)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex - 1).ToString() + "\">" + (pageindex - 1).ToString() + "</a></span>";
            }

            str += "<span class=\"current\"><a href=\"javascript:void(null)\">" + pageindex.ToString() + "</a></span>";

            if ((pageindex + 1) <= pageCount)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex + 1).ToString() + "\">" + (pageindex + 1).ToString() + "</a></span>";
            }
            if ((pageindex + 2) <= pageCount)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex + 2).ToString() + "\">" + (pageindex + 2).ToString() + "</a></span>";
            }
            if ((pageindex + 3) <= pageCount)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex + 3).ToString() + "\">" + (pageindex + 3).ToString() + "</a></span>";
            }
            if ((pageindex + 4) <= pageCount)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex + 4).ToString() + "\">" + (pageindex + 4).ToString() + "</a></span>";
            }
            if ((pageindex + 5) <= pageCount)
            {
                str += "<span><a>…</a></span>";
            }

            #endregion

            /*
            for (int i = pageStart; i <= pageEnd; i++)
            {
                if (i == pageindex)
                {
                    //当前页样式
                    str += "<span class=\"current\"><a href=\"javascript:void(null)\">" + i.ToString() + "</a></span>";
                }
                else
                {
                    str += "<span><a href=\"" + url + strQuery + "page=" + i.ToString() + "\">" + i.ToString() + "</a></span>";
                }
            }*/

            if (pageindex < pageCount)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex + 1) + "\" title=\"下一页\" class='pagenext'>下一页</a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled pagenext\" title=\"下一页\">下一页</a></span>";
            }

            if (pageindex != pageCount)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + pageCount + "\" title=\"尾 页\" class='pageend'>尾 页</a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled pageend\" title=\"尾 页\">尾 页</a></span>";
            }

            str += "</div>";
            return str;
        }


        /// <summary>
        /// 获取内容详细分页,可更换样式的分页,自动获取参数,无首页,尾页  1 2 3 4 5 6
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <param name="url"></param>
        /// <param name="css"></param>
        /// <returns></returns>
        public static string GetContentPageUrl(int pageindex, int pagesize, int count, string url, PageCss css)
        {
            string strQuery = EKRequest.RemoveSameParameter("page");//去除参数page
            string cssname = css.ToString();
            int pageCount;//页数
            int pageStart;//分页开始
            int pageEnd;//分页结束

            if (count <= pagesize)
            {
                return "";
            }

            if (count % pagesize == 0)
            {
                pageCount = count / pagesize;
            }
            else
            {
                pageCount = count / pagesize + 1;
            }
            string str;
            pageStart = pageindex / 10 == 0 ? 1 : pageindex / 10 * 10;
            pageEnd = pageindex / 10 == 0 ? 9 : pageindex / 10 * 10 + 9;
            pageEnd = pageEnd > pageCount ? pageCount : pageEnd;
            if (strQuery.Trim().Length > 0)
            {
                strQuery += "&";
            }
            //处理url中自定义添加参数
            if (url.Contains("?"))
            {
                url += "&";
            }
            else
            {
                url += "?";
            }
            str = "<div class=\"" + cssname.ToString() + "\">";

            if (pageindex > 1)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex - 1) + "\" title=\"上一页\">< 上一页</a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled\" title=\"上一页\">< 上一页</a></span>";
            }

            for (int i = pageStart; i <= pageEnd; i++)
            {
                if (i == pageindex)
                {
                    //当前页样式
                    str += "<span class=\"current\"><a href=\"javascript:void(null)\">" + i.ToString() + "</a></span>";
                }
                else
                {
                    str += "<span><a href=\"" + url + strQuery + "page=" + i.ToString() + "\">" + i.ToString() + "</a></span>";
                }
            }

            if (pageindex < pageCount)
            {
                str += "<span><a href=\"" + url + strQuery + "page=" + (pageindex + 1) + "\" title=\"下一页\">下一页 ></a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled\" title=\"下一页\">下一页 ></a></span>";
            }

            str += "</div>";
            return str;
        }

        #endregion

        #region 分页字符串2 首页  上一页  下一页  尾页 页次：1/1页  共1条记录 10条记录/页 转到

        /// <summary>
        /// 首页  上一页  下一页  尾页 页次：1/1页  共1条记录 10条记录/页 转到  默认CSS=page2
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetPageUrl2(int pageIndex, int pageSize, int count, string url)
        {
            string strQuery = EKRequest.RemoveSameParameter("page");//去除参数page
            return GetPageUrl2(strQuery, pageIndex, pageSize, count, url);
        }

        /// <summary>
        /// 首页  上一页  下一页  尾页 页次：1/1页  共1条记录 10条记录/页 转到  默认CSS=page2
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetPageUrl2(string strQuery,int pageindex, int pagesize, int count, string url)
        {
            string cssname = " class=\"page2\"";//样式名
            int pageCount;//页数
            int pageStart;//分页开始
            int pageEnd;//分页结束

            if (count <= pagesize)
            {
                return "";
            }

            if (count % pagesize == 0)
            {
                pageCount = count / pagesize;
            }
            else
            {
                pageCount = count / pagesize + 1;
            }
            StringBuilder str = new StringBuilder();
            pageStart = pageindex / 10 == 0 ? 1 : pageindex / 10 * 10;
            pageEnd = pageindex / 10 == 0 ? 9 : pageindex / 10 * 10 + 9;
            pageEnd = pageEnd > pageCount ? pageCount : pageEnd;
            if (strQuery.Trim().Length > 0)
            {
                strQuery += "&";
            }

            str.AppendFormat("<div{0}>", cssname.ToString());

            if (pageindex > 1)
            {
                str.AppendFormat("<span><a href=\"{0}?{1}page=1\" title=\"首页\">首页</a></span>&nbsp;&nbsp;", url, strQuery);
                str.AppendFormat("<span><a href=\"{0}?{1}page={2}\" title=\"上一页\">上一页</a></span>&nbsp;&nbsp;", url, strQuery, (pageindex - 1));
            }
            else
            {
                str.Append("<span style=\"color:#ccc\">首页</span>&nbsp;&nbsp;");
                str.Append("<span style=\"color:#ccc\">上一页</span>&nbsp;&nbsp;");
            }
            if (pageindex < pageCount)
            {
                str.AppendFormat("<span><a href=\"{0}?{1}page={2}\" title=\"下一页\">下一页</a></span>&nbsp;&nbsp;", url, strQuery, (pageindex + 1));
                str.AppendFormat("<span><a href=\"{0}?{1}page={2}\" title=\"尾页\">尾页</a></span>&nbsp;&nbsp;", url, strQuery, pageCount);
            }
            else
            {
                str.Append("<span style=\"color:#ccc\">下一页</span>&nbsp;&nbsp;");
                str.Append("<span style=\"color:#ccc\">尾页</span>&nbsp;&nbsp;");
            }

            str.AppendFormat("页次：{0}/{1}页&nbsp;&nbsp;", pageindex, pageCount);
            str.AppendFormat("共{0}条记录&nbsp;&nbsp;", count);
            str.AppendFormat("{0}条记录/页&nbsp;&nbsp;", pagesize);
            str.AppendFormat("转到：<INPUT maxLength=\"10\" size=\"4\" value=\"{0}\" id=\"page\" name=\"page\">&nbsp;<INPUT type=\"button\" value=\" 确定 \" onclick=\"goto()\">", pageindex);
            str.Append("<script>");
            str.Append("function goto(){");
            str.Append("var page=document.getElementById(\"page\").value;");
            str.AppendFormat("window.location.href=\"{0}?{1}page=\"+page;", url, strQuery);
            str.Append("}");
            str.Append("</script>");
            str.Append("</div>");

            return str.ToString();
        }

        #endregion

        #region 其他

        /// <summary>
        /// 获得当前页面的名称,不包括参数
        /// </summary>
        /// <returns></returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /// <summary>
        /// 获得当前页面的名称,包括参数
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageNameAndQuery()
        {
            string[] urlArr = HttpContext.Current.Request.Url.PathAndQuery.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        #endregion

        /// <summary>
        /// 分页样式
        /// </summary>
        public enum PageCss
        {
            page1,
            page2
        }

        #region 自定义URL地址分页

        /// <summary>
        /// 自定义URL地址多参数分页,样式 class="page1"
        /// </summary>
        /// <param name="pageindex">下标页</param>
        /// <param name="pagesize">页数量</param>
        /// <param name="count">总数量</param>
        /// <param name="ruleStr">规则地址，例: /abc/{0}-{1}/{2}/</param>
        /// <param name="parList">对应规则地址参数,例: "id","classid","page"</param>
        /// <returns></returns>
        public static string GetPageUrlPar(int pageindex, int pagesize, int count, string ruleStr, params object[] parList)
        {
            string cssname = "page1";//样式名
            int pageCount;//页数
            int pageStart;//分页开始
            int pageEnd;//分页结束

            if (count <= pagesize)
            {
                return "";
            }

            if (count % pagesize == 0)
            {
                pageCount = count / pagesize;
            }
            else
            {
                pageCount = count / pagesize + 1;
            }
            string str;
            pageStart = pageindex / 10 == 0 ? 1 : pageindex / 10 * 10;
            pageEnd = pageindex / 10 == 0 ? 9 : pageindex / 10 * 10 + 9;
            pageEnd = pageEnd > pageCount ? pageCount : pageEnd;

            List<string> tempList = new List<string>();
            for (int i = 0; i < parList.Length; i++)
            {
                if (parList[i] == null)
                {
                    continue;
                }

                if (parList[i].ToString() != "page")
                {
                    //中文编码 
                    tempList.Add(HttpUtility.UrlEncode(EKRequest.GetString(parList[i].ToString(), ""), Encoding.GetEncoding("GB2312")));
                    //tempList.Add(System.Web.HttpContext.Current.Server.UrlEncode(EKRequest.GetString(parList[i].ToString(), "")));
                }
                else
                {
                    tempList.Add("{0}");
                }
            }
            object[] tempObj = tempList.ToArray();
            ruleStr = string.Format(ruleStr, tempObj);

            //处理url中自定义添加参数
            str = "<div class=\"" + cssname.ToString() + "\">";

            if (count != 0 && pageindex != 1)
            {
                //str += "<span><a href=\"" + string.Format(ruleStr, "1") + "\" title=\"首 页\" ckass='pagefirst'>首 页</a></span>";
            }
            else
            {
                //str += "<span><a href=\"javascript:void(null)\" class=\"disabled pagefirst\" title=\"首 页\">首 页</a></span>";
            }

            if (pageindex > 1)
            {
                str += "<span><a href=\"" + string.Format(ruleStr, (pageindex - 1)) + "\" title=\"上一页\" class='pageback'>上一页</a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled pageback\" title=\"上一页\">上一页</a></span>";
            }

            for (int i = pageStart; i <= pageEnd; i++)
            {
                if (i == pageindex)
                {
                    //当前页样式
                    str += "<span class=\"current\"><a href=\"javascript:void(null)\">" + i.ToString() + "</a></span>";
                }
                else
                {
                    str += "<span><a href=\"" + string.Format(ruleStr, i.ToString()) + "\">" + i.ToString() + "</a></span>";
                }
            }

            if (pageindex < pageCount)
            {
                str += "<span><a href=\"" + string.Format(ruleStr, (pageindex + 1)) + "\" title=\"下一页\" class='pagenext'>下一页</a></span>";
            }
            else
            {
                str += "<span><a href=\"javascript:void(null)\" class=\"disabled pagenext\" title=\"下一页\">下一页</a></span>";
            }

            if (pageindex != pageCount)
            {
                //str += "<span><a href=\"" + string.Format(ruleStr, pageCount) + "\" title=\"尾 页\" ckass='pageend'>尾 页</a></span>";
            }
            else
            {
                //str += "<span><a href=\"javascript:void(null)\" class=\"disabled pageend\" title=\"尾 页\">尾 页</a></span>";
            }

            str += "</div>";
            return str;
        }


        #endregion

    }
}
