using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Collections;
using System.IO;

namespace Shu.Utility
{
    public enum SubmitType
    {
        POST,
        GET
    }

    /// <summary>
    /// 模拟表单提交的类
    /// </summary>
    public class EKMock
    {
        /// <summary>
        /// 模拟表单提交
        /// </summary>
        /// <param name="url">提交的路径</param>
        /// <param name="type">提交的类型</param>
        /// <param name="keyValue">表单中的键值对</param>
        /// <returns></returns>
        public static string Submit(string url, SubmitType type,NameValueCollection keyValue)
        {
            string result = string.Empty;
            System.Net.WebClient WebClientObj = new System.Net.WebClient();
            try
            {
                byte[] byRemoteInfo = WebClientObj.UploadValues(url, type.ToString(), keyValue);

                //下面都没用啦，就上面一句话就可以了
                string sRemoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);
                //这是获取返回信息
                result = sRemoteInfo;
            }
            catch
            {
                //throw ex;
            }
            finally
            {
                WebClientObj.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 提交一个字符串到指定路径
        /// </summary>
        /// <param name="url">提交的地址</param>
        /// <param name="type">提交的类型</param>
        /// <param name="message">提交的信息</param>
        /// <returns>提交返回的信息</returns>
        public static string Submit(string url, SubmitType type, string message)
        {
            string result = string.Empty;
            System.Net.WebClient WebClientObj = new System.Net.WebClient();
            try
            {   
                result = WebClientObj.UploadString(url, type.ToString(), message);
                WebClientObj.Dispose();
            }
            catch
            {
                //throw ex;
            }
            finally
            {
                WebClientObj.Dispose();
            }

            return result;
        }

        /// <summary>
        /// 模拟表单提交
        /// </summary>
        /// <param name="url">提交的路径</param>
        /// <param name="type">提交的类型</param>
        /// <param name="keyValue">表单中的键值对</param>
        /// <returns></returns>
        public static string Submit(string url, SubmitType type, Hashtable ht)
        {
            IDictionaryEnumerator dicenum = ht.GetEnumerator();
            NameValueCollection collection = new NameValueCollection();
            while (dicenum.MoveNext())
            {
                collection.Add((dicenum.Key as string),(dicenum.Value as string));
            }
            return Submit(url, type, collection);
        }

        /// <summary>
        /// Request方式提交到某个页面
        /// </summary>
        /// <param name="url">页面路径</param>
        /// <param name="message">数据串</param>
        /// <returns>页面的返回</returns>
        public static string ReqPost(string url,string message)
        {
            string result = string.Empty;
            Stream reqstr                   = null;
            System.IO.Stream responseStream = null;
            System.IO.StreamReader reader   = null;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.KeepAlive = false; //将 KeepAlive 属性设置为 false 以避免与 Internet 资源建立持久性连接。 

                reqstr = request.GetRequestStream();
                byte[] buff = Encoding.ASCII.GetBytes(message);
                reqstr.Write(buff, 0, message.Length);
                reqstr.Flush();
                reqstr.Close();
                reqstr.Dispose();
                reqstr = null;
                // 接收返回的页面
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                responseStream = response.GetResponseStream();
                reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            catch
            {
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (reqstr != null)
                {
                    reqstr.Flush();
                    reqstr.Close();
                    reqstr.Dispose();
                }
                if (responseStream != null)
                {
                    responseStream.Flush();
                    responseStream.Close();
                    responseStream.Dispose();
                }
            }
            return result;
            
        }
    }
}
