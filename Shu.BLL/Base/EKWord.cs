using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using Shu.Utility;

namespace Shu.BLL
{
    public class EKWord
    {

        /// <summary>
        /// 获取word 无格式的text文本
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string WordToText(string path)
        {
            string wordText = "";
            Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();//ApplicationClass();
            Microsoft.Office.Interop.Word.Document WordDoc;
            Microsoft.Office.Interop.Word.Documents docs = WordApp.Documents;

            Object oMissing = System.Reflection.Missing.Value;
            Type wordType = WordApp.GetType();

            object fileName = path;

            WordDoc = WordApp.Documents.Open(ref fileName,
               ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
               ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
               ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            wordText = WordDoc.Content.Text;

            WordDoc.Close(ref oMissing, ref oMissing, ref oMissing);
            WordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
            GC.Collect();

            return wordText;
        }

        /// <summary>
        /// Word转HTMl
        /// </summary>
        /// <param name="path">word文件路径 带盘符</param>
        /// <returns></returns>
        public static string WordToHtml(string wordPath)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Type wordType = word.GetType();
            Microsoft.Office.Interop.Word.Documents docs = word.Documents;
            Object oMissing = System.Reflection.Missing.Value;
            // 打开文件
            Type docsType = docs.GetType();

            //应当先把文件上传至服务器然后再解析文件为html
            string filePath = wordPath;
            Microsoft.Office.Interop.Word.Document doc = (Microsoft.Office.Interop.Word.Document)docsType.InvokeMember("Open",
            System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { filePath, true, true });

            // 转换格式，另存为html
            Type docType = doc.GetType();

            //被转换的html文档保存的位置
            string saveFileName = "";
            string ext = EKFileUpload.getExtend(wordPath).ToLower();
            if (ext == "doc")
            {
                saveFileName = wordPath.Replace(".doc", "");
            }
            else if (ext == "docx")
            {
                saveFileName = wordPath.Replace(".docx", "");
            }
            else
            {
            }

            //另存为html页面
            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
            null, doc, new object[] { saveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML });

            // 退出 Word
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);

            //doc.Close(ref oMissing, ref oMissing, ref oMissing);
            try
            {
                docs.Close(ref oMissing, ref oMissing, ref oMissing);
                word.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
            catch (Exception ex)
            {
                new MS_LogBLL().AddLogAdmin(MS_LogBLL.LogLevel.ERROR, "word转换失败" + ex.Message);
            }
            GC.Collect();

            //读取html　页面
            string html = "";
            //特别处理.有"."号的的文件名.直接读.  不用加.htm
            if (saveFileName.Contains("."))
            {
                html = EKFile.ReadFile(saveFileName);
            }
            else
            {
                html = EKFile.ReadFile(saveFileName + ".htm");
            }

            //补全图片地址
            html = EKHtml.ImageWebRoot(html, "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/files/temp/", "<img[\\s\\S]+?src=\"(?<url>.+?)\">");

            //保存页面图片
            html = EKHtml.SaveImage(html, DateTime.Now, "<img[\\s\\S]+?src=\"(?<url>.+?)\">");

            //删除临时文件．也可保留
            if (saveFileName.Contains("."))
            {
                EKFile.DeleteFile(saveFileName);
            }
            else
            {
                EKFile.DeleteFile(saveFileName + ".htm");
            }
            //删除目录
            if (EKFile.ExistsDirectory(saveFileName + ".files"))
            {
                EKFile.DeleteDirectoryAnd(saveFileName + ".files");
                EKFile.DeleteDirectory(saveFileName + ".files");
            }
            EKFile.DeleteFile(wordPath);

            return html;
        }

    }
}
