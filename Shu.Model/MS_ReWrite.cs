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
    
    public partial class MS_ReWrite
    {
        public int Kid { get; set; }
        public string Name { get; set; }
        public string LookFor { get; set; }
        public string SendTo { get; set; }
        public Nullable<int> TableType { get; set; }
        public Nullable<int> TableKid { get; set; }
        public Nullable<int> PageType { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<System.DateTime> EditTime { get; set; }
    }
}