using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace FineUI.Examples
{
    public partial class source : PageBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string files = Request.QueryString["files"];

                if (String.IsNullOrEmpty(files))
                {
                    return;
                }

                if (!String.IsNullOrEmpty(files))
                {
                    string[] fileNames = files.Split(';');

                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        string fileName = fileNames[i];
                        string shortFileName = GetShortFileName(fileName);
                        string iframeUrl = "./source_file.aspx?file=" + fileName;

                        Tab tab = new Tab();
                        tab.Title = shortFileName;
                        tab.EnableIFrame = true;
                        tab.IFrameUrl = iframeUrl;
                        tab.IconUrl = GetIconUrl(tab.IFrameUrl);
                        TabStrip1.Tabs.Add(tab);

                        // End with .aspx.
                        if (fileName.ToLower().EndsWith(".aspx") || fileName.ToLower().EndsWith(".ashx") || fileName.ToLower().EndsWith(".ascx") || fileName.ToLower().EndsWith(".master"))
                        {
                            tab = new FineUI.Tab();
                            tab.Title = shortFileName + ".cs";
                            tab.EnableIFrame = true;
                            tab.IFrameUrl = iframeUrl + ".cs";
                            tab.IconUrl = GetIconUrl(tab.IFrameUrl);
                            TabStrip1.Tabs.Add(tab);
                        }
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string GetIconUrl(string url)
        {
            string suffix = url.Substring(url.LastIndexOf('.') + 1);
            return "~/res/images/filetype/vs_" + suffix + ".png";
            //string fileName = "vs_unknow.png";
            //if (url.EndsWith(".aspx"))
            //{
            //    fileName = "vs_aspx.png";
            //}
            //else if (url.EndsWith(".cs"))
            //{
            //    fileName = "vs_cs.png";
            //}
            //else if (url.EndsWith(".xml"))
            //{
            //    fileName = "vs_xml.png";
            //}
            //else if (url.EndsWith(".config"))
            //{
            //    fileName = "vs_config.png";
            //}
            //else if (url.EndsWith(".js"))
            //{
            //    fileName = "vs_js.png";
            //}
            //else if (url.EndsWith(".css"))
            //{
            //    fileName = "vs_css.png";
            //}
            //else if (url.EndsWith(".html") || url.EndsWith(".htm"))
            //{
            //    fileName = "vs_htm.png";
            //}
        }

        private string GetShortFileName(string fileName)
        {
            int index = fileName.LastIndexOf("/");

            if (index >= 0)
            {
                return fileName.Substring(index + 1);
            }

            return fileName;
        }
    }
}
