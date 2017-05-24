using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using MvcWine.ViewModels;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{
    public class AdminSubregionController : Controller
    {
        IWineRepository _wineRepository;
        public AdminSubregionController() : this(new WineRepository()) { }
        public AdminSubregionController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }
        //
        // GET: /AdminSubregion/

        public ActionResult Index()
        {
            var subregions = from s in _wineRepository.FindAllSubRegions()
                             orderby s.SubRegionCode descending
                             select s;

            return View(subregions);
        }



        //
        // GET: /AdminSubregion/Create
        [MvcSiteMapNodeAttribute(Title = "Create SubRegion", ParentKey = "AdminSubRegion")] 
        public ActionResult Create()
        {
            SubRegionAdminViewModel viewModel = new SubRegionAdminViewModel()
            {
                SubRegion = new SubRegion(),
                Countries = _wineRepository.FindAllCountries().ToList(),
                Regions = _wineRepository.FindAllRegions().ToList()

            };
            return View(viewModel);
        }

        //
        // POST: /AdminSubregion/Create

        [HttpPost]
        public ActionResult Create(SubRegion subRegion, FormCollection form)
        {
            try
            {
                subRegion.PhotoUrl = form["PhotoUrl"].ToString();
                subRegion.SubRegionCode = subRegion.RegionCode.Trim() + subRegion.SubRegionCode.Trim();
                _wineRepository.AddSubRegion(subRegion);
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                SubRegionAdminViewModel viewModel = new SubRegionAdminViewModel()
                {
                    SubRegion = subRegion,
                    Countries = _wineRepository.FindAllCountries().ToList(),
                    Regions = _wineRepository.FindAllRegions().ToList()

                };
                return View(viewModel);
            }
        }

        //
        // GET: /AdminSubregion/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete SubRegion", ParentKey = "AdminSubRegion")] 
        public ActionResult Delete(string id)
        {
            var subRegion = _wineRepository.FindSubRegionByCode(id);
            return View(subRegion);
        }

        //
        // POST: /AdminSubregion/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var subRegion = _wineRepository.FindSubRegionByCode(id);
            try
            {
                _wineRepository.DeleteSubRegion(subRegion);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminSubregion/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit SubRegion", ParentKey = "AdminSubRegion")] 
        public ActionResult Edit(string id)
        {
            SubRegionAdminViewModel viewModel = new SubRegionAdminViewModel()
            {
                SubRegion = _wineRepository.FindSubRegionByCode( id),
                Countries = _wineRepository.FindAllCountries().ToList(),
                Regions = _wineRepository.FindAllRegions().ToList()

            };
            return View(viewModel);
        }

        //
        // POST: /AdminSubregion/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection form)
        {
            var subRegion = _wineRepository.FindSubRegionByCode(id);
            try
            {
                subRegion.PhotoUrl = form["PhotoUrl"].ToString();
                UpdateModel(subRegion, "SubRegion");
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                SubRegionAdminViewModel viewModel = new SubRegionAdminViewModel()
                {
                    SubRegion = subRegion,
                    Countries = _wineRepository.FindAllCountries().ToList(),
                    Regions = _wineRepository.FindAllRegions().ToList()

                };
                return View(viewModel);
            }
        }
    }
}
