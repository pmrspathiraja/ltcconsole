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
    
    public partial class UserInfo
    {
        public int UId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> SubjectsID { get; set; }
        public Nullable<int> Active { get; set; }
        public Nullable<int> LoginCount { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public Nullable<int> IsLTC { get; set; }
        public Nullable<int> UserRoleID { get; set; }
    
        public virtual SubjectInfo SubjectInfo { get; set; }
        public virtual UserRoleInfo UserRoleInfo { get; set; }
    }
}
