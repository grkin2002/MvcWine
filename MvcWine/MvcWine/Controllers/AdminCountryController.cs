using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using System.IO;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{
    public class AdminCountryController : Controller
    {

        IWineRepository _wineRepository;
        public AdminCountryController() : this(new WineRepository()) 
        { }
        public AdminCountryController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        
        //
        // GET: /CountryAdmin/

        public ActionResult Index()
        {

            var country = from c in _wineRepository.FindAllCountries()
                          orderby c.CountryCode descending
                          select c;
            return View(country);
        }



        //
        // GET: /CountryAdmin/Create

        public ActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }

        //
        // POST: /CountryAdmin/Create
        [MvcSiteMapNodeAttribute(Title = "Create Country", ParentKey = "AdminCountry")] 
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                _wineRepository.AddCountry(country);
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CountryAdmin/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete Country", ParentKey = "AdminCountry")] 
        public ActionResult Delete(string id)
        {
            Country country = _wineRepository.FindCountryByCode(id);

            return View(country);
        }

        //
        // POST: /CountryAdmin/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            Country country = _wineRepository.FindCountryByCode(id);
            try
            {
                _wineRepository.DeleteCountry(country);
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(country);
            }
        }

        //
        // GET: /CountryAdmin/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Country", ParentKey = "AdminCountry")] 
        public ActionResult Edit(string id)
        {
            var country = _wineRepository.FindCountryByCode(id);
            return View(country);
        }

        //
        // POST: /CountryAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection formValues)
        {
            var country = _wineRepository.FindCountryByCode(id);
            try
            {

                UpdateModel(country);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {

                return View(country);
            }
        }



     


    }
}
