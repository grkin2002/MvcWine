using System.Linq;
using System.Web.Mvc;
using MvcWine.Models;
using MvcWine.ViewModels;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{


    public class AdminRegionController : Controller
    {

            private IWineRepository _wineRepository;
            public AdminRegionController(): this(new WineRepository()){}
            public AdminRegionController(IWineRepository wineRepository)
            {
                _wineRepository = wineRepository;
            }
        //
        // GET: /RegionAdmin/

        public ActionResult Index()
        {
            var region = from r in _wineRepository.FindAllRegions()
                         orderby r.RegionCode descending
                         select r;

            return View(region);
        }



        //
        // GET: /RegionAdmin/Create
        [MvcSiteMapNodeAttribute(Title = "Create Region", ParentKey = "AdminRegion")] 
        public ActionResult Create()
        {
            var viewModel = new RegionAdminViewModel()
            {
                Region = new Region(),
                Countries = _wineRepository.FindAllCountries().ToList()
            };
            return View( viewModel);
        } 

        //
        // POST: /RegionAdmin/Create

        [HttpPost]
        public ActionResult Create(Region region, FormCollection form)
        {
            try
            {
                region.PhotoUrl = form["PhotoUrl"].ToString();
                region.RegionCode = region.CountryCode.Trim() + region.RegionCode.Trim();
                _wineRepository.AddRegion(region);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                var viewModel = new RegionAdminViewModel()
                {
                    Region = region,
                    Countries = _wineRepository.FindAllCountries().ToList()
                };
                return View(viewModel);
            }
        }

        //
        // GET: /RegionAdmin/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete Region", ParentKey = "AdminRegion")] 
        public ActionResult Delete(string id)
        {
            var region = _wineRepository.FindRegionByCode(id);
            return View(region);
        }

        //
        // POST: /RegionAdmin/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var region = _wineRepository.FindRegionByCode(id);
            try
            {
                _wineRepository.DeleteRegion(region);
                _wineRepository.Save();
 
                return RedirectToAction("Index");
            }
            catch
            {
                
                return View(region);
            }
        }

        //
        // GET: /RegionAdmin/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Region", ParentKey = "AdminRegion")] 
        public ActionResult Edit(string id)
        {

            var viewModel = new RegionAdminViewModel() 
            { 
                Region =_wineRepository.FindRegionByCode(id),
                Countries = _wineRepository.FindAllCountries().ToList()

            };
            return View(viewModel);
        }

        //
        // POST: /RegionAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var region = _wineRepository.FindRegionByCode(id);
            try
            {
                region.PhotoUrl = collection["PhotoUrl"].ToString();
                UpdateModel(region, "Region");
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                var viewModel = new RegionAdminViewModel()
                {
                    Region = region,
                    Countries = _wineRepository.FindAllCountries().ToList()
                };
                return View(viewModel);
            }
        }
    }
}
