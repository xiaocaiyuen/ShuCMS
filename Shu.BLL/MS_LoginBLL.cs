using Shu.Model;
using Shu.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shu.BLL
{
    public partial class MS_LoginBLL : BaseBLL<MS_Login>
    {
        #region 基本扩展

        /// <summary>
        /// 验证登陆错误次数．是否锁定
        /// </summary>
        /// <param name="datatime">当前时间</param>
        /// <param name="MinutesCount">多少分钟内</param>
        /// <param name="Number">错误次数</param>
        /// <param name="adminName">管理员登陆名</param>
        /// <returns></returns>
        public bool LoginErrorLock(string adminName, int MinutesCount, int Number)
        {
            string IP = EKRequest.GetIP();
            DateTime time_now = DateTime.Now;
            DateTime time_newdete = time_now.AddMinutes(-MinutesCount);
            return DBSession.MS_LoginDal.GetCount(p => p.F_IP == IP && p.F_Time >= time_newdete && p.F_Time <= time_now && p.F_AdminName == adminName) > Number;// _BLLLoginBase.GetCount(p => p.F_IP == IP && p.F_Time >= time_newdete && p.F_Time <= time_now && p.F_AdminName == adminName) > Number;
        }


        /// <summary>
        /// 登陆错误插入数据
        /// </summary>
        public void LoginAddError(string adminName)
        {
            MS_Login login = new MS_Login();
            login.F_AdminName = adminName;
            login.F_IP = EKRequest.GetIP();
            login.F_Time = DateTime.Now;
            DBSession.MS_LoginDal.Add(login);
        }

        #endregion
    }
}
