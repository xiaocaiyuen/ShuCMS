using Shu.Model;
using Shu.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Shu.BLL
{
    public partial class MS_AdminBLL : BaseBLL<MS_Admin>
    {
        #region 属性

        /// <summary>
        /// 管理员ID
        /// </summary>
        public static int AdminID
        {
            get
            {
                //管理员
                if (HttpContext.Current.User.Identity.Name == "")
                {
                    return 0;
                }
                FormsAuthenticationTicket ticket = ((FormsIdentity)System.Web.HttpContext.Current.User.Identity).Ticket;
                return ticket.UserData.ToInt(0);
            }
        }

        /// <summary>
        /// 管理员角色ID
        /// </summary>
        public int AdminRoleID
        {
            get
            {
                MS_Admin m_admin = Get(p => p.Kid == AdminID);// BLLAdmin.Get(AdminID);
                if (m_admin == null)
                {
                    return 0;
                }

                string AdminName = m_admin.F_LoginName;

                if (m_admin.F_RoleID == 0)
                {
                    return 0;
                }

                //管理员角色
                return m_admin.F_RoleID;
            }
        }

        #endregion

        #region 基本扩展

        /// <summary>
        /// 根据当前登录角色，禁用角色下拉列表。管理员专用。
        /// </summary>
        /// <param name="_ddl_role">FineUI下拉控件</param>
        /// <param name="_adminRoleID">当前登录角色</param>
        public void AdminDropDownListDisabled(FineUI.DropDownList _ddl_role, int _adminRoleID)
        {
            if (IsSuperAdminRole())
            {
                //超级管理员.不操作.
                return;
            }
            
            //根据登录的角色禁用本级与上级选项
            var list_child = (
                                from r in DBSession.Db.GetParentID_AdminRole(_adminRoleID)
                                select new { r.Kid, r.F_Title }
                              ).ToList();
            //禁用ID列表
            string str_id = "";
            if (IsSuperAdminRole())
            {
                //超级管理员.过滤本身角色.
                list_child = list_child.Where(p => p.Kid.Value != _adminRoleID).ToList();
            }
            else
            {
                //不是超级管理员.顶级角色不可用．
                str_id = "-1,0,";
            }

            foreach (var item in list_child)
            {
                str_id += item.Kid + ",";
            }
            //禁用
            EKFineUIDataControl.DropDownListDisabledSelect(_ddl_role, str_id);
        }

        #endregion

        #region 基本信息获取

        /// <summary>
        /// 根据登录名获取用户对象
        /// </summary>
        /// <param name="loginName">登录名称</param>
        /// <returns></returns>
        public MS_Admin Get(string loginName)
        {
            //List<MS_Admin> list_admin = GetList(p => p.F_LoginName == loginName, p => p.Kid, true).ToList();
            //if (list_admin.Count == 0)
            //{
            //    return new MS_Admin();
            //}

            //return list_admin[0];
            return Get(p => p.F_LoginName == loginName);
        }

        /// <summary>
        /// 当前登录是否为超级管理角色
        /// </summary>
        /// <returns></returns>
        public bool IsSuperAdminRole()
        {

            if (AdminRoleID == MS_ConfigBLL.SuperAdminRoleID)// BLLConfig.SuperAdminRoleID)
            {
                //超级管理员角色id 1
                return true;
            }

            return false;
        }

        /// <summary>
        /// 判断角色ID是否为超级管理角色
        /// </summary>
        /// <param name="roleid">判断角色ID</param>
        /// <returns></returns>
        public static bool IsSuperAdminRole(int roleid)
        {

            if (roleid == MS_ConfigBLL.SuperAdminRoleID)
            {
                //超级管理员角色id 1
                return true;
            }

            return false;
        }

        #endregion

        #region 登录

        /// <summary>
        /// 登录成功
        /// </summary>
        /// <param name="user"></param>
        public void LoginSuccess(MS_Admin admin)
        {
            //更新信息
            admin.F_LastLoginTime = admin.F_ThisLoginTime;
            admin.F_LastLoginIP = admin.F_ThisLoginIP;

            admin.F_ThisLoginTime = DateTime.Now;
            admin.F_ThisLoginIP = EKRequest.GetIP();
            admin.F_LoginCount += 1;
            Update(admin);


            //票证
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                MS_ConfigBLL.AdminPath,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                true,
                admin.Kid.ToString(),
                FormsAuthentication.FormsCookiePath);
            string hashTicket = FormsAuthentication.Encrypt(ticket);

            //写cookie
            HttpCookie adminCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
            adminCookie.HttpOnly = true;
            adminCookie.Expires = DateTime.Now.Add(FormsAuthentication.Timeout);//分单位
            adminCookie.Domain = FormsAuthentication.CookieDomain;
            adminCookie.Path = FormsAuthentication.FormsCookiePath;

            HttpContext.Current.Response.Cookies.Add(adminCookie);
            System.Web.HttpContext.Current.Response.Redirect(FormsAuthentication.DefaultUrl);


            //string userRoles = UserToRole(user); //调用UserToRole方法来获取role字符串
            //FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, user, DateTime.Now, DateTime.Now.AddMinutes(30), false, userRoles, "/");//建立身份验证票对象
            //string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串
            //HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);
            ////生成Cookie
            //Context.Response.Cookies.Add(UserCookie); //输出Cookie
            //Context.Response.Redirect(Context.Request["ReturnUrl"]); // 重定向到用户申请的初始页面
        }

        /// <summary>
        /// 管理员退出
        /// </summary>
        /// <returns></returns>
        public static void LoginOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// 检查是否登录
        /// </summary>
        public static bool IsLogin()
        {
            return System.Web.HttpContext.Current.Request.IsAuthenticated;
        }

        /// <summary>
        /// 检查管理员是否 启用
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEnabled()
        {
            MS_Admin m_admin = Get(p => p.Kid == AdminID);

            if (m_admin == null)
            {
                return false;
            }
            return m_admin.F_Enabled;
        }

        #endregion
    }
}
