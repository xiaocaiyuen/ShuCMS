using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FineUI;

using Shu.BLL;
using Shu.Utility;

using System.Security.Principal;
using Shu.Model;

namespace Shu.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(EKRequest.GetPageName());
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string adminName = tbxUserName.Text.Trim();
            string password = tbxPassword.Text.Trim();

            MS_LoginBLL BLLLogin = new MS_LoginBLL();

            //为空
            if (adminName == "")
            {
                Alert.Show("请输入用户名！");
                return;
            }
            if (password == "")
            {
                Alert.Show("请输入密码！");
                return;
            }

            //长度
            if (adminName.Length > 50)
            {
                Alert.Show("用户名过长！");
                return;
            }
            if (password.Length > 50)
            {
                Alert.Show("密码过长！");
                return;
            }

            if (BLLLogin.LoginErrorLock(adminName, 3, 3))
            {
                Alert.Show("登录失败：登陆错误次数超过三次，请过5分钟重新登陆");
                return;
            }
            //MS_AdminBLL BLLAdmin = new MS_AdminBLL();

            MS_Admin m_admin = new MS_AdminBLL().Get(adminName);
            if (m_admin != null && m_admin.F_LoginName == adminName)
            {
                if (EKPasswordUtil.ComparePasswords(m_admin.F_Password, password))
                {
                    if (!m_admin.F_Enabled)
                    {
                        logger.Error("用户: " + m_admin.F_LoginName + " 未启用，请联系管理员！");

                        Alert.Show("用户未启用，请联系管理员！");
                        return;
                    }
                    else
                    {
                        //登录成功
                        logger.Info(String.Format("登录成功：用户“{0}”，登录IP：" + EKRequest.GetIP() + "", m_admin.F_LoginName));
                        new MS_AdminBLL().LoginSuccess(m_admin);
                        return;
                    }
                }
                else
                {
                    BLLLogin.LoginAddError(adminName);
                    logger.Warn(String.Format("登录失败：用户“{0}”密码错误", adminName));
                    Alert.Show("用户名或密码错误！");
                    return;
                }


            }
            else
            {
                BLLLogin.LoginAddError(adminName);
                logger.Warn(String.Format("登录失败：用户“{0}”不存在", adminName));
                Alert.ShowInTop("用户名或密码错误！");
            }
        }
    }
}