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
    
    public partial class MS_Recruitment
    {
        public int Kid { get; set; }
        public string F_Title { get; set; }
        public string F_Content { get; set; }
        public string F_LinkMan { get; set; }
        public string F_ContactPhone { get; set; }
        public string F_WorkAddress { get; set; }
        public string F_ContactEmail { get; set; }
        public int F_Taxis { get; set; }
        public Nullable<System.DateTime> F_AddTime { get; set; }
        public Nullable<System.DateTime> F_EditTime { get; set; }
        public Nullable<int> F_IsRecycle { get; set; }
    }
}
