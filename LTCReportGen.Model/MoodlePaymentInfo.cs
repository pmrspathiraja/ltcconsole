//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LTCReportGen.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MoodlePaymentInfo
    {
        public int UId { get; set; }
        public Nullable<int> SubID { get; set; }
        public string Subjects { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string EzyCashRef { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public Nullable<int> Active { get; set; }
        public string IPAddress { get; set; }
        public string FullName { get; set; }
    
        public virtual MoodleSubjectInfo MoodleSubjectInfo { get; set; }
    }
}