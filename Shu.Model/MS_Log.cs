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
    
    public partial class MS_Log
    {
        public int Kid { get; set; }
        public string F_Type { get; set; }
        public string F_Level { get; set; }
        public string F_Thread { get; set; }
        public string F_Source { get; set; }
        public string F_Message { get; set; }
        public string F_Exception { get; set; }
        public string F_IP { get; set; }
        public Nullable<int> F_AdminID { get; set; }
        public Nullable<System.DateTime> F_AddTime { get; set; }
    }
}
