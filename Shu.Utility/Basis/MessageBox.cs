using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Shu.Utility
{
    public class MessageBox
    {
        static int mode = 1;
        static string str_jboxres = "";

        static MessageBox()
        {
            mode = 0;
        }

        #region ����ҳ����ʾ

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(string msg)
        {
            if (mode == 0)
            {
                string str_script = "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>";
                System.Web.HttpContext.Current.Response.Write(str_script);
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                JboxShow(msg, "");
            }
        }


        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void ShowScript(string str_script)
        {
            if (mode == 0)
            {
                System.Web.HttpContext.Current.Response.Write(str_script);
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                //JboxShow(msg, "");
            }
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��תҳ��</param>
        public static void Show(string msg, string url)
        {
            if (mode == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript' defer>alert('" + msg.ToString() + "');window.location.href='" + url + "';</script>");
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                JboxShow(msg, url);
            }
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            if (mode == 0)
            {
                string str_script = "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>";
                if (!page.ClientScript.IsClientScriptBlockRegistered(page.GetType(), "clientScript"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "clientScript", str_script);
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write(str_script);
                    System.Web.HttpContext.Current.Response.End();
                }
            }
            else
            {
                JboxShow(page, msg, "");
            }
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void ShowLogin(System.Web.UI.Page page, string msg)
        {
            if (mode == 0)
            {
                string str_script = "<script language='javascript' defer>" + msg + ";</script>";
                if (!page.ClientScript.IsClientScriptBlockRegistered(page.GetType(), "clientScript"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "clientScript", str_script);
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write(str_script);
                    System.Web.HttpContext.Current.Response.End();
                }
            }
            else
            {
                JboxShow(page, msg, "");
            }
        }


        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static string Show2(System.Web.UI.Page page, string msg)
        {
                string str_script = "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>";
                return str_script;
           
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(System.Web.UI.Page page, string msg, string url)
        {
            if (mode == 0)
            {
                string str_script = "<script language='javascript' defer>alert('" + msg.ToString() + "');window.location.href='" + url + "';</script>";
                if (!page.ClientScript.IsClientScriptBlockRegistered(page.GetType(), "clientScript"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "clientScript", str_script);
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write(str_script);
                    System.Web.HttpContext.Current.Response.End();
                }
            }
            else
            {
                JboxShow(page, msg, url);
            }
        }


        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show1(System.Web.UI.Page page, string msg, string url)
        {
            if (mode == 0)
            {
                string str_script = "<script language='javascript' defer>alert('" + msg.ToString() + "');window.top.location.href='" + url + "';</script>";
                if (!page.ClientScript.IsClientScriptBlockRegistered(page.GetType(), "clientScript"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "clientScript", str_script);
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write(str_script);
                    System.Web.HttpContext.Current.Response.End();
                }
            }
            else
            {
                JboxShow(page, msg, url);
            }
        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��תҳ��</param>
        public static void ShowTop(string msg, string url)
        {
            if (mode == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript' defer>alert('" + msg.ToString() + "');top.location.href='" + url + "';</script>");
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                JboxShow(msg, url, "top");
            }
        }


        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��תҳ��</param>
        public static void ShowTop(System.Web.UI.Page page, string msg, string url)
        {
            if (mode == 0)
            {
                string str_script = "<script language='javascript' defer>alert('" + msg.ToString() + "');top.location.href='" + url + "';</script>";
                if (!page.ClientScript.IsClientScriptBlockRegistered(page.GetType(), "clientScript"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "clientScript", str_script);
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write(str_script);
                    System.Web.HttpContext.Current.Response.End();
                }
            }
            else
            {
                JboxShow(page, msg, url, "top");
            }
        }

        /// <summary>
        /// ��ʾ��Ϣȷ�Ͽ�
        /// </summary>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="urla">��ʾ��Ϣ</param>
        /// <param name="urlb">��ʾ��Ϣ</param>
        public static void ShowConfirm(string msg, string urla, string urlb)
        {
            if (mode == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript' defer>if(confirm('" + msg.ToString() + "')){window.location.href='" + urla + "';}else{window.location.href='" + urlb + "';}</script>");
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                JboxShowConfirm(msg, urla, urlb);
            }
        }

        /// <summary>
        /// ��ʾ��Ϣȷ�Ͽ�
        /// </summary>
        /// <param name="page">ҳ��</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">ת���ַ</param>
        public static void ShowConfirm(System.Web.UI.Page page, string msg, string urla, string urlb)
        {
            if (mode == 0)
            {
                string str_script = "<script language='javascript' defer>if(confirm('" + msg.ToString() + "')){window.location.href='" + urla + "';}else{window.location.href='" + urlb + "';}</script>";
                if (!page.ClientScript.IsClientScriptBlockRegistered(page.GetType(), "clientScript"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "clientScript", str_script);
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write(str_script);
                    System.Web.HttpContext.Current.Response.End();
                }
            }
            else
            {
                JboxShowConfirm(msg, urla, urlb);
            }
        }

        #endregion

        #region ������Ϣ����

        /// <summary>
        /// ����Զ���ű���Ϣ
        /// </summary>
        /// <param name="script">����ű�</param>
        public static void RegisterScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "clientScript", "<script  language='javascript'>" + script + "</script>");
        }

        /// <summary>
        /// ����Զ���ű���Ϣ
        /// </summary>
        /// <param name="script">����ű�</param>
        public static void RegisterScript(string script)
        {
            System.Web.HttpContext.Current.Response.Write("<script  language='javascript'>" + script + "</script>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// ��ʾһ���������ڣ����رյ�ǰҳ
        /// </summary>
        /// <param name="str"></param>
        public static void ShowClose(string str)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<script language=\"javascript\">\n");
            sb.AppendLine("alert(\"" + str.Trim() + "\"); \n");
            sb.AppendLine("window.close();\n");
            sb.AppendLine("</script>\n");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        #endregion

        #region Jbox����Ч��

        /// <summary>
        /// ���jboxЧ��
        /// </summary>
        /// <param name="msg">��Ϣ��ʾ</param>
        /// <param name="url">��ת��ַ</param>
        public static void JboxShow(string msg, string url)
        {
            JboxShow(msg, url, "window");
        }

        /// <summary>
        /// ���jboxЧ��
        /// </summary>
        /// <param name="msg">��Ϣ��ʾ</param>
        /// <param name="url">��ת��ַ</param>
        /// <param name="target">ҳ����ת���</param>
        protected static void JboxShow(string msg, string url, string target)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\"><head>");

            sb.AppendLine(str_jboxres);

            sb.AppendLine("<script type=\"text/javascript\">");

            sb.AppendLine("var fun_submit = function (v, h, f) {");
            if (url != "")
            {
                sb.AppendLine("" + target + ".location.href='" + url + "';");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("var fun_close = function () {");
            if (url != "")
            {
                sb.AppendLine("" + target + ".location.href='" + url + "';");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("function jboxMsg(msg) {");
            sb.AppendLine("     $.jBox.info(msg , \"��Ϣ��ʾ\", { submit : fun_submit ,closed : fun_close , top: '30%'});");
            /*
            sb.AppendLine("$.jBox(msg, {");
            sb.AppendLine(" title: \"��Ϣ��ʾ\",");
            sb.AppendLine("  width: 500,");
            sb.AppendLine(" height: 350,");
            sb.AppendLine(" buttons: { '�ر�': true }");
            sb.AppendLine("});");*/
            sb.AppendLine("}");
            sb.AppendLine("</script>");

            sb.AppendLine("<script language='javascript'>$(document).ready(function () {jboxMsg('" + msg + "');});</script>");

            sb.AppendLine("</head><body>");
            sb.AppendLine("</body></html>");

            System.Web.HttpContext.Current.Response.Write(sb.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// ���jboxЧ��
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��Ϣ��ʾ</param>
        /// <param name="url">��ת��ַ</param>
        protected static void JboxShow(System.Web.UI.Page page, string msg, string url)
        {
            JboxShow(page, msg, url, "window");
        }

        /// <summary>
        /// ���jboxЧ��
        /// </summary>
        /// <param name="page">ҳ�����</param>
        /// <param name="msg">��Ϣ��ʾ</param>
        /// <param name="url">��ת��ַ</param>
        /// <param name="target">ҳ����ת���</param>
        protected static void JboxShow(System.Web.UI.Page page, string msg, string url, string target)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("");

            bool isjquey = false;
            //�Ƿ���� jquery ������Ҫ�ظ�����
            for (int i = 0; i < page.Header.Controls.Count; i++)
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter html_write = new HtmlTextWriter(sw);
                page.Header.Controls[i].RenderControl(html_write);
                if (sw.ToString().ToLower().Contains("jquery"))
                {
                    isjquey = true;
                }
            }

            //������Ҫ�Ŀ�
            string adminpath = "/";
            string str_res = "<link rel=\"stylesheet\" href=\"" + adminpath + "/tool/JBox/Skins/Blue/jbox.css\" />\n";

            if (!isjquey)
            {
                str_res += "<script type=\"text/javascript\" src=\"" + adminpath + "/js/jquery1.4.js\"></script>\n";
            }
            str_res += "<script type=\"text/javascript\" src=\"" + adminpath + "/tool/JBox/jquery.jBox-2.3.min.js\"></script>\n";
            sb.AppendLine(str_res);


            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("var fun_submit = function (v, h, f) {");
            if (url != "")
            {
                sb.AppendLine("" + target + ".location.href='" + url + "';");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("var fun_close = function () {");
            if (url != "")
            {
                //�ر����ڱ�ҳ
                sb.AppendLine("/*" + target + ".location.href='" + url + "';*/");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("function jboxMsg(msg) {");
            sb.AppendLine("     $.jBox.info(msg , \"��Ϣ��ʾ\", { submit : fun_submit ,closed : fun_close , top: '30%' });");
            /*
            sb.AppendLine("$.jBox(msg, {");
            sb.AppendLine(" title: \"��Ϣ��ʾ\",");
            sb.AppendLine("  width: 500,");
            sb.AppendLine(" height: 350,");
            sb.AppendLine(" buttons: { '�ر�': true }");
            sb.AppendLine("});");*/
            sb.AppendLine("}");
            sb.AppendLine("</script>");

            sb.AppendLine("<script language='javascript'>$(document).ready(function () {jboxMsg('" + msg + "');});</script>");
            sb.AppendLine("");

            page.Header.Controls.Add(new LiteralControl(sb.ToString()));
            //page.ClientScript.RegisterClientScriptBlock(page.GetType(), "jbox", sb.ToString());
        }

        /// <summary>
        /// ��Ϣѯ��
        /// </summary>
        /// <param name="msg">��Ϣ����</param>
        /// <param name="urla">ȷ������ҳ��</param>
        /// <param name="urlb">ȡ������ҳ��</param>
        /// <param name="target">ҳ����ת���</param>
        protected static void JboxShowConfirm(string msg, string urla, string urlb)
        {
            JboxShowConfirm(msg, urla, urlb, "window");
        }

        /// <summary>
        /// ��Ϣѯ��
        /// </summary>
        /// <param name="msg">��Ϣ����</param>
        /// <param name="urla">ȷ������ҳ��</param>
        /// <param name="urlb">ȡ������ҳ��</param>
        /// <param name="target">ҳ����ת���</param>
        protected static void JboxShowConfirm(string msg, string urla, string urlb, string target)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\"><head>");

            sb.AppendLine(str_jboxres);

            sb.AppendLine("<script type=\"text/javascript\">");

            sb.AppendLine("var fun_submit = function (v, h, f) {");
            if (urla != "")
            {
                sb.AppendLine("" + target + ".location.href='" + urla + "';");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("var fun_cancel = function () {");
            if (urlb != "")
            {
                sb.AppendLine("" + target + ".location.href='" + urlb + "';");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("function jboxMsg(msg) {");
            sb.AppendLine("     $.jBox.confirm(msg , \"��Ϣ��ʾ\", { submit : fun_submit ,cancel : fun_cancel , top: '30%' });");
            sb.AppendLine("}");
            sb.AppendLine("</script>");

            sb.AppendLine("<script language='javascript'>$(document).ready(function () {jboxMsg('" + msg + "');});</script>");

            sb.AppendLine("</head><body>");
            sb.AppendLine("</body></html>");

            System.Web.HttpContext.Current.Response.Write(sb.ToString());
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// ��Ϣѯ��
        /// </summary>
        /// <param name="msg">��Ϣ����</param>
        /// <param name="urla">ȷ������ҳ��</param>
        /// <param name="urlb">ȡ������ҳ��</param>
        /// <param name="target">ҳ����ת���</param>
        protected static void JboxShowConfirm(System.Web.UI.Page page, string msg, string urla, string urlb)
        {
            JboxShowConfirm(page, msg, urla, urlb, "window");
        }

        /// <summary>
        /// ��Ϣѯ��
        /// </summary>
        /// <param name="page">ҳ��page����</param>
        /// <param name="msg">��Ϣ����</param>
        /// <param name="urla">ȷ������ҳ��</param>
        /// <param name="urlb">ȡ������ҳ��</param>
        /// <param name="target">ҳ����ת���</param>
        protected static void JboxShowConfirm(System.Web.UI.Page page, string msg, string urla, string urlb, string target)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("");

            bool isjquey = false;
            //�Ƿ���� jquery ������Ҫ�ظ�����
            for (int i = 0; i < page.Header.Controls.Count; i++)
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter html_write = new HtmlTextWriter(sw);
                page.Header.Controls[i].RenderControl(html_write);
                if (sw.ToString().ToLower().Contains("jquery"))
                {
                    isjquey = true;
                }
            }

            //������Ҫ�Ŀ�
            string adminpath = "/";
            string str_res = "<link rel=\"stylesheet\" href=\"" + adminpath + "/tool/JBox/Skins/Blue/jbox.css\" />\n";

            if (!isjquey)
            {
                str_res += "<script type=\"text/javascript\" src=\"" + adminpath + "/js/jquery1.4.js\"></script>\n";
            }
            str_res += "<script type=\"text/javascript\" src=\"" + adminpath + "/tool/JBox/jquery.jBox-2.3.min.js\"></script>\n";
            sb.AppendLine(str_res);


            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("var fun_submit = function (v, h, f) {");
            if (urla != "")
            {
                sb.AppendLine("" + target + ".location.href='" + urla + "';");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("var fun_cancel = function () {");
            if (urlb != "")
            {
                sb.AppendLine("" + target + ".location.href='" + urlb + "';");
            }
            sb.AppendLine("return true;");
            sb.AppendLine("};");

            sb.AppendLine("function jboxMsg(msg) {");
            sb.AppendLine("     $.jBox.confirm(msg , \"��Ϣ��ʾ\", { submit : fun_submit ,cancel : fun_cancel , top: '30%' });");
            sb.AppendLine("}");
            sb.AppendLine("</script>");

            sb.AppendLine("<script language='javascript'>$(document).ready(function () {jboxMsg('" + msg + "');});</script>");
            sb.AppendLine("");

            page.Header.Controls.AddAt(0, new LiteralControl(sb.ToString()));
            //page.ClientScript.RegisterClientScriptBlock(page.GetType(), "jbox", sb.ToString());
        }

        #endregion

    }
}
