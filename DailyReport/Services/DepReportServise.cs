using DailyReport.Models;
using DailyReport.Pages;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace DailyReport.Services
{
    public class DepReportServise
    {
        public DepReport DepReport = new DepReport();
        /// <summary>
        /// инициализация для отладочных целей
        /// </summary>
        public DepReportServise()
        { 
            DepReport.Id = 1;
            DepReport.date = DateTime.Today;
            DepReport.depNumber = 1;
            DepReport.existed = 1;
            DepReport.existedChildrens = 1;
            DepReport.income = 1;
            DepReport.incomeChildrens = 1;
            DepReport.outcome = 1;
            DepReport.outcomeChildrens = 1;
            DepReport.movedOutDep = 1;
            DepReport.movedOutDepChildrens = 1;
            DepReport.movedInDep = 1;
            DepReport.movedInDepChildrens = 1;
            DepReport.died = 1;
            DepReport.diedChildrens = 1;
            DepReport.present = 1;
            DepReport.presentChildrens = 1;
            DepReport.oIVL = 1;
            DepReport.oIVLChildrens = 1;
            DepReport.oNIVL = 1;
            DepReport.oNIVLChildrens = 1;
            DepReport.oNIVLVPO = 1;
            DepReport.oNIVLVPOChildrens = 1;
            DepReport.oNIVLMask = 1;
            DepReport.oNIVLMaskChildrens = 1;
            DepReport.oMask = 1;
            DepReport.oMaskChildren = 1;
            DepReport.oBrease = 1;
            DepReport.oBreaseChildrens = 1;
            DepReport.pregnant = 1;
            DepReport.pregnantChildrens = 1;
            DepReport.restZone = 1;
            DepReport.restZoneChildrens = 1;
            DepReport.outRegions = 1;
            DepReport.outRegionsChildrens = 1;
            DepReport.forein = 1;
            DepReport.foreinChildrens = 1;
            DepReport.LNR_DNR = 1;
            DepReport.LNR_DNRChildrens = 1;
            DepReport.incomeHospital = 1;
            DepReport.incomeHospitalChildrens = 1;
            DepReport.outcomeHospital = 1;
            DepReport.outcomeHospitalChildrens = 1;
            DepReport.U071 = 1;
            DepReport.U071Childrens = 1;
            DepReport.U072 = 1;
            DepReport.U072Childrens = 1;
            DepReport.ORVI = 1;
            DepReport.ORVIChildrens = 1;
            DepReport.pneumonia = 1;
            DepReport.pneumoniaChildrens = 1;
            DepReport.OKI = 1;
            DepReport.OKIChildrens = 1;
            DepReport.meningit = 1;
            DepReport.meningitChildrens = 1;
            DepReport.hepatit = 1;
            DepReport.hepatitChildrens = 1;
            DepReport.HIV = 1;
            DepReport.HIVCildrens = 1;
            DepReport.other = 1;
            DepReport.otherChildrens = 1;
        }

        public DepReport Get()
        {
            return DepReport;
        }
    
    
    }
}
