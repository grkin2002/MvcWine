using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MvcWine.Models;

namespace MvcWine.Services
{
    /// <summary>
    /// LocationService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
     //若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class LocationService : System.Web.Services.WebService
    {
        IWineRepository _wineRepository;

        [WebMethod]
        public List<RegionCompact> Regions(string CountryCode)
        {
            _wineRepository = new WineRepository();
            var regions = from m in _wineRepository.FindAllRegions()
                          where m.CountryCode.Trim() == CountryCode
                          select new RegionCompact
                          {
                              RegionCode = m.RegionCode,
                              RegionName = m.RegionName
                          };
            return regions.ToList(); 
        }

        [WebMethod]
        public List<SubRegionCompact> SubRegions(string RegionCode)
        {
            _wineRepository = new WineRepository();
            var subRegions = from m in _wineRepository.FindAllSubRegions()
                             where m.RegionCode.Trim() == RegionCode
                             select new SubRegionCompact
                             {
                                 SubRegionCode = m.SubRegionCode,
                                 SubRegionName = m.SubRegionName
                             };
            return subRegions.ToList();
        }
    }

    public class RegionCompact
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
    }

    public class SubRegionCompact
    {
        public string SubRegionCode { get; set; }
        public string SubRegionName { get; set; }
    }
}
