//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Images { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Married { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public string PositionId { get; set; }
        public string NationId { get; set; }
        public string RegionId { get; set; }
        public Nullable<int> StatusWorkId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string UserCreate { get; set; }
        public Nullable<System.DateTime> DateLastUpdate { get; set; }
        public string UserLastUpdate { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
