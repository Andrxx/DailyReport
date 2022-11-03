using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace DailyReport.Services
{
    public static class FreeSpotsServices
    {
        static FreeSpots _freeSpots;
        public static FreeSpots CountSpots(List<DepReport> _dRep, DepartmentSpots _ds )
        {
            _freeSpots = new();
            if (_dRep.Count != 9)
            {
                _dRep = CheckReports(_dRep);
            }
            //else
            //{
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                _freeSpots.dep1 = _ds.dep1 - _dRep.Find(p => p.depNumber == 1).present;
                _freeSpots.dep1Children = _ds.dep11Children - _dRep.Find(p => p.depNumber == 1).presentChildrens;
                _freeSpots.dep11 = _ds.dep11 + -_dRep.Find(p => p.depNumber == 11).present;
                _freeSpots.dep11Children = _ds.dep11Children - _dRep.Find(p => p.depNumber == 11).presentChildrens;
                //_freeSpots.dep2 = _ds.dep2 + _ds. - _dRep.Find(p => p.depNumber == 2).present - _dRep.Find(p => p.depNumber == 2).presentChildrens;
                _freeSpots.dep3 = _ds.dep3 - _dRep.Find(p => p.depNumber == 3).present;
                _freeSpots.dep3Children = _ds.dep3Children - _dRep.Find(p => p.depNumber == 3).presentChildrens;
                _freeSpots.dep4 = _ds.dep4 - _dRep.Find(p => p.depNumber == 4).present;
                _freeSpots.dep4Children = _ds.dep4Children - _dRep.Find(p => p.depNumber == 4).presentChildrens;
                _freeSpots.dep5 = _ds.dep5 - _dRep.Find(p => p.depNumber == 5).present;
                _freeSpots.dep5Children = _ds.dep5Children - _dRep.Find(p => p.depNumber == 5).presentChildrens;
                _freeSpots.dep6 = _ds.dep6 - _dRep.Find(p => p.depNumber == 6).present;
                _freeSpots.dep6Children = _ds.dep6Children - _dRep.Find(p => p.depNumber == 6).presentChildrens;
                _freeSpots.dep7 = _ds.dep7 - _dRep.Find(p => p.depNumber == 7).present;
                _freeSpots.dep7Children = _ds.dep7Children - _dRep.Find(p => p.depNumber == 7).presentChildrens;
                _freeSpots.dep8 = _ds.dep8 - _dRep.Find(p => p.depNumber == 8).present;
                _freeSpots.dep8Children = _ds.dep8Children - _dRep.Find(p => p.depNumber == 8).presentChildrens;
                _freeSpots.dep90 = _ds.dep90 - _dRep.Find(p => p.depNumber == 90).present;
                _freeSpots.dep90Children = _ds.dep90Children - _dRep.Find(p => p.depNumber == 90).presentChildrens;
                _freeSpots.dep91 = _ds.dep91 - _dRep.Find(p => p.depNumber == 91).present;
                _freeSpots.dep91Children = _ds.dep91Children - _dRep.Find(p => p.depNumber == 91).presentChildrens;
                _freeSpots.sum = _freeSpots.dep1 + _freeSpots.dep11 + _freeSpots.dep3 + _freeSpots.dep4 + _freeSpots.dep5
                    + _freeSpots.dep6 + _freeSpots.dep7 + _freeSpots.dep8 + _freeSpots.dep90 + _freeSpots.dep91;
                _freeSpots.sumChildren = _freeSpots.dep1Children + _freeSpots.dep11Children + _freeSpots.dep3Children +
                    _freeSpots.dep4Children + _freeSpots.dep5Children + _freeSpots.dep6Children + _freeSpots.dep7Children +
                    _freeSpots.dep8Children + _freeSpots.dep90Children + _freeSpots.dep91Children;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            //}
            return _freeSpots;
        }

        public static List<DepReport> CheckReports (List<DepReport> reports)
        {
            DepReport dep1, dep11, dep3, dep4, dep5, dep6, dep7, dep8, dep90, dep91; //dep2
            List<DepReport> depReports = new();
          
            dep1 = reports.Find(p => p.depNumber == 1);
            if (dep1 == null)
            {
                dep1 = new();
                dep1.depNumber = 1;
            }
            depReports.Add(dep1);
         
            dep11 = reports.Find(p => p.depNumber == 11);
            if (dep11 == null) 
            {
                dep11 = new();
                dep11.depNumber = 11; 
            }
            depReports.Add(dep11);
           
            dep3 = reports.Find(p => p.depNumber == 3);
            if (dep3 == null)
            {
                dep3 = new();
                dep3.depNumber = 3;
            }
            depReports.Add(dep3);
          
                dep4 = reports.Find(p => p.depNumber == 4);
            if (dep4 == null)
            {
                dep4 = new();
                dep4.depNumber = 4;
            }
            depReports.Add(dep4);
          
                dep5 = reports.Find(p => p.depNumber == 5);
            if (dep5 == null)
            {
                dep5 = new();
                dep5.depNumber = 5;
            }
            depReports.Add(dep5);
           
                dep6 = reports.Find(p => p.depNumber == 6);
            if (dep6 == null)
            {
                dep6 = new();
                dep6.depNumber = 6;
            }
            depReports.Add(dep6);
           
                dep7 = reports.Find(p => p.depNumber == 7);
            if (dep7 == null)
            {
                dep7 = new();
                dep7.depNumber = 7;
            }
            depReports.Add(dep7);
           
                dep8 = reports.Find(p => p.depNumber == 8);
            if (dep8 == null)
            {
                dep8 = new();
                dep8.depNumber = 8;
            }
            depReports.Add(dep8);
          
                dep90 = reports.Find(p => p.depNumber == 90);
            if (dep90 == null)
            {
                dep90 = new();
                dep90.depNumber = 90;
            }
            depReports.Add(dep90);
            
                dep91 = reports.Find(p => p.depNumber == 91);
            if (dep91 == null)
            {
                dep91 = new();
                dep91.depNumber = 91;
            }
            depReports.Add(dep91);
           
            return depReports;
        }
    }
}
