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
    
    public partial class tblandonimagetextscheduleddisplay
    {
        public int TextImageAndonId { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> PlantID { get; set; }
        public Nullable<int> ShopID { get; set; }
        public Nullable<int> CellID { get; set; }
        public string ScreenType { get; set; }
        public Nullable<int> FlagStart { get; set; }
        public Nullable<int> FlagEnd { get; set; }
        public Nullable<System.DateTime> StartDateTime { get; set; }
        public Nullable<System.DateTime> EndDateTime { get; set; }
        public string ImageName { get; set; }
        public string TextToDisplay { get; set; }
        public Nullable<int> DefaultScreenVisible { get; set; }
        public Nullable<System.DateTime> InsertedOn { get; set; }
        public Nullable<int> InsertedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    
        public virtual tblplant tblplant { get; set; }
        public virtual tblshop tblshop { get; set; }
        public virtual tblcell tblcell { get; set; }
    }
}
