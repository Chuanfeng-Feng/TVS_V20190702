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
    
    public partial class tbl_axisdet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_axisdet()
        {
            this.tblsensordatalinks = new HashSet<tblsensordatalink>();
        }
    
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
        public Nullable<int> AxisdetMonth { get; set; }
        public Nullable<int> AxisdetYear { get; set; }
        public Nullable<int> AxisdetWeekNumber { get; set; }
        public Nullable<int> AxisdetQuarter { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblsensordatalink> tblsensordatalinks { get; set; }
        public virtual tblmachinedetail tblmachinedetail { get; set; }
    }
}
