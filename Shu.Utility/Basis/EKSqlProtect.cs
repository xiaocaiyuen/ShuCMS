using System;
using System.Collections.Generic;
using System.Text;

namespace Shu.Utility
{
    /// <summary>
    /// SqlProtect 的摘要说明。
    /// </summary>
    public class EKSqlProtect
    {
        public EKSqlProtect()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region SQL注入式攻击代码分析
        /// <summary>
        /// 处理用户提交的请求
        /// </summary>
        public static void StartSqlProtect()
        {
            try
            {
                string getkeys = "";
                if (System.Web.HttpContext.Current.Request.QueryString != null)
                {

                    for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys], 0))
                        {
                            //System.Web.HttpContext.Current.Response.Redirect (sqlErrorPage+"?errmsg=sqlserver&sqlprocess=true");
                            System.Web.HttpContext.Current.Response.Write("<script>alert('请勿非法提交！');history.back();</script>");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
                /*
                if (System.Web.HttpContext.Current.Request.Form != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.Form[getkeys], 1))
                        {
                            //System.Web.HttpContext.Current.Response.Redirect (sqlErrorPage+"?errmsg=sqlserver&sqlprocess=true");
                            System.Web.HttpContext.Current.Response.Write("<script>alert('请勿非法提交！');history.back();</script>");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }*/
            }
            catch
            {
                // 错误处理: 处理用户提交信息!
            }
        }

        /// <summary>
        /// 分析用户请求是否正常
        /// </summary>
        /// <param name="Str">传入用户提交数据</param>
        /// <returns>返回是否含有SQL注入式攻击代码</returns>
        private static bool ProcessSqlStr(string Str,int type)
        {
            string SqlStr;

            if (type == 1)
            {
                //SqlStr = "exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ";
                SqlStr = "exec|insert|select|delete|update|count|declare|drop|create|alter|<|>|'|;";
            }
            else
            {
                //SqlStr = "'|and|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
                SqlStr = "exec|insert|select|delete|update|count|declare|drop|create|alter|<|>|'|;";
            }

            bool ReturnValue = true;
            try
            {
                if (Str != "")
                {
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
        #endregion

    }
}
