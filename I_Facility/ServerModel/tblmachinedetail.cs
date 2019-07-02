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
    
    public partial class tblmachinedetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblmachinedetail()
        {
            this.handle_no_ping = new HashSet<handle_no_ping>();
            this.hist_alarm_history_master = new HashSet<hist_alarm_history_master>();
            this.hist_message_history_master = new HashSet<hist_message_history_master>();
            this.hist_parameters_master = new HashSet<hist_parameters_master>();
            this.message_history_master = new HashSet<message_history_master>();
            this.operationlogs = new HashSet<operationlog>();
            this.pcb_details = new HashSet<pcb_details>();
            this.pcb_parameters = new HashSet<pcb_parameters>();
            this.pcbdps_master = new HashSet<pcbdps_master>();
            this.program_master = new HashSet<program_master>();
            this.tbl_autoreportsetting = new HashSet<tbl_autoreportsetting>();
            this.tbl_axisdet = new HashSet<tbl_axisdet>();
            this.tbl_axisdetails1 = new HashSet<tbl_axisdetails1>();
            this.tbl_axisdetails2 = new HashSet<tbl_axisdetails2>();
            this.tbl_deletedprogdet = new HashSet<tbl_deletedprogdet>();
            this.tbl_machinestatusrealtime = new HashSet<tbl_machinestatusrealtime>();
            this.tbl_prodorderlosses = new HashSet<tbl_prodorderlosses>();
            this.tbl_savencprogver = new HashSet<tbl_savencprogver>();
            this.tbl_servodetails = new HashSet<tbl_servodetails>();
            this.tbl_utilreport = new HashSet<tbl_utilreport>();
            this.tblatccounters = new HashSet<tblatccounter>();
            this.tblbreakdowns = new HashSet<tblbreakdown>();
            this.tbldailyprodstatus = new HashSet<tbldailyprodstatu>();
            this.tblemailescalations = new HashSet<tblemailescalation>();
            this.tblgenericworkentries = new HashSet<tblgenericworkentry>();
            this.tblhistaxisdets = new HashSet<tblhistaxisdet>();
            this.tblhistaxisdetails1 = new HashSet<tblhistaxisdetails1>();
            this.tblhistaxisdetails2 = new HashSet<tblhistaxisdetails2>();
            this.tblhistbreakdowns = new HashSet<tblhistbreakdown>();
            this.tblhistdailyprodstatus = new HashSet<tblhistdailyprodstatu>();
            this.tblhistlossofentries = new HashSet<tblhistlossofentry>();
            this.tblhistmimics = new HashSet<tblhistmimic>();
            this.tblhistprodandondisps = new HashSet<tblhistprodandondisp>();
            this.tblhistservodetails = new HashSet<tblhistservodetail>();
            this.tblhistutilreports = new HashSet<tblhistutilreport>();
            this.tblhistworkorderentries = new HashSet<tblhistworkorderentry>();
            this.tblmachineaxisdetails = new HashSet<tblmachineaxisdetail>();
            this.tblmodes = new HashSet<tblmode>();
            this.tblmachinesensors = new HashSet<tblmachinesensor>();
            this.tblmode2018 = new HashSet<tblmode2018>();
            this.tblncprogramtransfermains = new HashSet<tblncprogramtransfermain>();
            this.tbloperatordashboards = new HashSet<tbloperatordashboard>();
            this.tbloperatorheaders = new HashSet<tbloperatorheader>();
            this.tblsetupmaints = new HashSet<tblsetupmaint>();
            this.tblshiftdetails_machinewise = new HashSet<tblshiftdetails_machinewise>();
            this.tblprogramtransferhistories = new HashSet<tblprogramtransferhistory>();
            this.tbltoolcounters = new HashSet<tbltoolcounter>();
            this.tblprimitivemaintainanceschedulings = new HashSet<tblprimitivemaintainancescheduling>();
            this.tblpresenttools = new HashSet<tblpresenttool>();
            this.tblmultipleworkorders = new HashSet<tblmultipleworkorder>();
            this.tblshiftplanners = new HashSet<tblshiftplanner>();
            this.tblusers = new HashSet<tbluser>();
            this.tblrejectreasons = new HashSet<tblrejectreason>();
            this.tbl_prodandondisp = new HashSet<tbl_prodandondisp>();
            this.tbl_prodmanmachine = new HashSet<tbl_prodmanmachine>();
            this.tbltoollifeoperators = new HashSet<tbltoollifeoperator>();
            this.tblpartlearningreports = new HashSet<tblpartlearningreport>();
            this.parameters_master = new HashSet<parameters_master>();
            this.tbllivemodes = new HashSet<tbllivemode>();
            this.tblmimics = new HashSet<tblmimic>();
            this.tblpartscountandcuttings = new HashSet<tblpartscountandcutting>();
            this.tblbottelnecks = new HashSet<tblbottelneck>();
            this.tblworkorderentries = new HashSet<tblworkorderentry>();
            this.tbllossofentries = new HashSet<tbllossofentry>();
        }
    
        public int MachineID { get; set; }
        public string InsertedOn { get; set; }
        public int InsertedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public Nullable<int> PlantID { get; set; }
        public Nullable<int> ShopID { get; set; }
        public Nullable<int> CellID { get; set; }
        public string MachineName { get; set; }
        public string MachineDescription { get; set; }
        public string MachineDisplayName { get; set; }
        public Nullable<int> CellOrderNo { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> MachineType { get; set; }
        public string ControllerType { get; set; }
        public string MachineModel { get; set; }
        public string MachineMake { get; set; }
        public string ModelType { get; set; }
        public Nullable<int> IsParameters { get; set; }
        public string ShopNo { get; set; }
        public Nullable<int> IsPCB { get; set; }
        public Nullable<int> IsLevel { get; set; }
        public Nullable<int> IsNormalWC { get; set; }
        public Nullable<int> ManualWCID { get; set; }
        public Nullable<int> NoOfAxis { get; set; }
        public string MacType { get; set; }
        public Nullable<int> CurrentControlAxis { get; set; }
        public string ProgramNum { get; set; }
        public string ProgDBit { get; set; }
        public int MachineModelType { get; set; }
        public string MacConnName { get; set; }
        public string SpindleAxis { get; set; }
        public string TabIPAddress { get; set; }
        public Nullable<int> MachineLockBit { get; set; }
        public Nullable<int> MachineSetupBit { get; set; }
        public Nullable<int> MachineMaintBit { get; set; }
        public Nullable<int> MachineToolLifeBit { get; set; }
        public Nullable<int> MachineUnlockBit { get; set; }
        public Nullable<int> MachineIdleBit { get; set; }
        public Nullable<int> MachineIdleMin { get; set; }
        public int EnableLockLogic { get; set; }
        public int ServerTabFlagSync { get; set; }
        public int ServerTabCheck { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public bool EnableToolLife { get; set; }
        public Nullable<int> AssetCode { get; set; }
        public Nullable<int> OperationNumber { get; set; }
        public Nullable<int> IsBottelNeck { get; set; }
        public Nullable<int> IsFirstMachine { get; set; }
        public Nullable<int> IsLastMachine { get; set; }
        public string BottomneckMachine { get; set; }
        public Nullable<decimal> PlannedCycleTimeInSec { get; set; }
        public Nullable<decimal> StdLoadingTime { get; set; }
        public Nullable<decimal> StdUnLoadingTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<handle_no_ping> handle_no_ping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hist_alarm_history_master> hist_alarm_history_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hist_message_history_master> hist_message_history_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hist_parameters_master> hist_parameters_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message_history_master> message_history_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<operationlog> operationlogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pcb_details> pcb_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pcb_parameters> pcb_parameters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pcbdps_master> pcbdps_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<program_master> program_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_autoreportsetting> tbl_autoreportsetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_axisdet> tbl_axisdet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_axisdetails1> tbl_axisdetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_axisdetails2> tbl_axisdetails2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_deletedprogdet> tbl_deletedprogdet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_machinestatusrealtime> tbl_machinestatusrealtime { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_prodorderlosses> tbl_prodorderlosses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_savencprogver> tbl_savencprogver { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_servodetails> tbl_servodetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_utilreport> tbl_utilreport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblatccounter> tblatccounters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblbreakdown> tblbreakdowns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbldailyprodstatu> tbldailyprodstatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblemailescalation> tblemailescalations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblgenericworkentry> tblgenericworkentries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistaxisdet> tblhistaxisdets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistaxisdetails1> tblhistaxisdetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistaxisdetails2> tblhistaxisdetails2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistbreakdown> tblhistbreakdowns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistdailyprodstatu> tblhistdailyprodstatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistlossofentry> tblhistlossofentries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistmimic> tblhistmimics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistprodandondisp> tblhistprodandondisps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistservodetail> tblhistservodetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistutilreport> tblhistutilreports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblhistworkorderentry> tblhistworkorderentries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblmachineaxisdetail> tblmachineaxisdetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblmode> tblmodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblmachinesensor> tblmachinesensors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblmode2018> tblmode2018 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblncprogramtransfermain> tblncprogramtransfermains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbloperatordashboard> tbloperatordashboards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbloperatorheader> tbloperatorheaders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblsetupmaint> tblsetupmaints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblshiftdetails_machinewise> tblshiftdetails_machinewise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblprogramtransferhistory> tblprogramtransferhistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbltoolcounter> tbltoolcounters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblprimitivemaintainancescheduling> tblprimitivemaintainanceschedulings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblpresenttool> tblpresenttools { get; set; }
        public virtual tblplant tblplant { get; set; }
        public virtual tblshop tblshop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblmultipleworkorder> tblmultipleworkorders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblshiftplanner> tblshiftplanners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbluser> tblusers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblrejectreason> tblrejectreasons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_prodandondisp> tbl_prodandondisp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_prodmanmachine> tbl_prodmanmachine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbltoollifeoperator> tbltoollifeoperators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblpartlearningreport> tblpartlearningreports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<parameters_master> parameters_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbllivemode> tbllivemodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblmimic> tblmimics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblpartscountandcutting> tblpartscountandcuttings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblbottelneck> tblbottelnecks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblworkorderentry> tblworkorderentries { get; set; }
        public virtual tblcell tblcell { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbllossofentry> tbllossofentries { get; set; }
    }
}
