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
    
    public partial class SequenceNumber
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Prefix { get; set; }
        public string DateType { get; set; }
        public string Infix { get; set; }
        public Nullable<int> IndexLength { get; set; }
        public string Suffix { get; set; }
        public string MaxDate { get; set; }
        public Nullable<int> MaxIndex { get; set; }
        public string CurrentMaxValue { get; set; }
    }
}
