//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shu.Model
{
    
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class MS_Admin
    {
        public int Kid { get; set; }
        public string F_Number { get; set; }
        public int F_RoleID { get; set; }
        public string F_LoginName { get; set; }
        public string F_Password { get; set; }
        public string F_Email { get; set; }
        public string F_Sex { get; set; }
        public string F_RealName { get; set; }
        public string F_QQ { get; set; }
        public string F_MSN { get; set; }
        public string F_CellPhone { get; set; }
        public string F_OfficePhone { get; set; }
        public string F_HomePhone { get; set; }
        public string F_Remark { get; set; }
        public Nullable<int> F_DeptID { get; set; }
        public bool F_Enabled { get; set; }
        public Nullable<System.DateTime> F_AddTime { get; set; }
        public Nullable<System.DateTime> F_EditTime { get; set; }
        public Nullable<System.DateTime> F_LastLoginTime { get; set; }
        public string F_LastLoginIP { get; set; }
        public Nullable<System.DateTime> F_ThisLoginTime { get; set; }
        public string F_ThisLoginIP { get; set; }
        public Nullable<int> F_LoginCount { get; set; }
    }
}
