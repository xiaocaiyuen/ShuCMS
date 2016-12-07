using Shu.Model;
using Shu.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shu.BLL
{
    public partial class MS_ConfigBLL:BaseBLL<MS_Config>
    {
        #region 基本信息获取

        /// <summary>
        /// 根据key获取对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public MS_Config Get(string key)
        {
            MS_Config m_config = Get(p => p.F_Key == key);
            if (m_config == null)
            {
                return new MS_Config();
            }

            return m_config;
        }

        /// <summary>
        /// 根据key获取value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            MS_Config m_config = Get(key);
            if (m_config == null)
            {
                return "";
            }
            return m_config.F_Value;
        }

        #endregion


        #region 网站基本

        /// <summary>
        /// 网站域名
        /// </summary>
        public static string WebUrl
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["WebUrl"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 网站身份模式.0使用cookie 1使用session
        /// </summary>
        public static string SessionModel
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["SessionModel"].ToString(); }
                catch
                {
                    return "0";
                }
            }
        }

        /// <summary>
        /// 超级管理员ID
        /// </summary>
        public static int SuperAdminID
        {
            get
            {
                try { return EKTypeParse.StrToInt(System.Configuration.ConfigurationManager.AppSettings["SuperAdminID"].ToString(), 1); }
                catch
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// 超级管理角色ID
        /// </summary>
        public static int SuperAdminRoleID
        {
            get
            {
                try { return Utility.EKTypeParse.StrToInt(System.Configuration.ConfigurationManager.AppSettings["SuperAdminRoleID"].ToString(), 1); }
                catch
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// 获取管理员后台文件夹路径
        /// </summary>
        public static string AdminPath
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["AdminPath"].ToString(); }
                catch
                {
                    return "admin";
                }
            }
        }

        /// <summary>
        /// 获取用户后台文件夹路径
        /// </summary>
        public static string UserPath
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["UserPath"].ToString(); }
                catch
                {
                    return "user";
                }
            }
        }

        #endregion

        #region 邮箱

        /// <summary>
        /// 是否启用邮箱功能
        /// </summary>
        public static string IsOpenEmail
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["IsOpenEmail"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 邮箱服务器地址
        /// </summary>
        public static string EmailHost
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["EmailHost"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 邮箱帐户
        /// </summary>
        public static string EmailUserName
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["EmailUserName"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 邮箱密码
        /// </summary>
        public static string EmailUserPass
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["EmailUserPass"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 发送邮箱地址
        /// </summary>
        public static string FromEmail
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["FromEmail"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 接收邮箱地址
        /// </summary>
        public static string ToEmail
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["ToEmail"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 邮箱是否加密
        /// </summary>
        public static string EmailEncrypt
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["EmailEncrypt"].ToString(); }
                catch
                {
                    return "";
                }
            }
        }

        #endregion

        #region 文件上传

        /// <summary>
        /// 文件上传路径
        /// </summary>
        public static string UploadPath
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["UploadPath"].ToString(); }
                catch
                {
                    return "upload";
                }
            }
        }

        /// <summary>
        /// 文件上传类型
        /// </summary>
        public static string UploadType
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["UploadType"].ToString(); }
                catch
                {
                    return "JPG|GIF|PNG|JPEG|RAR|ZIP|DOC|DOCX|XLS|PDF|PSD|TXT|PPT|CDR|SWF|DWF|BMP|FLV";
                }
            }
        }

        /// <summary>
        /// 图片上传类型
        /// </summary>
        public static string UploadImageType
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["UploadImageType"].ToString(); }
                catch
                {
                    return "JPG|GIF|PNG|JPEG|BMP";
                }
            }
        }

        /// <summary>
        /// 文件上传大小
        /// </summary>
        public static int UploadSize
        {
            get
            {
                try { return int.Parse(System.Configuration.ConfigurationManager.AppSettings["UploadSize"].ToString()); }
                catch
                {
                    return 2097151;//2G
                }
            }
        }

        /// <summary>
        /// 文件上传图片 缩略图宽度 px
        /// </summary>
        public static int UploadWidth
        {
            get
            {
                try { return int.Parse(System.Configuration.ConfigurationManager.AppSettings["UploadWidth"].ToString()); }
                catch
                {
                    return 150;
                }
            }
        }

        /// <summary>
        /// 文件上传图片 缩略图高度 px
        /// </summary>
        public static int UploadHeight
        {
            get
            {
                try { return int.Parse(System.Configuration.ConfigurationManager.AppSettings["UploadHeight"].ToString()); }
                catch
                {
                    return 150;
                }
            }
        }

        /// <summary>
        /// 文件中等缩略图路径
        /// </summary>
        public static string UploadPath_Z
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["UploadPath_Z"].ToString(); }
                catch
                {
                    return "upload_z";
                }
            }
        }

        /// <summary>
        /// 文件小缩略图路径
        /// </summary>
        public static string UploadPath_X
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["UploadPath_X"].ToString(); }
                catch
                {
                    return "upload_x";
                }
            }
        }

        #endregion

        #region 其他


        /// <summary>
        /// 加密密钥
        /// </summary>
        public static string EncryptKey
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["EncryptKey"].ToString(); }
                catch
                {
                    return "MSMS1101";//8位
                }
            }
        }


        /// <summary>
        /// WebService 密匙
        /// </summary>
        public static string WebServiceKey
        {
            get
            {
                try { return System.Configuration.ConfigurationManager.AppSettings["WebServiceKey"].ToString(); }
                catch
                {
                    return "MSMS1102";//8位
                }
            }
        }

        /// <summary>
        /// 获取web.config指定值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetConfigValue(string key)
        {
            try { return System.Configuration.ConfigurationManager.AppSettings[key].ToString(); }
            catch
            {
                return "";
            }
        }

        #endregion
    }
}
