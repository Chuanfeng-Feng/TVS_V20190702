﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I_Facility.ServerModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace I_Facility.ReportsCalcClass
{
    public class ProdDetAndon
    {
        i_facilityEntities1 Serverdb = new i_facilityEntities1();

        public ProdDetAndon()
        {

        }

        public void insertProdDet(int MachineID, DateTime CorrectedDate)
        {
            try
            {
                var getProdList = Serverdb.tblworkorderentries.Where(m => m.MachineID == MachineID && m.CorrectedDate == CorrectedDate.Date.ToString("yyyy-MM-dd")).OrderBy(m => m.WOStart).ToList();

                foreach (var ProdRow in getProdList)
                {
                    var GetEntry = Serverdb.tbl_prodandondisp.Where(m => m.WOID == ProdRow.HMIID).FirstOrDefault();
                    if (GetEntry == null)
                    {
                        DateTime ProdStartTime = ProdRow.WOStart;
                        DateTime ProdEndtime = DateTime.Now;
                        try
                        {
                            if (ProdRow.WOEnd.HasValue)
                            {
                                ProdEndtime = Convert.ToDateTime(ProdRow.WOEnd);
                            }
                        }
                        catch { }

                        int OperatingTime = 0;
                        int LossTime = 0;
                        int MinorLossTime = 0;
                        int MntTime = 0;
                        int SetupTime = 0;
                        int SetupMinorTime = 0;
                        int PowerOffTime = 0;

                        #region Logic to get the Mode Durations between a Production Order which are completed
                        var GetModeDurations = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime >= ProdStartTime && m.StartTime < ProdEndtime && m.EndTime > ProdStartTime && m.EndTime < ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).ToList();
                        foreach (var ModeRow in GetModeDurations)
                        {
                            if (ModeRow.ModeType == "PROD")
                            {
                                OperatingTime += (int)(ModeRow.DurationInSec / 60);
                            }
                            else if (ModeRow.ModeType == "IDLE" && ModeRow.DurationInSec > 600)
                            {
                                LossTime += (int)(ModeRow.DurationInSec / 60);
                            }
                            else if (ModeRow.ModeType == "IDLE" && ModeRow.DurationInSec < 600)
                            {
                                MinorLossTime += (int)(ModeRow.DurationInSec / 60);
                            }
                            else if (ModeRow.ModeType == "MNT")
                            {
                                MntTime += (int)(ModeRow.DurationInSec / 60);
                            }
                            else if (ModeRow.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (int)(ModeRow.DurationInSec / 60);
                            }
                            else if (ModeRow.ModeType == "SETUP")
                            {
                                try
                                {
                                    SetupTime += (int)(Convert.ToDateTime(ModeRow.LossCodeEnteredTime).Subtract(Convert.ToDateTime(ModeRow.StartTime)).TotalSeconds / 60);
                                    SetupMinorTime += (int)(Serverdb.tblsetupmaints.Where(m => m.ModeID == ModeRow.ModeID).Select(m => m.MinorLossTime).First() / 60);
                                }
                                catch { }
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration if the Production is still Running.
                        if (ProdRow.IsFinished == 0)
                        {
                            var getRunningMode = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.IsCompleted == 0).OrderByDescending(m => m.ModeID).First();
                            if (getRunningMode.ModeType == "PROD")
                            {
                                OperatingTime += (int)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                            else if (getRunningMode.ModeType == "IDLE")
                            {
                                LossTime += (int)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                            else if (getRunningMode.ModeType == "MNT")
                            {
                                MntTime += (int)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                            else if (getRunningMode.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (int)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                            else if (getRunningMode.ModeType == "SETUP")
                            {
                                try
                                {
                                    SetupTime += (int)(Convert.ToDateTime(getRunningMode.LossCodeEnteredTime).Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                                    SetupMinorTime += (int)(Serverdb.tblsetupmaints.Where(m => m.ModeID == getRunningMode.ModeID).Select(m => m.MinorLossTime).First() / 60);
                                }
                                catch { }
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration Which Was started before this Production and Ended during this Production
                        var GetEndModeDuration = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime < ProdStartTime && m.EndTime > ProdStartTime && m.EndTime < ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).FirstOrDefault();
                        if (GetEndModeDuration != null)
                        {
                            if (GetEndModeDuration.ModeType == "PROD")
                            {
                                OperatingTime += (int)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetEndModeDuration.ModeType == "IDLE")
                            {
                                LossTime += (int)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetEndModeDuration.ModeType == "MNT")
                            {
                                MntTime += (int)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetEndModeDuration.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (int)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetEndModeDuration.ModeType == "SETUP")
                            {
                                try
                                {
                                    SetupTime += (int)(Convert.ToDateTime(GetEndModeDuration.LossCodeEnteredTime).Subtract(Convert.ToDateTime(GetEndModeDuration.StartTime)).TotalSeconds / 60);
                                    SetupMinorTime += (int)(Serverdb.tblsetupmaints.Where(m => m.ModeID == GetEndModeDuration.ModeID).Select(m => m.MinorLossTime).First() / 60);
                                }
                                catch { }
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration Which Was Started during the Production and Ended after the Production
                        var GetStartModeDuration = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime >= ProdStartTime && m.EndTime >= ProdStartTime && m.StartTime < ProdEndtime && m.EndTime > ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).FirstOrDefault();
                        if (GetStartModeDuration != null)
                        {
                            if (GetStartModeDuration.ModeType == "PROD")
                            {
                                OperatingTime += (int)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetStartModeDuration.ModeType == "IDLE")
                            {
                                LossTime += (int)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetStartModeDuration.ModeType == "MNT")
                            {
                                MntTime += (int)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetStartModeDuration.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (int)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetStartModeDuration.ModeType == "SETUP")
                            {
                                try
                                {
                                    SetupTime += (int)(Convert.ToDateTime(GetStartModeDuration.LossCodeEnteredTime).Subtract(Convert.ToDateTime(GetStartModeDuration.StartTime)).TotalSeconds / 60);
                                    SetupMinorTime += (int)(Serverdb.tblsetupmaints.Where(m => m.ModeID == GetStartModeDuration.ModeID).Select(m => m.MinorLossTime).First() / 60);
                                }
                                catch { }
                            }
                        }
                        #endregion

                        double TotalTime = ProdEndtime.Subtract(ProdStartTime).TotalMinutes;
                        decimal UtilPercent = (decimal)Math.Round(OperatingTime / TotalTime * 100, 2);
                        if(UtilPercent > 100)
                        {
                            UtilPercent = 100;
                        }

                        tbl_prodandondisp PRA = new tbl_prodandondisp();
                        PRA.MachineID = MachineID;
                        PRA.WOID = ProdRow.HMIID;
                        PRA.CorrectedDate = CorrectedDate.Date.ToString("yyyy-MM-dd");
                        PRA.TotalLoss = LossTime + MinorLossTime - SetupMinorTime;
                        PRA.TotalOperatingTime = OperatingTime;
                        PRA.TotalSetup = SetupTime + SetupMinorTime;
                        PRA.UtilPercent = UtilPercent;
                        PRA.InsertedOn = DateTime.Now;
                        Serverdb.tbl_prodandondisp.Add(PRA);
                        Serverdb.SaveChanges();
                    }
                    else if (GetEntry.tblworkorderentry.IsFinished == 0)
                    {
                        DateTime ProdStartTime = ProdRow.WOStart;
                        DateTime ProdEndtime = DateTime.Now;
                        try
                        {
                            if (ProdRow.WOEnd.HasValue)
                            {
                                ProdEndtime = Convert.ToDateTime(ProdRow.WOEnd);
                            }
                        }
                        catch { }

                        decimal OperatingTime = 0;
                        decimal LossTime = 0;
                        decimal MinorLossTime = 0;
                        decimal MntTime = 0;
                        decimal SetupTime = 0;
                        decimal SetupMinorTime = 0;
                        decimal PowerOffTime = 0;

                        #region Logic to get the Mode Durations between a Production Order which are completed
                        var GetModeDurations = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime >= ProdStartTime && m.StartTime <= ProdEndtime && m.EndTime >= ProdStartTime && m.EndTime <= ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).ToList();
                        foreach (var ModeRow in GetModeDurations)
                        {
                            if (ModeRow.ModeType == "PROD")
                            {
                                OperatingTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "IDLE" && ModeRow.DurationInSec > 600)
                            {
                                LossTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "IDLE" && ModeRow.DurationInSec < 600)
                            {
                                MinorLossTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "MNT")
                            {
                                MntTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "SETUP")
                            {
                                try
                                {
                                    SetupTime += (decimal)(Convert.ToDateTime(ModeRow.LossCodeEnteredTime).Subtract(Convert.ToDateTime(ModeRow.StartTime)).TotalSeconds / 60);
                                    SetupMinorTime += (decimal)(Serverdb.tblsetupmaints.Where(m => m.ModeID == ModeRow.ModeID).Select(m => m.MinorLossTime).First() / 60);
                                }
                                catch { }
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration if the Production is still Running.
                        if (ProdRow.IsFinished == 0)
                        {
                            var getRunningMode = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.IsCompleted == 0).OrderByDescending(m => m.ModeID).First();
                            if (getRunningMode.ModeType == "PROD")
                            {
                                OperatingTime += (decimal)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                            else if (getRunningMode.ModeType == "IDLE")
                            {
                                LossTime += (decimal)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                            else if (getRunningMode.ModeType == "MNT")
                            {
                                MntTime += (decimal)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                            else if (getRunningMode.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (decimal)(DateTime.Now.Subtract(Convert.ToDateTime(getRunningMode.StartTime)).TotalSeconds / 60);
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration Which Was started before this Production and Ended during this Production
                        var GetEndModeDuration = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime < ProdStartTime && m.EndTime >= ProdStartTime && m.EndTime <= ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).FirstOrDefault();
                        if (GetEndModeDuration != null)
                        {
                            if (GetEndModeDuration.ModeType == "PROD")
                            {
                                OperatingTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetEndModeDuration.ModeType == "IDLE")
                            {
                                LossTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetEndModeDuration.ModeType == "MNT")
                            {
                                MntTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetEndModeDuration.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration Which Was Started during the Production and Ended Before the Production End
                        var GetStartModeDuration = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime >= ProdStartTime && m.EndTime >= ProdStartTime && m.StartTime <= ProdEndtime && m.EndTime > ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).FirstOrDefault();
                        if (GetStartModeDuration != null)
                        {
                            if (GetStartModeDuration.ModeType == "PROD")
                            {
                                OperatingTime += (decimal)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetStartModeDuration.ModeType == "IDLE")
                            {
                                LossTime += (decimal)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetStartModeDuration.ModeType == "MNT")
                            {
                                MntTime += (decimal)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                            else if (GetStartModeDuration.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (decimal)(Convert.ToDateTime(GetStartModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60);
                            }
                        }
                        #endregion

                        double TotalTime = ProdEndtime.Subtract(ProdStartTime).TotalMinutes;
                        decimal UtilPercent = (Decimal)Math.Round((double)OperatingTime / TotalTime * 100, 2);
                        if (UtilPercent > 100)
                        {
                            UtilPercent = 100;
                        }

                        tbl_prodandondisp PRA = Serverdb.tbl_prodandondisp.Where(m => m.ProdDashboardID == GetEntry.ProdDashboardID).First();
                        //PRA.MachineID = MachineID;
                        //PRA.WOID = ProdRow.HMIID;
                        //PRA.CorrectedDate = CorrectedDate.Date.ToString("yyyy-MM-dd");
                        PRA.TotalLoss = (Decimal)Math.Round(LossTime + MinorLossTime - SetupMinorTime,2);
                        PRA.TotalOperatingTime = (Decimal)Math.Round(OperatingTime,2);
                        PRA.TotalSetup = (Decimal)Math.Round(SetupTime + SetupMinorTime,2);
                        PRA.UtilPercent = UtilPercent;
                        Serverdb.Entry(PRA).State = EntityState.Modified;
                        Serverdb.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        // Get Production Data for Man Machine Ticket.
        public void insertManMacProd(int MachineID, DateTime CorrectedDate)
        {
            try
            {
                var getProdList = Serverdb.tblworkorderentries.Where(m => m.MachineID == MachineID && m.CorrectedDate == CorrectedDate.Date.ToString("yyyy-MM-dd")).OrderBy(m => m.WOStart).ToList();

                foreach (var ProdRow in getProdList)
                {
                    var GetEntry = Serverdb.tbl_prodmanmachine.Where(m => m.WOID == ProdRow.HMIID).FirstOrDefault();
                    if (GetEntry == null)
                    {
                        DateTime ProdStartTime = ProdRow.WOStart;
                        DateTime ProdEndtime = DateTime.Now;
                        try
                        {
                            if (ProdRow.WOEnd.HasValue)
                            {
                                ProdEndtime = Convert.ToDateTime(ProdRow.WOEnd);
                            }
                        }
                        catch { }

                        decimal OperatingTime = 0;
                        decimal LossTime = 0;
                        decimal MinorLossTime = 0;
                        decimal MntTime = 0;
                        decimal SetupTime = 0;
                        decimal SetupMinorTime = 0;
                        decimal PowerOffTime = 0;

                        #region Logic to get the Mode Durations between a Production Order which are completed
                        var GetModeDurations = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime >= ProdStartTime && m.StartTime < ProdEndtime && m.EndTime > ProdStartTime && m.EndTime <= ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).ToList();
                        foreach (var ModeRow in GetModeDurations)
                        {
                            if (ModeRow.ModeType == "PROD")
                            {
                                OperatingTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "IDLE" && ModeRow.DurationInSec > 600)
                            {
                                LossTime += (decimal)(ModeRow.DurationInSec / 60.00);
                                decimal LossDuration = (decimal)(ModeRow.DurationInSec / 60.00);
                                if (ModeRow.LossCodeID != null)
                                    insertProdlosses(ProdRow.HMIID, (int)ModeRow.LossCodeID, LossDuration, CorrectedDate, MachineID);
                            }
                            else if (ModeRow.ModeType == "IDLE" && ModeRow.DurationInSec < 600)
                            {
                                MinorLossTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "MNT")
                            {
                                MntTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (decimal)(ModeRow.DurationInSec / 60.00);
                            }
                            else if (ModeRow.ModeType == "SETUP")
                            {
                                try
                                {
                                    SetupTime += (decimal)Convert.ToDateTime(ModeRow.LossCodeEnteredTime).Subtract(Convert.ToDateTime(ModeRow.StartTime)).TotalMinutes;
                                    SetupMinorTime += (decimal)(Serverdb.tblsetupmaints.Where(m => m.ModeID == ModeRow.ModeID).Select(m => m.MinorLossTime).First() / 60.00);
                                }
                                catch { }
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration Which Was started before this Production and Ended during this Production
                        var GetEndModeDuration = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime < ProdStartTime && m.EndTime > ProdStartTime && m.EndTime <= ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).FirstOrDefault();
                        if (GetEndModeDuration != null)
                        {
                            if (GetEndModeDuration.ModeType == "PROD")
                            {
                                OperatingTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60.00);
                            }
                            else if (GetEndModeDuration.ModeType == "IDLE")
                            {
                                LossTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60.00);
                                decimal LossDuration = (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60.00);
                                if (GetEndModeDuration.LossCodeID != null)
                                    insertProdlosses(ProdRow.HMIID, (int)GetEndModeDuration.LossCodeID, LossDuration, CorrectedDate, MachineID);
                                //insertProdlosses(WOID, LossID, LossDuration, CorrectedDate);
                            }
                            else if (GetEndModeDuration.ModeType == "MNT")
                            {
                                MntTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60.00);
                            }
                            else if (GetEndModeDuration.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (decimal)(Convert.ToDateTime(GetEndModeDuration.EndTime).Subtract(Convert.ToDateTime(ProdStartTime)).TotalSeconds / 60.00);
                            }
                        }
                        #endregion

                        #region Logic to get the Mode Duration Which Was Started during the Production and Ended after the Production
                        var GetStartModeDuration = Serverdb.tblmodes.Where(m => m.MachineID == MachineID && m.StartTime >= ProdStartTime && m.EndTime >= ProdStartTime && m.StartTime < ProdEndtime && m.EndTime > ProdEndtime && m.IsCompleted == 1 && m.ModeTypeEnd == 1).FirstOrDefault();
                        if (GetStartModeDuration != null)
                        {
                            if (GetStartModeDuration.ModeType == "PROD")
                            {
                                OperatingTime += (decimal)(Convert.ToDateTime(ProdEndtime).Subtract(Convert.ToDateTime(GetStartModeDuration.StartTime)).TotalSeconds / 60.00);
                            }
                            else if (GetStartModeDuration.ModeType == "IDLE")
                            {
                                LossTime += (decimal)(Convert.ToDateTime(ProdEndtime).Subtract(Convert.ToDateTime(GetStartModeDuration.StartTime)).TotalSeconds / 60.00);
                                decimal LossDuration = (decimal)(Convert.ToDateTime(ProdEndtime).Subtract(Convert.ToDateTime(GetStartModeDuration.StartTime)).TotalSeconds / 60.00);
                                if (GetStartModeDuration.LossCodeID != null)
                                    insertProdlosses(ProdRow.HMIID, (int)GetStartModeDuration.LossCodeID, LossDuration, CorrectedDate, MachineID);
                                //insertProdlosses(WOID, LossID, LossDuration, CorrectedDate);
                            }
                            else if (GetStartModeDuration.ModeType == "MNT")
                            {
                                MntTime += (decimal)(Convert.ToDateTime(ProdEndtime).Subtract(Convert.ToDateTime(GetStartModeDuration.StartTime)).TotalSeconds / 60.00);
                            }
                            else if (GetStartModeDuration.ModeType == "POWEROFF")
                            {
                                PowerOffTime += (decimal)(Convert.ToDateTime(ProdEndtime).Subtract(Convert.ToDateTime(GetStartModeDuration.StartTime)).TotalSeconds / 60.00);
                            }
                        }
                        #endregion

                        int TotlaQty = ProdRow.Total_Qty;
                        if (TotlaQty == 0)
                            TotlaQty = 1;
                        decimal GetOptime = OperatingTime;
                        if (GetOptime == 0)
                        {
                            GetOptime = 1;
                        }
                        decimal IdealCycleTimeVal = 0;
                        var IdealCycTime = Serverdb.tblparts.Where(m => m.FGCode == ProdRow.FGCode && m.OperationNo == ProdRow.OperationNo).FirstOrDefault();
                        if (IdealCycTime != null)
                            IdealCycleTimeVal = IdealCycTime.IdealCycleTime;
                        double TotalTime = ProdEndtime.Subtract(ProdStartTime).TotalMinutes;
                        decimal UtilPercent = (decimal)Math.Round((double)OperatingTime / TotalTime * 100, 2);
                        decimal Quality = (decimal)Math.Round((double)ProdRow.Yield_Qty / TotlaQty * 100, 2);
                        decimal Performance = (decimal)Math.Round((double)IdealCycleTimeVal * (double)ProdRow.Total_Qty / (double)GetOptime * 100, 2);
                        int PerformanceFactor = (int)IdealCycleTimeVal * ProdRow.Total_Qty;
                        tbl_prodmanmachine PRA = new tbl_prodmanmachine();
                        PRA.MachineID = MachineID;
                        PRA.WOID = ProdRow.HMIID;
                        PRA.CorrectedDate = CorrectedDate.Date.ToString("yyyy-MM-dd");
                        PRA.TotalLoss = LossTime;
                        PRA.TotalOperatingTime = Math.Round(OperatingTime,2);
                        PRA.TotalSetup = Math.Round(SetupTime + SetupMinorTime,2);
                        PRA.TotalMinorLoss = Math.Round(MinorLossTime - SetupMinorTime,2);
                        PRA.TotalSetupMinorLoss = Math.Round(SetupMinorTime,2);
                        PRA.TotalPowerLoss = Math.Round(PowerOffTime,2);
                        PRA.UtilPercent = Math.Round(UtilPercent,2);
                        PRA.QualityPercent = Math.Round(Quality,2);
                        PRA.PerformancePerCent = Math.Round(Performance,2);
                        PRA.PerfromaceFactor = PerformanceFactor;
                        PRA.InsertedOn = DateTime.Now;
                        Serverdb.tbl_prodmanmachine.Add(PRA);
                        Serverdb.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        //Insert Losses Data for Man Machine Ticket.
        public void insertProdlosses(int WOID, int LossID, decimal LossDuration, DateTime CorrectedDate, int MachineID)
        {
            var Presentloss = Serverdb.tbl_prodorderlosses.Where(m => m.WOID == WOID && m.LossID == LossID).FirstOrDefault();
            if (Presentloss == null)
            {
                tbl_prodorderlosses PRA = new tbl_prodorderlosses();
                PRA.LossID = LossID;
                if (LossID != 0)
                {
                    var GetLossDet = Serverdb.tbllossescodes.Find(LossID);
                    if (GetLossDet.LossCodesLevel1ID == null)
                    {
                        PRA.LossCodeL1ID = LossID;
                    }
                    else
                    {
                        PRA.LossCodeL1ID = (int)GetLossDet.LossCodesLevel1ID;
                        PRA.LossID = (int)GetLossDet.LossCodesLevel1ID;
                    }
                    if (GetLossDet.LossCodesLevel2ID != null)
                        PRA.LossCodeL2ID = (int)GetLossDet.LossCodesLevel2ID;
                }
                //PRA.MachineID = MachineID;
                PRA.WOID = WOID;
                PRA.CorrectedDate = CorrectedDate.Date;
                PRA.LossDuration = (int)LossDuration;
                PRA.MachineID = MachineID;
                Serverdb.tbl_prodorderlosses.Add(PRA);
                Serverdb.SaveChanges();
            }
            else
            {
                Presentloss.LossDuration = (int)(Presentloss.LossDuration + LossDuration);
                Serverdb.Entry(Presentloss).State = EntityState.Modified;
                Serverdb.SaveChanges();
            }
        }
    }
}