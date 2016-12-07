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

        #region ************�ļ����� ****************

        /// <summary>
        /// �õ��ļ�����ȫ���� 
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <returns></returns>
        public static string FullFileName(string path)
        {
            return Path.GetFileName(path);//path�����ھͷ���path
        }

        /// <summary>
        /// �Ƿ�����ļ�
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
        /// <returns></returns>
        public static bool ExistFile(string filepath)
        {
            return File.Exists(filepath);
        }

        /// <summary>
        /// д�ļ�
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
        /// <param name="context">����</param>
        public static void WriteFile(string filepath, string context)
        {
            if (File.Exists(filepath)) /*�ж��ļ��Ƿ����*/
            {
                //����                
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
                //������,����                    
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
        /// ���ļ�
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
        /// <returns></returns>
        public static string ReadFile(string filepath)
        {
            return File.ReadAllText(filepath, Encoding.Default);
        }

        /// <summary>
        /// ���ļ�
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
        /// <returns></returns>
        public static string ReadFile(string filepath, string encoding)
        {
            return File.ReadAllText(filepath, Encoding.GetEncoding(encoding));
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
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
        /// �����ļ�,�����ǵ��ļ����Ƶ�һ�����ļ�,���ļ�����Ѿ�������ô�͹���
        /// </summary>
        /// <param name="filepath">Դ�ļ�·��</param>
        /// <param name="path">Ŀ���ļ�·��,������Ŀ¼</param>
        /// <returns></returns>
        public static bool CopyFile(string filepath, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Copy(filepath, path);
                    return true;//���Ƴɹ���
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
        /// �޸��ļ�����
        /// </summary>
        /// <param name="oldName">���ļ�����</param>
        /// <param name="newsName">���ļ�����</param>
        public static void Rename(string oldName,string newsName)
        {
            File.Move(oldName, newsName);
        }

        /// <summary>
        /// ת���ļ�
        /// </summary>
        /// <param name="filepath">Դ�ļ�</param>
        /// <param name="path">Ŀ���ļ�</param>
        /// <returns></returns>
        public static void MoveFile(string filepath, string path)
        {
            File.Move(filepath, path);
        }

        /// <summary>
        /// ��õ�ǰ����·��
        /// </summary>
        /// <param name="strPath">ָ����·��</param>
        /// <returns>����·��</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //��web��������
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
        /// ��ȡĳĿ¼�µ������ļ�(������Ŀ¼���ļ�)������  
        /// </summary>
        /// <param name="Path">Ŀ¼·��</param>
        /// <returns></returns>
        public static int GetFileNum(string Path)
        {
            int fileNum = 0;
            string[] fileList = System.IO.Directory.GetFileSystemEntries(Path);
            // �������е��ļ���Ŀ¼
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
        /// ��ȡĳĿ¼�µ������ļ�(������Ŀ¼���ļ�)�Ĵ�С
        /// </summary>
        /// <param name="dirPath">Ŀ¼·��</param>
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
        /// ��ȡ�ļ���С
        /// </summary>
        /// <param name="filepath">�ļ�·��</param>
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
        /// ����Url���Դ�ļ�����
        /// </summary>
        /// <param name="url">�Ϸ���Url��ַ</param>
        /// <returns></returns>
        public static string GetSourceTextByUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            request.Timeout = 20000;//20�볬ʱ
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


        #region ************Ŀ¼���� ****************

        /// <summary>
        /// �õ����д���������
        /// </summary>
        /// <returns></returns>
        public static string[] AllDrivers()
        {
            return Directory.GetLogicalDrives();
        }

        /// <summary>
        /// Ӧ�ó���ĵ�ǰ����Ŀ¼��bin�ļ���
        /// </summary>
        /// <returns></returns>
        public static string CurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// ��ȡpathĿ¼�µ��ļ����������ļ���
        /// </summary>
        /// <param name="path">Ŀ¼·��</param>
        /// <returns></returns>
        public static string[] AllFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /// <summary>
        /// ����һ��Ŀ¼���directory���ڣ���ô�Ͳ�����Ŀ¼
        /// </summary>
        /// <param name="directory"></param>
        public static void CreateDirectory(string directory)
        {
            //DirectoryInfo info = new DirectoryInfo(directory);         
            //info.Create();

            DirectoryInfo info = Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// ����Ŀ¼���������ļ�
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
        /// �Ƿ����Ŀ¼
        /// </summary>
        /// <param name="path">Ŀ¼·��</param>
        /// <returns></returns>
        public static bool ExistsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// ɾ��Ŀ¼
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(string path)
        {
            //Directory.Delete(path, false/*ɾ����Ŀ¼*/);   //��Ŀ¼�ǿ��򱨴�
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true/*������Ŀ¼*/);
            }
        }

        /// <summary>
        /// ɾ��Ŀ¼��Ŀ¼�´����ļ���ȫ��ɾ��������ɾ������Ŀ¼
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static int DeleteDirectoryAnd(string Path)
        {
            int fileNum = 0;
            string[] fileList = System.IO.Directory.GetFileSystemEntries(Path);
            // �������е��ļ���Ŀ¼
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
        /// Ŀ¼�µ������ļ��������ļ�Ҳ�ɼ�
        /// </summary>
        /// <param name="path">Ŀ¼·��</param>
        /// <returns></returns>
        public static string[] AllContent(string path)
        {
            return Directory.GetFileSystemEntries(path);//���path�������򱨴�
        }

        /// <summary>
        /// ת���ļ�Ŀ¼��ת�����ԭĿ¼ɾ��
        /// </summary>
        /// <param name="sourcePath">ԴĿ¼</param>
        /// <param name="targetPath">Ŀ��Ŀ¼</param>
        public static void MoveDirectory(string sourcePath/*����ǰ�������,������ɺ�ҵ���*/, string targetPath)
        {
            Directory.Move(sourcePath, targetPath);
        }

        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="SourceDirectory">ԴĿ¼</param>
        /// <param name="TargetDirectory">��Ŀ¼</param>
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

            //�����ļ�
            FileInfo[] sourceFiles = source.GetFiles();
            for (int i = 0; i < sourceFiles.Length; ++i)
            {
                File.Copy(sourceFiles[i].FullName, target.FullName + "\\" + sourceFiles[i].Name, true);
            }

            //����Ŀ¼ 
            DirectoryInfo[] sourceDirectories = source.GetDirectories();
            for (int j = 0; j < sourceDirectories.Length; ++j)
            {
                CopyDirectory(sourceDirectories[j].FullName, target.FullName + "\\" + sourceDirectories[j].Name);
            }
        }

        #endregion


        #region **************XML����*****************

        /// <summary>
        /// DataSet���XML��ʽ�ĵ�
        /// </summary>
        /// <param name="filepath">XML�ļ�·��</param>
        public static void WriteDataSetToXml(string filepath)
        {
            DataSet ds = new DataSet();

            EKFile.GetMapPath(filepath);
            //����XML����
            XmlTextWriter xml = new XmlTextWriter(filepath, Encoding.Default);

            try
            {
                //���÷��ظ�ʽ
                xml.Formatting = Formatting.Indented;
                xml.Indentation = 4;//����
                xml.IndentChar = ' ';
                xml.WriteStartDocument();
                //���XML��ʽ���� ���ͻ���
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


        #region **************HTML����*****************


        /// <summary>
        /// ��ȡҳ��Դ�ļ�
        /// </summary>
        /// <param name="url">ҳ��·��</param>
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
        /// Զ�̵�¼,����cookie����ȡҳ��Դ����
        /// </summary>
        /// <param name="url">��ַ</param>
        /// <param name="paramList">����</param>
        /// <returns>ҳ��html</returns>
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

        /// <summary> ��ȡҳ��HTML
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


        #region ��������

        /// <summary> 
        /// ���������㷨.��������Ϊ���ȶ�����,ʱ�临�Ӷ�O(nlog2n),Ϊͬ���������������򷽷� 
        /// </summary> 
        /// <param name="arr">���ֵ�����</param> 
        /// <param name="low">����Ͷ��ϱ�</param> 
        /// <param name="high">����߶��±�</param> 
        /// <param name="strOrder"></param>
        /// <returns></returns> 
        private static int Partition<T>(T[] arr, int low, int high, string strOrder)
        {
            //����һ�˿�������,�����������¼λ�� 
            // arr[0] = arr[low]; 
            T pivot = arr[low];//������������arr[0] 
            while (low < high)
            {
                while (low < high && Convert.ToDateTime(arr[high].GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, arr[high], null)) >= Convert.ToDateTime(pivot.GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, pivot, null)))
                    --high;
                //�����������¼С���Ƶ��Ͷ� 
                Swap(ref arr[high], ref arr[low]);

                while (low < high && Convert.ToDateTime(arr[low].GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, arr[low], null)) <= Convert.ToDateTime(pivot.GetType().InvokeMember(strOrder, System.Reflection.BindingFlags.GetProperty, null, pivot, null)))
                    ++low;
                //�����������¼����Ƶ��߶� 
                Swap(ref arr[high], ref arr[low]);
            }
            arr[low] = pivot; //�������Ƶ���ȷλ��

            return low; //����������λ�� 
        }

        /// <summary> 
        /// �ļ��������򣬰�����ʱ������
        /// </summary> 
        /// ��������Ϊ���ȶ�����,ʱ�临�Ӷ�O(nlog2n),Ϊͬ���������������򷽷� 
        /// <param name="arr">���ֵ�����</param> 
        /// <param name="low">����Ͷ��ϱ�</param> 
        /// <param name="high">����߶��±�</param> 
        public static void QuickSort<T>(T[] arr, int low, int high, string strOrder)
        {
            if (low <= high - 1)//�� arr[low,high]Ϊ�ջ�ֻһ����¼�������� 
            {
                int pivot = Partition(arr, low, high, strOrder);
                QuickSort(arr, low, pivot - 1,strOrder);
                QuickSort(arr, pivot + 1, high,strOrder);
            }
        }

        /// <summary>
        /// �������󽻻�λ��
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="i">����1</param>
        /// <param name="j">����2</param>
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
