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
        /// ��ȡword �޸�ʽ��text�ı�
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
        /// WordתHTMl
        /// </summary>
        /// <param name="path">word�ļ�·�� ���̷�</param>
        /// <returns></returns>
        public static string WordToHtml(string wordPath)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Type wordType = word.GetType();
            Microsoft.Office.Interop.Word.Documents docs = word.Documents;
            Object oMissing = System.Reflection.Missing.Value;
            // ���ļ�
            Type docsType = docs.GetType();

            //Ӧ���Ȱ��ļ��ϴ���������Ȼ���ٽ����ļ�Ϊhtml
            string filePath = wordPath;
            Microsoft.Office.Interop.Word.Document doc = (Microsoft.Office.Interop.Word.Document)docsType.InvokeMember("Open",
            System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { filePath, true, true });

            // ת����ʽ�����Ϊhtml
            Type docType = doc.GetType();

            //��ת����html�ĵ������λ��
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

            //���Ϊhtmlҳ��
            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
            null, doc, new object[] { saveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML });

            // �˳� Word
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);

            //doc.Close(ref oMissing, ref oMissing, ref oMissing);
            try
            {
                docs.Close(ref oMissing, ref oMissing, ref oMissing);
                word.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
            catch (Exception ex)
            {
                new MS_LogBLL().AddLogAdmin(MS_LogBLL.LogLevel.ERROR, "wordת��ʧ��" + ex.Message);
            }
            GC.Collect();

            //��ȡhtml��ҳ��
            string html = "";
            //�ر���.��"."�ŵĵ��ļ���.ֱ�Ӷ�.  ���ü�.htm
            if (saveFileName.Contains("."))
            {
                html = EKFile.ReadFile(saveFileName);
            }
            else
            {
                html = EKFile.ReadFile(saveFileName + ".htm");
            }

            //��ȫͼƬ��ַ
            html = EKHtml.ImageWebRoot(html, "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/files/temp/", "<img[\\s\\S]+?src=\"(?<url>.+?)\">");

            //����ҳ��ͼƬ
            html = EKHtml.SaveImage(html, DateTime.Now, "<img[\\s\\S]+?src=\"(?<url>.+?)\">");

            //ɾ����ʱ�ļ���Ҳ�ɱ���
            if (saveFileName.Contains("."))
            {
                EKFile.DeleteFile(saveFileName);
            }
            else
            {
                EKFile.DeleteFile(saveFileName + ".htm");
            }
            //ɾ��Ŀ¼
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
