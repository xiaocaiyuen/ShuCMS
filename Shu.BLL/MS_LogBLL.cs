using Shu.Model;
using Shu.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shu.BLL
{
    public partial class MS_LogBLL : BaseBLL<MS_Log>
    {
        /// <summary>
        /// 日志等级枚举
        /// </summary>
        public enum LogLevel
        {
            /// <summary>
            /// 程序漏洞
            /// </summary>
            DEBUG,
            /// <summary>
            /// 消息
            /// </summary>
            INFO,
            /// <summary>
            /// 警告
            /// </summary>
            WARN,
            /// <summary>
            /// 错误事件
            /// </summary>
            ERROR,
            /// <summary>
            /// 致命的错误
            /// </summary>
            FATAL
        }

        #region 基本扩展

        /// <summary>
        /// 添加后台管理员日志．
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="message">信息说明</param>
        public void AddLogAdmin(LogLevel level, string message)
        {
            MS_Log m_log = new MS_Log();

            m_log.F_Type = "admin";
            m_log.F_AddTime = DateTime.Now;
            m_log.F_AdminID = MS_AdminBLL.AdminID;
            m_log.F_Exception = "";
            m_log.F_Level = level.ToString();
            m_log.F_Message = message;
            m_log.F_Source = EKRequest.GetUrl();
            m_log.F_Thread = "1";
            m_log.F_IP = EKRequest.GetIP();

            Add(m_log);

        }

        /// <summary>
        /// 添加前台用户日志．
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="message">信息说明</param>
        public void AddLogUser(LogLevel level, string message)
        {
            MS_Log m_log = new MS_Log();

            m_log.F_Type = "user";
            m_log.F_AddTime = DateTime.Now;
            m_log.F_AdminID = MS_AdminBLL.AdminID;
            m_log.F_Exception = "";
            m_log.F_Level = level.ToString();
            m_log.F_Message = message;
            m_log.F_Source = EKRequest.GetUrl();
            m_log.F_Thread = "1";
            m_log.F_IP = EKRequest.GetIP();

            Add(m_log);

        }

        #endregion
    }
}
