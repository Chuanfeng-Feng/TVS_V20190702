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
    
    public partial class pcbdaq
    {
        public int PCBDAQID { get; set; }
        public string PCBIPAddress { get; set; }
        public int PinNumber { get; set; }
        public Nullable<int> ParamValue { get; set; }
        public Nullable<System.DateTime> PCBDateTime { get; set; }
        public int IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
