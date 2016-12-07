using System;
using System.Web;

namespace Shu.Utility
{
    /// <summary>
    /// Request操作类
    /// </summary>
    public class EKRequest
    {
        /// <summary>
        /// 获取请求对象
        /// </summary>
        /// <returns></returns>
        public static HttpRequest Request
        {
            get
            {
                return System.Web.HttpContext.Current.Request;
            }
        }

        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// 返回上一个页面的地址
        /// </summary>
        /// <returns>上一个页面的地址</returns>
        public static string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
            {
                return "";
            }

            return FilterKey(retVal);

        }

        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }

        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// 获取主域名
        /// </summary>
        /// <returns></returns>
        public static string GetDoMain()
        {
            string host = HttpContext.Current.Request.Url.Host;
            if (host.Split('.').Length > 2)
            {
                host = host.Remove(0, host.IndexOf(".") + 1);
            }
            return host;
        }

        /// <summary>
        /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
        /// </summary>
        /// <returns>原始 URL</returns>
        public static string GetRawUrl()
        {
            return FilterKey(StrEncode(HttpContext.Current.Request.RawUrl));
        }

        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// </summary>
        /// <returns>是否来自搜索引擎链接</returns>
        public static bool IsSearchEnginesGet()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
            {
                return false;
            }
            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获得当前完整Url地址
        /// </summary>
        /// <returns>当前完整Url地址</returns>
        public static string GetUrl()
        {
            return FilterKey(HttpContext.Current.Request.Url.ToString());
            //return System.Web.HttpContext.Current.Server.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// 获得当前Url地址参数列表字符串，不包含'?'号
        /// </summary>
        /// <returns>当前完整Url地址</returns>
        public static string GetUrlParameterList()
        {
            string[] urlArr = HttpContext.Current.Request.Url.Query.Split('?');
            return FilterKey(urlArr[urlArr.Length - 1]);
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }

            //string q = HttpContext.Current.Request.Url.Query;
            System.Collections.Specialized.NameValueCollection nv = System.Web.HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query, System.Text.Encoding.GetEncoding("utf-8"));
            return FilterKey(nv[strName]);

            //System.Collections.Specialized.NameValueCollection nv = System.Web.HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query);
            //return nv[strName];
            //return HttpContext.Current.Request.QueryString[strName];
        }

        /// <summary>
        /// 获得当前页面的名称,不包括参数
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1];
        }

        /// <summary>
        /// 获得当前页面的名称,包括参数
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageNameAndQuery()
        {
            string[] urlArr = HttpContext.Current.Request.Url.PathAndQuery.Split('/');
            return FilterKey(urlArr[urlArr.Length - 1]);
        }


        /// <summary>
        /// 获取上次请求的路径与参数
        /// </summary>
        /// <returns></returns>
        public static string GetReferrerPathAndQuery()
        {
            return FilterKey(HttpContext.Current.Request.UrlReferrer.PathAndQuery);
        }

        /// <summary>
        /// 获得当前页面的名称,包括参数
        /// </summary>
        /// <returns>当前页面全名</returns>
        public static string GetPageAllName()
        {
            return FilterKey(HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// 返回表单和Url参数的总个数
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            else
            {
                return GetQueryString(strName);
            }
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <param name="dufault">默认值</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName, string val)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                if (GetFormString(strName) == "")
                {
                    return val;
                }
                else
                {
                    return GetFormString(strName);
                }
            }
            else
            {
                if (GetQueryString(strName) == "")
                {
                    return val;
                }
                else
                {
                    return GetQueryString(strName);
                }
            }
        }

        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <param name="dufault">默认值</param>
        /// <returns>Url或表单参数的值</returns>
        public static int GetString(string strName, int val)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                if (GetFormString(strName) == "")
                {
                    return val;
                }
                else
                {
                    try
                    {
                        val = Convert.ToInt32(GetFormString(strName));
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                if (GetQueryString(strName) == "")
                {
                    return val;
                }
                else
                {
                    try
                    {
                        val = Convert.ToInt32(GetQueryString(strName));
                    }
                    catch
                    {
                    }
                }
            }
            return val;
        }

        /// <summary>
        /// 获得指定Url参数的int类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return EKTypeParse.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// 获得指定表单参数的int类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的int类型值</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return EKTypeParse.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的int类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            else
            {
                return GetQueryInt(strName, defValue);
            }
        }

        /// <summary>
        /// 获得指定Url参数的float类型值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url参数的int类型值</returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return EKTypeParse.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// 获得指定表单参数的float类型值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>表单参数的float类型值</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return EKTypeParse.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 获得指定Url或表单参数的float类型值, 先判断Url参数是否为缺省值, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">Url或表单参数</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>Url或表单参数的int类型值</returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            else
            {
                return GetQueryFloat(strName, defValue);
            }
        }

        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (string.IsNullOrEmpty(result) || !EKValidate.IsIP(result))
            {
                return "127.0.0.1";
            }

            return result;

        }

        /// <summary>
        /// 是否本站提交
        /// </summary>
        /// <returns></returns>
        public static bool IsLocalPost()
        {
            string met = HttpContext.Current.Request.ServerVariables["Request_Method"];
            if (met == "POST")
            {
                if (HttpContext.Current.Request.UrlReferrer == null)
                {
                    return true;
                }
                else
                {
                    string host = HttpContext.Current.Request.Url.Host;
                    string url = HttpContext.Current.Request.UrlReferrer.DnsSafeHost;
                    if (url.IndexOf(host) != -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 删除当前请求中的重复的参数,删除指定参数(多个使用,号格开),并返回删除后参数列表
        /// </summary>
        /// <param name="parame">参数键名,多个用逗号格开</param>
        /// <returns></returns>
        public static string RemoveSameParameter(string parameter)
        {
            string strParam = "";
            bool isExist = false;
            for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
            {
                for (int j = 0; j < HttpContext.Current.Request.QueryString.Count; j++)
                {
                    if (HttpContext.Current.Request.QueryString.GetKey(i) == null || HttpContext.Current.Request.QueryString.GetKey(j) == null)
                    {
                        break;
                    }

                    if (i != j && HttpContext.Current.Request.QueryString.GetKey(i).ToLower() == HttpContext.Current.Request.QueryString.GetKey(j).ToLower())
                    {
                        isExist = true;
                        break;
                    }
                }

                //多参数
                string[] strAry = parameter.ToLower().Split(',');
                bool isParam = false;
                for (int k = 0; k < strAry.Length; k++)
                {
                    if (HttpContext.Current.Request.QueryString.GetKey(i) == null || strAry[k] == null)
                    {
                        break;
                    }

                    if (HttpContext.Current.Request.QueryString.GetKey(i).ToLower() == strAry[k])
                    {
                        isParam = true;
                        break;
                    }
                }

                //是否存在重复,是否存在 要删除中的一个.为了不重复添加,判断strParam中是否已经存在相同键 "?键=" 或 "&键="
                if (!isExist && HttpContext.Current.Request.QueryString.GetKey(i) != null && !isParam)
                {
                    strParam += "&" + HttpContext.Current.Request.QueryString.GetKey(i) + "=" + EKRequest.StrEncode(HttpContext.Current.Request.QueryString.Get(i),"utf-8");
                }
            }
            if (strParam.Contains("&"))
            {
                strParam = strParam.Remove(0, 1);
            }
            return FilterKey(strParam);
        }

        /// <summary>
        /// 删除当前请求中的重复的参数,并返回删除后参数列表
        /// </summary>
        /// <returns></returns>
        public static string RemoveSameParameter()
        {
            return RemoveSameParameter("");
        }

        /// <summary>
        /// 重新定向页面，返回删除参数后的页面地址
        /// </summary>
        /// <param name="par">参数键名,多个用逗号格开</param>
        /// <returns></returns>
        public static string RePage(string par)
        {
            return EKRequest.GetPageName() + "?" + EKRequest.RemoveSameParameter(par);
        }


        /// <summary>
        /// 当前页面编码
        /// </summary>
        /// <returns></returns>
        public static string GetUrlEncode()
        {
            return FilterKey(System.Web.HttpContext.Current.Server.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()));
        }

        /// <summary>
        /// 当前页面解码
        /// </summary>
        /// <returns></returns>
        public static string GetUrlDecode()
        {
            return System.Web.HttpContext.Current.Server.UrlDecode(System.Web.HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// 字符串编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrEncode(string str)
        {
            return StrEncode(str, "utf-8");
        }

        /// <summary>
        /// 字符串编码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string StrEncode(string str,string encoding)
        {
            return FilterKey(System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding(encoding)).Replace("+", "%20"));
        }

        /// <summary>
        /// 字符串解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrDecode(string str)
        {
            return StrDecode(str, "utf-8");
        }

        /// <summary>
        /// 字符串解码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string StrDecode(string str, string encoding)
        {
            return System.Web.HttpUtility.UrlDecode(str, System.Text.Encoding.GetEncoding(encoding));
        }

        /// <summary>
        /// 地址，路径编码，排除 / // \ \\等编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrEncodeUrl(string str)
        {
            return StrEncodeUrl(str, "utf-8");
        }

        /// <summary>
        /// 地址，路径编码，排除 / // \ \\等编码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string StrEncodeUrl(string str, string encoding)
        {
            if (str == null)
            {
                return "";
            }
            char tempStr = ' ';
            string tempStr2 = "";
            string returnStr = "";
            char[] ary = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                tempStr = ary[i];
                //过滤特别字符
                if (!EKGetString.IsExist(":,?,&,/,//,///,////,\\,\\\\,\\/,/\\", ',', tempStr.ToString()))
                {
                    tempStr2 = EKRequest.StrEncode(tempStr.ToString(), encoding);
                }
                else
                {
                    tempStr2 = tempStr.ToString();
                }
                //新编码字符串
                returnStr += tempStr2;
            }
            return returnStr.Replace("+", "%20");
        }

        /// <summary>
        /// 转义敏感字符
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string FilterKey(string url)
        {
            if (url == null)
            {
                return null;
            }

            url = url.Replace("<", "&lt;");
            url = url.Replace(">", "&gt;");
            url = url.Replace("\"", "&quot;");
            url = url.Replace("\\", "&#39;");

            //url = url.Replace("%", "&#37;");
            //url = url.Replace(";", "&#59;");
            url = url.Replace("(", "&#40;");
            url = url.Replace(")", "&#41;");

            //url = url.Replace("&", "&amp;");
            //url = url.Replace("+", "&#43;");

            return url;
        }

        /// <summary>
        /// 还原转义敏感字符
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string FilterKeyReverse(string url)
        {
            if (url == null)
            {
                return null;
            }

            url = url.Replace("&lt;", "<");
            url = url.Replace("&gt;", ">");
            url = url.Replace("&quot;", "\"");
            url = url.Replace("&#39;", "\\");

            //url = url.Replace("%", "&#37;");
            //url = url.Replace(";", "&#59;");
            url = url.Replace("&#40;", "(");
            url = url.Replace("&#41;", ")");

            //url = url.Replace("&amp;", "&");
            //url = url.Replace("&#43;", "+");

            return url;
        }
    }
}
