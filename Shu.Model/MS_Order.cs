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
    
    public partial class MS_Order
    {
        public int Kid { get; set; }
        public string F_OrderNumber { get; set; }
        public Nullable<int> F_UserKid { get; set; }
        public string F_UserName { get; set; }
        public string F_ReceiveName { get; set; }
        public string F_ReceiveMobile { get; set; }
        public string F_ReceivePhone { get; set; }
        public string F_ReceiveEmail { get; set; }
        public string F_ReceiveAddress { get; set; }
        public string F_ReceivePostCode { get; set; }
        public string F_InvoiceName { get; set; }
        public string F_InvoiceInfo { get; set; }
        public string F_Content { get; set; }
        public Nullable<decimal> F_AllAmount { get; set; }
        public Nullable<int> F_State { get; set; }
        public string F_TransitCompany { get; set; }
        public string F_TransitType { get; set; }
        public string F_TransitNumber { get; set; }
        public Nullable<int> F_UserCouponKid { get; set; }
        public Nullable<int> F_CPSUserKid { get; set; }
        public Nullable<int> F_IsRebate { get; set; }
        public Nullable<decimal> F_Rebate { get; set; }
        public Nullable<int> F_IsPostage { get; set; }
        public Nullable<decimal> F_Postage { get; set; }
        public Nullable<int> F_IsPayment { get; set; }
        public string F_PaymentType { get; set; }
        public Nullable<decimal> F_PaymentPrice { get; set; }
        public Nullable<System.DateTime> F_PaymentTime { get; set; }
        public Nullable<int> F_IsSend { get; set; }
        public Nullable<System.DateTime> F_SendTime { get; set; }
        public Nullable<System.DateTime> F_ConfirmTime { get; set; }
        public Nullable<System.DateTime> F_AddTime { get; set; }
        public Nullable<System.DateTime> F_EditTime { get; set; }
        public Nullable<int> F_EditAdminKid { get; set; }
        public Nullable<int> F_IsRecycle { get; set; }
    }
}