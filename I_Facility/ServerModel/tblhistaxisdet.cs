//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace I_Facility.ServerModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblhistaxisdet
    {
        public int AxisDetID { get; set; }
        public int MachineID { get; set; }
        public int AxisID { get; set; }
        public string AxisName { get; set; }
        public System.DateTime InsertedOn { get; set; }
        public int InsertedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public int IsDeleted { get; set; }
        public int SpindlePath { get; set; }
    
        public virtual tblmachinedetail tblmachinedetail { get; set; }
    }
}
