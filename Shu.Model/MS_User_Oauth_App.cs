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
    
    public partial class MS_User_Oauth_App
    {
        public int Kid { get; set; }
        public string F_Title { get; set; }
        public string F_ImgUrl { get; set; }
        public string F_AppId { get; set; }
        public string F_AppKey { get; set; }
        public string F_Remark { get; set; }
        public Nullable<int> F_Taxis { get; set; }
        public Nullable<byte> F_IsLock { get; set; }
        public string F_ApiPath { get; set; }
        public Nullable<System.DateTime> F_AddTime { get; set; }
        public Nullable<System.DateTime> F_EditTime { get; set; }
    }
}
