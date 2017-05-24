using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using MvcWine.Models;
using MvcWine.Helpers;

namespace MvcWine
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Aspxpage/{weform}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        private void InitialDictionary()
        {
            WineDataContext db = new WineDataContext();
            RegisterCountryDict(db);
            RegisterRegionDict(db);
            RegisterSubRegionDict(db);
            RegisterGrapedict(db);
            RegisterWineDict(db);
            RegisterProducerDict(db);
            RegisterTasteDict(db);
        }

        private void RegisterTasteDict(WineDataContext db)
        {
            var tastes = from t in db.Taste
                         select new
                         {
                             t.TasteType,
                             t.TasteDesc
                         };
            Dictionary<string, string> TasteDict = tastes.ToDictionary(t => t.TasteType.Trim(), p => p.TasteDesc);
            Application[ConstName.TasteDict] = TasteDict;
        }

        private void RegisterProducerDict(WineDataContext db)
        {
            var producers = from p in db.Producer
                            select new
                            {
                                p.ProducerId,
                                p.ProducerName
                            };
            Dictionary<int, string> ProducerDict = producers.ToDictionary(p => p.ProducerId, p => p.ProducerName);
            Application[ConstName.ProducerDict] = ProducerDict;
        }

        private void RegisterWineDict(WineDataContext db)
        {
            var wines = from w in db.Wine
                        select new
                        {
                            w.WineId,
                            w.WineType
                        };
            Dictionary<int, string> WineDict = wines.ToDictionary(w => w.WineId, w => w.WineType);
            Application[ConstName.WineDict] = WineDict;

        }

        private void RegisterGrapedict(WineDataContext db)
        {
            var grapes = from g in db.Grape
                         select new
                         {
                             g.GrapeId,
                             g.GrapeType
                         };
            Dictionary<int, string> GrapeDict = grapes.ToDictionary(g => g.GrapeId, g => g.GrapeType);
            Application[ConstName.GrapeDict] = GrapeDict;
        }

        private void RegisterSubRegionDict(WineDataContext db)
        {
            var subRegions = from s in db.SubRegion
                             select new
                             {
                                 s.SubRegionCode,
                                 s.SubRegionName
                             };
            Dictionary<string, string> SubRegionDict = subRegions.ToDictionary(s => s.SubRegionCode.Trim(), s => s.SubRegionName);
            SubRegionDict.Add("", "Not Found");
            Application[ConstName.SubRegionDict] = SubRegionDict;

        }

        private void RegisterRegionDict(WineDataContext db)
        {
            var regions = from r in db.Region
                          select new 
                          { 
                              r.RegionCode, 
                              r.RegionName 
                          };
            Dictionary<string, string> RegionDict = regions.ToDictionary(r => r.RegionCode.Trim(), r => r.RegionName);
            RegionDict.Add("", "Not Found");
            Application[ConstName.RegionDict] = RegionDict;
        }

        private void RegisterCountryDict( WineDataContext db)
        {
            var countries = from c in db.Country
                            select new
                            {
                                c.CountryCode,
                                c.CountryName
                            };

            Dictionary<string, string> CountryDict = countries.ToDictionary(c => c.CountryCode.Trim(), c => c.CountryName);
            CountryDict.Add("", "Not Found");
            Application[ConstName.CountryDict] = CountryDict;

        }

      



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            InitialDictionary();
        }


    }
}