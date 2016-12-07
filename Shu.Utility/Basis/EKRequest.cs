using System;
using System.Web;

namespace Shu.Utility
{
    /// <summary>
    /// Request������
    /// </summary>
    public class EKRequest
    {
        /// <summary>
        /// ��ȡ�������
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
        /// �жϵ�ǰҳ���Ƿ���յ���Post����
        /// </summary>
        /// <returns>�Ƿ���յ���Post����</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /// <summary>
        /// �жϵ�ǰҳ���Ƿ���յ���Get����
        /// </summary>
        /// <returns>�Ƿ���յ���Get����</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// ����ָ���ķ�����������Ϣ
        /// </summary>
        /// <param name="strName">������������</param>
        /// <returns>������������Ϣ</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>
        /// ������һ��ҳ��ĵ�ַ
        /// </summary>
        /// <returns>��һ��ҳ��ĵ�ַ</returns>
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
        /// �õ���ǰ��������ͷ
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
        /// �õ�����ͷ
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// ��ȡ������
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
        /// ��ȡ��ǰ�����ԭʼ URL(URL ������Ϣ֮��Ĳ���,������ѯ�ַ���(�������))
        /// </summary>
        /// <returns>ԭʼ URL</returns>
        public static string GetRawUrl()
        {
            return FilterKey(StrEncode(HttpContext.Current.Request.RawUrl));
        }

        /// <summary>
        /// �жϵ�ǰ�����Ƿ�������������
        /// </summary>
        /// <returns>��ǰ�����Ƿ�������������</returns>
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
        /// �ж��Ƿ�����������������
        /// </summary>
        /// <returns>�Ƿ�����������������</returns>
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
        /// ��õ�ǰ����Url��ַ
        /// </summary>
        /// <returns>��ǰ����Url��ַ</returns>
        public static string GetUrl()
        {
            return FilterKey(HttpContext.Current.Request.Url.ToString());
            //return System.Web.HttpContext.Current.Server.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// ��õ�ǰUrl��ַ�����б��ַ�����������'?'��
        /// </summary>
        /// <returns>��ǰ����Url��ַ</returns>
        public static string GetUrlParameterList()
        {
            string[] urlArr = HttpContext.Current.Request.Url.Query.Split('?');
            return FilterKey(urlArr[urlArr.Length - 1]);
        }

        /// <summary>
        /// ���ָ��Url������ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������ֵ</returns>
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
        /// ��õ�ǰҳ�������,����������
        /// </summary>
        /// <returns>��ǰҳ�������</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1];
        }

        /// <summary>
        /// ��õ�ǰҳ�������,��������
        /// </summary>
        /// <returns>��ǰҳ�������</returns>
        public static string GetPageNameAndQuery()
        {
            string[] urlArr = HttpContext.Current.Request.Url.PathAndQuery.Split('/');
            return FilterKey(urlArr[urlArr.Length - 1]);
        }


        /// <summary>
        /// ��ȡ�ϴ������·�������
        /// </summary>
        /// <returns></returns>
        public static string GetReferrerPathAndQuery()
        {
            return FilterKey(HttpContext.Current.Request.UrlReferrer.PathAndQuery);
        }

        /// <summary>
        /// ��õ�ǰҳ�������,��������
        /// </summary>
        /// <returns>��ǰҳ��ȫ��</returns>
        public static string GetPageAllName()
        {
            return FilterKey(HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// ���ر���Url�������ܸ���
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /// <summary>
        /// ���ָ����������ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <returns>��������ֵ</returns>
        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>Url���������ֵ</returns>
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
        /// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="dufault">Ĭ��ֵ</param>
        /// <returns>Url���������ֵ</returns>
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
        /// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="dufault">Ĭ��ֵ</param>
        /// <returns>Url���������ֵ</returns>
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
        /// ���ָ��Url������int����ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url������int����ֵ</returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return EKTypeParse.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// ���ָ����������int����ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>��������int����ֵ</returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return EKTypeParse.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ���ָ��Url���������int����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">Url�������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url���������int����ֵ</returns>
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
        /// ���ָ��Url������float����ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url������int����ֵ</returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return EKTypeParse.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }


        /// <summary>
        /// ���ָ����������float����ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>��������float����ֵ</returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return EKTypeParse.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// ���ָ��Url���������float����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">Url�������</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>Url���������int����ֵ</returns>
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
        /// ��õ�ǰҳ��ͻ��˵�IP
        /// </summary>
        /// <returns>��ǰҳ��ͻ��˵�IP</returns>
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
        /// �Ƿ�վ�ύ
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
        /// ɾ����ǰ�����е��ظ��Ĳ���,ɾ��ָ������(���ʹ��,�Ÿ�),������ɾ��������б�
        /// </summary>
        /// <param name="parame">��������,����ö��Ÿ�</param>
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

                //�����
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

                //�Ƿ�����ظ�,�Ƿ���� Ҫɾ���е�һ��.Ϊ�˲��ظ����,�ж�strParam���Ƿ��Ѿ�������ͬ�� "?��=" �� "&��="
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
        /// ɾ����ǰ�����е��ظ��Ĳ���,������ɾ��������б�
        /// </summary>
        /// <returns></returns>
        public static string RemoveSameParameter()
        {
            return RemoveSameParameter("");
        }

        /// <summary>
        /// ���¶���ҳ�棬����ɾ���������ҳ���ַ
        /// </summary>
        /// <param name="par">��������,����ö��Ÿ�</param>
        /// <returns></returns>
        public static string RePage(string par)
        {
            return EKRequest.GetPageName() + "?" + EKRequest.RemoveSameParameter(par);
        }


        /// <summary>
        /// ��ǰҳ�����
        /// </summary>
        /// <returns></returns>
        public static string GetUrlEncode()
        {
            return FilterKey(System.Web.HttpContext.Current.Server.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()));
        }

        /// <summary>
        /// ��ǰҳ�����
        /// </summary>
        /// <returns></returns>
        public static string GetUrlDecode()
        {
            return System.Web.HttpContext.Current.Server.UrlDecode(System.Web.HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrEncode(string str)
        {
            return StrEncode(str, "utf-8");
        }

        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">��������</param>
        /// <returns></returns>
        public static string StrEncode(string str,string encoding)
        {
            return FilterKey(System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding(encoding)).Replace("+", "%20"));
        }

        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrDecode(string str)
        {
            return StrDecode(str, "utf-8");
        }

        /// <summary>
        /// �ַ�������
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">��������</param>
        /// <returns></returns>
        public static string StrDecode(string str, string encoding)
        {
            return System.Web.HttpUtility.UrlDecode(str, System.Text.Encoding.GetEncoding(encoding));
        }

        /// <summary>
        /// ��ַ��·�����룬�ų� / // \ \\�ȱ���
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StrEncodeUrl(string str)
        {
            return StrEncodeUrl(str, "utf-8");
        }

        /// <summary>
        /// ��ַ��·�����룬�ų� / // \ \\�ȱ���
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">��������</param>
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
                //�����ر��ַ�
                if (!EKGetString.IsExist(":,?,&,/,//,///,////,\\,\\\\,\\/,/\\", ',', tempStr.ToString()))
                {
                    tempStr2 = EKRequest.StrEncode(tempStr.ToString(), encoding);
                }
                else
                {
                    tempStr2 = tempStr.ToString();
                }
                //�±����ַ���
                returnStr += tempStr2;
            }
            return returnStr.Replace("+", "%20");
        }

        /// <summary>
        /// ת�������ַ�
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
        /// ��ԭת�������ַ�
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
