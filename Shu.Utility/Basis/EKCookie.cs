//***********************************
//版本：3 （数字，由1自增）
//创建时间：2012-11-11
//作者：王健龙
//说明：Cookie 处理封装
//
//V1:
//修改时间：2011-11-12
//修改人：王健龙
//修改说明：添加是否加密功能。
//
//V2:
//修改时间：2011-11-14
//修改人：王健龙
//修改说明：密钥异常修改。
//
//***********************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;

namespace Shu.Utility
{
    public class EKCookie
    {
        #region 属性
        
        //cookie过期时间,单位分钟
        private static double _minute = 1440;
        //加密密钥
        private static string _encryptkey = "MSMS1101";

        /// <summary>
        /// cookie过期时间，分钟
        /// </summary>
        public static double Minute
        {
            get { return _minute; }
            set { _minute = value; }
        }
        
        /// <summary>
        /// 加密密钥
        /// </summary>
        public static string EncryptKey
        {
            get { return _encryptkey; }
            set { _encryptkey = value == "" ? "MSMS1101" : value; }
        }


        #endregion

        #region 一般操作方法
        
        /// <summary>
        /// 添加cookie值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="decode">是否加密</param>
        public static void AddCookie(string name, string value, bool encode)
        {
            if (encode)
            {
                value = EKEncrypt.EncryptDES(value, _encryptkey);
            }
            System.Web.HttpCookie cook = System.Web.HttpContext.Current.Request.Cookies[name];
            if (cook == null)
            {
                cook = new System.Web.HttpCookie(name);

                if (!EKRequest.GetHost().Contains("192.168.") && !EKRequest.GetHost().Contains("localhost"))
                {
                    cook.Domain = EKRequest.GetDoMain();
                }

                cook.Value = value;
                cook.Expires = DateTime.Now.AddMinutes(_minute);
                System.Web.HttpContext.Current.Response.Cookies.Add(cook);
            }
            else
            {
                if (!EKRequest.GetHost().Contains("192.168.") && !EKRequest.GetHost().Contains("localhost"))
                {
                    cook.Domain = EKRequest.GetDoMain();
                }

                cook.Value = value;
                cook.Expires = DateTime.Now.AddMinutes(_minute);
                System.Web.HttpContext.Current.Response.Cookies.Add(cook);
            }
        }

        /// <summary>
        /// 添加cookie值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public static void AddCookie(string name, string value)
        {
            AddCookie(name, value, true);
        }


        /// <summary>
        /// 获取cookie值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="decode">是否解密</param>
        /// <returns></returns>
        public static string GetCookie(string name, bool decode)
        {
            if (System.Web.HttpContext.Current.Request.Cookies == null || System.Web.HttpContext.Current.Request.Cookies[name] == null || System.Web.HttpContext.Current.Request.Cookies[name].Value == null || System.Web.HttpContext.Current.Request.Cookies[name].Value == "")
            {
                return "";
            }
            if (decode)
            {
                return EKEncrypt.DecryptDES(System.Web.HttpContext.Current.Request.Cookies[name].Value, _encryptkey);
            }
            return System.Web.HttpContext.Current.Request.Cookies[name].Value;
        }

        /// <summary>
        /// 获取cookie值
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static string GetCookie(string name)
        {
            return GetCookie(name, true);
        }

        /// <summary>
        /// 获取cookie值,加默认值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="decode">是否解密</param>
        /// <returns></returns>
        public static string GetCookie(string name, string defaultValue, bool decode)
        {
            if (System.Web.HttpContext.Current.Request.Cookies == null || System.Web.HttpContext.Current.Request.Cookies[name] == null || System.Web.HttpContext.Current.Request.Cookies[name].Value == null || System.Web.HttpContext.Current.Request.Cookies[name].Value == "")
            {
                return defaultValue;
            }
            if (decode)
            {
                return EKEncrypt.DecryptDES(System.Web.HttpContext.Current.Request.Cookies[name].Value, _encryptkey);
            }
            return System.Web.HttpContext.Current.Request.Cookies[name].Value;
        }

        /// <summary>
        /// 获取cookie值,加默认值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetCookie(string name, string defaultValue)
        {
            return GetCookie(name, defaultValue, true);
        }

        /// <summary>
        /// 清除指定cookie
        /// </summary>
        /// <param name="name">名称</param>
        public static void ClearCookie(string name)
        {
            if (System.Web.HttpContext.Current.Request.Cookies != null && System.Web.HttpContext.Current.Response.Cookies.Get(name) != null)
            {
                System.Web.HttpCookie cook = System.Web.HttpContext.Current.Response.Cookies.Get(name);
                cook.Expires = DateTime.Now.AddDays(-1);
                System.Web.HttpContext.Current.Response.Cookies.Add(cook);
            }
        }

        /// <summary>
        /// 重新设置指定cookie值
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="encode">是否加密</param>
        public static void SetCookie(string name, string value, bool encode)
        {
            if (System.Web.HttpContext.Current.Request.Cookies == null || System.Web.HttpContext.Current.Request.Cookies[name] == null || System.Web.HttpContext.Current.Request.Cookies[name].Value == null || System.Web.HttpContext.Current.Request.Cookies[name].Value == "")
            {
                AddCookie(name, value, encode);
                return;
            }
            System.Web.HttpContext.Current.Response.Cookies[name].Value = encode ? EKEncrypt.EncryptDES(value, _encryptkey) : value;
        }

        /// <summary>
        /// 重新设置指定cookie值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetCookie(string name, string value)
        {
            SetCookie(name, value, true);
        }

        /// <summary>
        /// 是否存在指定名称Cookie
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static bool IsExistCookie(string name)
        {
            if (System.Web.HttpContext.Current.Request.Cookies == null || System.Web.HttpContext.Current.Request.Cookies[name] == null || System.Web.HttpContext.Current.Request.Cookies[name].Value == null)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region cookie集合操作

        public static CookieContainer AddCookie(string url,HttpCookieCollection cooks)
        {
            CookieContainer cookieCon = new CookieContainer();
            for (int i = 0; i < cooks.Count;i++ )
            {
                cookieCon.Add(new Uri(url), new System.Net.Cookie(cooks[i].Name, cooks[i].Value));
            }

            return cookieCon;
        }

        #endregion

    }
}
