using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Xml;
using System.Data;
using System.Net;

namespace Shu.Utility
{
    public class EKFile
    {
        /// <summary>
        /// 
        /// </summary>
        public EKFile()
        {
        }

        #region ************文件操作 ****************

        /// <summary>
        /// 得到文件的完全名字 
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string FullFileName(string path)
        {
            return Path.GetFileName(path);//path不存在就返回path
        }

        /// <summary>
        /// 是否存在文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static bool ExistFile(string filepath)
        {
            return File.Exists(filepath);
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="context">内容</param>
        public static void WriteFile(string filepath, string context)
        {
            if (File.Exists(filepath)) /*判断文件是否存在*/
            {
                //存在                
                using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.Default))
                {
                    sw.WriteLine(context);
                    sw.Dispose();
                    sw.Close();
                }
            }
            else
            {
                FileInfo file = new FileInfo(filepath);
                //不存在,创建                    
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }

                using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.Default))
                {
                    sw.WriteLine(context);
                    sw.Dispose();
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string filepath)
        {
            return File.ReadAllText(filepath, Encoding.Default);
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string filepath, string encoding)
        {
            return File.ReadAllText(filepath, Encoding.GetEncoding(encoding));
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 复制文件,将我们的文件复制到一个新文件,新文件如果已经存在那么就挂了
        /// </summary>
        /// <param name="filepath">源文件路径</param>
        /// <param name="path">目标文件路径,不能是目录</param>
        /// <returns></returns>
        public static bool CopyFile(string filepath, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Copy(filepath, path);
                    return true;//复制成功了
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改文件名称
        /// </summary>
        /// <param name="oldName">旧文件名称</param>
        /// <param name="newsName">新文件名称</param>
        public static void Rename(string oldName,string newsName)
        {
            File.Move(oldName, newsName);
        }

        /// <summary>
        /// 转移文件
        /// </summary>
        /// <param name="filepath">源文件</param>
        /// <param name="path">目标文件</param>
        /// <returns></returns>
        public static void MoveFile(string filepath, string path)
        {
            File.Move(filepath, path);
        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 获取某目录下的所有文件(包括子目录下文件)的数量  
        /// </summary>
        /// <param name="Path">目录路径</param>
        /// <returns></returns>
        public static int GetFileNum(string Path)
        {
            int fileNum = 0;
            string[] fileList = System.IO.Directory.GetFileSystemEntries(Path);
            // 遍历所有的文件和目录
            foreach (string file in fileList)
            {
                if (System.IO.Directory.Exists(file))
                {
                    GetFileNum(file);
                }
                else
                {
                    fileNum++;
                }
            }
            return fileNum;
        }

        /// <summary>
        /// 获取某目录下的所有文件(包括子目录下文件)的大小
        /// </summary>
        /// <param name="dirPath">目录路径</param>
        /// <returns></returns>
        public static long GetDirectoryLength(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                return 0;
            }
            long len = 0;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static long GetFileLength(string filepath)
        {
            if(!File.Exists(filepath)){
                return 0;
            }
            FileInfo myInfo = new FileInfo(filepath);
            return myInfo.Length;
        }

        /// <summary>
        /// 根据Url获得源文件内容
        /// </summary>
        /// <param name="url">合法的Url地址</param>
        /// <returns></returns>
        public static string GetSourceTextByUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            request.Timeout = 20000;//20秒超时
            try
            {
                response = request.GetResponse();
            }
            catch
            {
                return "";
            }
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.Default);

            return sr.ReadToEnd();
        }
        #endregion


        #region ************目录操作 ****************

        /// <summary>
        /// 得到所有磁盘驱动器
        /// </summary>
        /// <returns></returns>
        public static string[] AllDrivers()
        {
            return Directory.GetLogicalDrives();
        }

        /// <summary>
        /// 应用程序的当前工作目录，bin文件夹
        /// </summary>
        /// <returns></returns>
        public static string CurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// 获取path目录下的文件，不包括文件夹
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns></returns>
        public static string[] AllFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /// <summary>
        /// 创建一个目录如果directory存在，那么就不创建目录
        /// </summary>
        /// <param name="directory"></param>
        public static void CreateDirectory(string directory)
        {
            //DirectoryInfo info = new DirectoryInfo(directory);         
            //info.Create();

            DirectoryInfo info = Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// 创建目录，不创建文件
        /// </summary>
        /// <param name="dirName"></param>
        public static void DoCreatrDir(string dirName)
        {
            string[] adir = dirName.Split("/".ToCharArray());
            string DirFile = adir[0];
            for (int i = 1; i < adir.Length - 1; i++)
            {
                DirFile += "/" + adir[i];
                if (!Directory.Exists(DirFile))
                {
                    Directory.CreateDirectory(DirFile);

                }
            }
        }

        /// <summary>
        /// 是否存在目录
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns></returns>
        public static bool ExistsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(string path)
        {
            //Directory.Delete(path, false/*删除子目录*/);   //子目录非空则报错。
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true/*保留子目录*/);
            }
        }

        /// <summary>
        /// 删除目录，目录下存在文件．全部删除．但不删除本身目录
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static int DeleteDirectoryAnd(string Path)
        {
            int fileNum = 0;
            string[] fileList = System.IO.Directory.GetFileSystemEntries(Path);
            // 遍历所有的文件和目录
            foreach (string file in fileList)
            {
                if (System.IO.Directory.Exists(file))
                {
                    DeleteDirectoryAnd(file);
                }
                else
                {
                    fileNum++;
                    EKFile.DeleteFile(file);
                }
            }
            return fileNum;
        }

        /// <summary>
        /// 目录下的所有文件，隐藏文件也可见
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns></returns>
        public static string[] AllContent(string path)
        {
            return Directory.GetFileSystemEntries(path);//如果path不存在则报错
        }

        /// <summary>
        /// 转移文件目录，转移完成原目录删除
        /// </summary>
        /// <param name="sourcePath">源目录</param>
        /// <param name="targetPath">目标目录</param>
        public static void MoveDirectory(string sourcePath/*复制前必须存在,复制完成后挂掉了*/, string targetPath)
        {
            Directory.Move(sourcePath, targetPath);
        }

        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="SourceDirectory">源目录</param>
        /// <param name="TargetDirectory">新目录</param>
        public static void CopyDirectory(string SourceDirectory, string TargetDirectory)
        {
            DirectoryInfo source = new DirectoryInfo(SourceDirectory);
            DirectoryInfo target = new DirectoryInfo(TargetDirectory);

            if (!source.Exists)
            {
                return;
            }

            if (!target.Exists)
            {
                target.Create();
            }

            //复制文件
            FileInfo[] sourceFiles = source.GetFiles();
            for (int i = 0; i < sourceFiles.Length; ++i)
            {
                File.Copy(sourceFiles[i].FullName, target.FullName + "\\" + sourceFiles[i].Name, true);
            }

            //复制目录 
            DirectoryInfo[] sourceDirectories = source.GetDirectories();
            for (int j = 0; j < sourceDirectories.Length; ++j)
            {
                CopyDirectory(sourceDirectories[j].FullName, target.FullName + "\\" + sourceDirectories[j].Name);
            }
        }

        #endregion


        #region **************XML操作*****************

        /// <summary>
        /// DataSet输出XML格式文档
        /// </summary>
        /// <param name="filepath">XML文件路径</param>
        public static void WriteDataSetToXml(string filepath)
        {
            DataSet ds = new DataSet();

            EKFile.GetMapPath(filepath);
            //创建XML对象
            XmlTextWriter xml = new XmlTextWriter(filepath, Encoding.Default);

            try
            {
                //设置返回格式
                xml.Formatting = Formatting.Indented;
                xml.Indentation = 4;//缩进
                xml.IndentChar = ' ';
                xml.WriteStartDocument();
                //输出XML格式数据 到客户端
                ds.WriteXml(xml);
            }
            catch
            {
            }
            finally
            {
                xml.Flush();
                xml.Close();
            }
        }

        #endregion


        #region **************HTML操作*****************


        /// <summary>
        /// 获取页面源文件
        /// </summary>
        /// <param name="url">页面路径</param>
        /// <returns></returns>
        public static string GetHTMLPage(string url)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();
                System.IO.StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.Default);
                string content = streamReader.ReadToEnd();
                streamReader.Close();
                webResponse.Close();
                streamReader.Dispose();
                stream.Close();
                stream.Dispose();
                return content;
            }
            catch { return ""; }
        }

        static string cookieheader = "";

        /// <summary> 
        /// 远程登录,保存cookie，获取页面源代码
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="paramList">参数</param>
        /// <returns>页面html</returns>
        //public static string Login(String url, String paramList)
        //{
        //    HttpWebResponse res = null;
        //    string strResult = "";
        //    try
        //    {
        //        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        //        req.Method = "POST";
        //        req.ContentType = "application/x-www-form-urlencoded";
        //        req.AllowAutoRedirect = false;

        //        CookieContainer cookieCon = new CookieContainer();
        //        // cookieCon.Add(new Uri(url), new System.Net.Cookie("uid", "tIv2DuvAiKQ="));

        //        /*
        //        cookieCon.Add(new Uri(url), new System.Net.Cookie("userid", "1281767242922_8055"));
        //        cookieCon.Add(new Uri(url), new System.Net.Cookie("weather_city", "zj_hz"));
        //        cookieCon.Add(new Uri(url), new System.Net.Cookie("vjlast", "1281880468.1281880468.30"));
        //        cookieCon.Add(new Uri(url), new System.Net.Cookie("vjuids", "1002d764e.12a7607ab72.0.1415981f804544"));
        //        cookieCon.Add(new Uri(url), new System.Net.Cookie("sid", "4EF34D1831820D1B78E2895C5AD16DDBwjlkingwjl"));

        //        cookieCon.Add(new Uri(url), new System.Net.Cookie("Q37_auth", "NqUElcr3SuhJNF1OEDEK6p3rIgmaCkJknudxRQ"));
        //        cookieCon.Add(new Uri(url), new System.Net.Cookie("Q37_sid", "Mzkio2"));*/
        //        cookieCon = Cookie.AddCookie(url, System.Web.HttpContext.Current.Request.Cookies);

        //        req.CookieContainer = cookieCon;

        //        StringBuilder UrlEncoded = new StringBuilder();
        //        Char[] reserved = { '?', '=', '&' };
        //        byte[] SomeBytes = null;
        //        if (paramList != null)
        //        {
        //            int i = 0, j;
        //            while (i < paramList.Length)
        //            {
        //                j = paramList.IndexOfAny(reserved, i);
        //                if (j == -1)
        //                {
        //                    UrlEncoded.Append(HttpUtility.UrlEncode(paramList.Substring(i, paramList.Length - i)));
        //                    break;
        //                }
        //                UrlEncoded.Append(HttpUtility.UrlEncode(paramList.Substring(i, j - i)));
        //                UrlEncoded.Append(paramList.Substring(j, 1));
        //                i = j + 1;
        //            }
        //            SomeBytes = Encoding.Default.GetBytes(UrlEncoded.ToString());
        //            req.ContentLength = SomeBytes.Length;
        //            Stream newStream = req.GetRequestStream();
        //            newStream.Write(SomeBytes, 0, SomeBytes.Length);
        //            newStream.Close();
        //        }
        //        else
        //        {
        //            req.ContentLength = 0;
        //        }

        //        res = (HttpWebResponse)req.GetResponse();
        //        cookieheader = req.CookieContainer.GetCookieHeader(new Uri(url));
        //        Stream ReceiveStream = res.GetResponseStream();
        //        Encoding encode = System.Text.Encoding.Default;
        //        StreamReader sr = new StreamReader(ReceiveStream, encode);
        //        //StreamReader sr = new StreamReader(ReceiveStream,Encoding.Default);
        //        Char[] read = new Char[256];
        //        int count = sr.Read(read, 0, 256);
        //        while (count > 0)
        //        {
        //            String str = new String(read, 0, count);
        //            strResult += str;
        //            count = sr.Read(read, 0, 256);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        strResult = e.ToString();
        //    }
        //    finally
        //    {
        //        if (res != null)
        //        {
        //            res.Close();
        //        }
        //    }
        //    return strResult;
        //}

        /// <summary> 获取页面HTML
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static string GetPage(String url, String paramList)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Referer = url;
            CookieContainer cookieCon = new CookieContainer();
            req.CookieContainer = cookieCon;
            req.CookieContainer.SetCookies(new Uri(url), cookieheader);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.Default);
            string strResult = sr.ReadToEnd();
            sr.Close();
            return strResult;
        }

        #endregion


        #region 数组排序

        /// <summary> 
        /// 快速排序算法.快速排序为不稳定排序,时间复杂度O(nlog2n),为同数量级中最快的排序方法 
        /// </summary> 
        /// <param name="arr">划分的数组</param> 
        /// <param name="low">数组低端上标</param> 
        /// <param name="high">数组高端下标</param> 
        /// <param name="strOrder"></param>
        /// <returns></returns> 
        private static int Partition<T>(T[] arr, int low, int high, string strOrder)
        {
            //进行一趟快速排序,返回中心轴记录位置 
            // arr[0] = arr[low]; 
            T pivot = arr[low];//把中心轴置于arr[0] 
            while (low < high)
            {
                while (low < high && Convert.ToDateTime(arr[high].GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, arr[high], null)) >= Convert.ToDateTime(pivot.GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, pivot, null)))
                    --high;
                //将比中心轴记录小的移到低端 
                Swap(ref arr[high], ref arr[low]);

                while (low < high && Convert.ToDateTime(arr[low].GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, arr[low], null)) <= Convert.ToDateTime(pivot.GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, pivot, null)))
                    ++low;
                //将比中心轴记录大的移到高端 
                Swap(ref arr[high], ref arr[low]);
            }
            arr[low] = pivot; //中心轴移到正确位置

            return low; //返回中心轴位置 
        }

        /// <summary> 
        /// 文件快速排序，按创建时间升序
        /// </summary> 
        /// 快速排序为不稳定排序,时间复杂度O(nlog2n),为同数量级中最快的排序方法 
        /// <param name="arr">划分的数组</param> 
        /// <param name="low">数组低端上标</param> 
        /// <param name="high">数组高端下标</param> 
        public static void QuickSort<T>(T[] arr, int low, int high, string strOrder)
        {
            if (low <= high - 1)//当 arr[low,high]为空或只一个记录无需排序 
            {
                int pivot = Partition(arr, low, high, strOrder);
                QuickSort(arr, low, pivot - 1,strOrder);
                QuickSort(arr, pivot + 1, high,strOrder);
            }
        }

        /// <summary>
        /// 二个对象交换位置
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="i">对象1</param>
        /// <param name="j">对象2</param>
        private static void Swap<T>(ref T i, ref T j)
        {
            T t;
            t = i;
            i = j;
            j = t;
        }

        #endregion
    }
}
