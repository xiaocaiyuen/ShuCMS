using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Shu.Manage
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["OnlineUserCount"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // 这种统计在线人数的做法会有一定的误差
            Application.Lock();
            Application["OnlineUserCount"] = (int)Application["OnlineUserCount"] + 1;
            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnlineUserCount"] = (int)Application["OnlineUserCount"] - 1;
            Application.UnLock();
        }
    }
}