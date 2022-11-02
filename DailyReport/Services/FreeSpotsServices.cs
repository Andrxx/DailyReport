using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DailyReport.Services
{
    public static class FreeSpotsServices
    {
        static FreeSpots _freeSpots;
        public static FreeSpots CountSpots(List<DepReport> _dRep, DepartmentSpots _ds )
        {
            _freeSpots = new();
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            _freeSpots.dep1 = _ds.dep1  - _dRep.Find(p => p.depNumber == 1).present;
            _freeSpots.dep1Children = _ds.dep11Children - _dRep.Find(p => p.depNumber == 1).presentChildrens;
            _freeSpots.dep11 = _ds.dep11 + -_dRep.Find(p => p.depNumber == 11).present;
            _freeSpots.dep11Children = _ds.dep11Children - _dRep.Find(p => p.depNumber == 11).presentChildrens;
            //_freeSpots.dep2 = _ds.dep2 + _ds. - _dRep.Find(p => p.depNumber == 2).present - _dRep.Find(p => p.depNumber == 2).presentChildrens;
            _freeSpots.dep3 = _ds.dep3 -  _dRep.Find(p => p.depNumber == 3).present;
            _freeSpots.dep3Children = _ds.dep3Children - _dRep.Find(p => p.depNumber == 3).presentChildrens; 
            _freeSpots.dep4 = _ds.dep4   - _dRep.Find(p => p.depNumber == 4).present;
            _freeSpots.dep4Children = _ds.dep4Children - _dRep.Find(p => p.depNumber == 4).presentChildrens;
            _freeSpots.dep5 = _ds.dep5 - _dRep.Find(p => p.depNumber == 5).present;
            _freeSpots.dep5Children = _ds.dep5Children - _dRep.Find(p => p.depNumber == 5).presentChildrens;
            _freeSpots.dep6 = _ds.dep6 - _dRep.Find(p => p.depNumber == 6).present;
            _freeSpots.dep6Children = _ds.dep6Children - _dRep.Find(p => p.depNumber == 6).presentChildrens;
            _freeSpots.dep7 = _ds.dep7  - _dRep.Find(p => p.depNumber == 7).present;
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

            return _freeSpots;
        }
    }
}
