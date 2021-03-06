//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hisa
{
    using System;
    using System.Collections.Generic;
    
    public partial class LPO
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.TimeSpan> OrderTime { get; set; }
        public System.Guid OrderNumber { get; set; }
        public Nullable<int> RefNumber { get; set; }
        public string RequestBy { get; set; }
        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string PurchasingOfficer { get; set; }
        public string PaymentMode { get; set; }
        public string ItemName { get; set; }
        public string Units { get; set; }
        public string UnitPrice { get; set; }
        public string SOH { get; set; }
        public string Requested { get; set; }
        public string ToOrder { get; set; }
        public string VAT { get; set; }
        public string Net { get; set; }
        public string TotalAmount { get; set; }
        public string TotalTotalAmount { get; set; }
    }
}
