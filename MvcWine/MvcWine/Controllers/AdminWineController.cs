using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{
    public class AdminWineController : Controller
    {

        IWineRepository _wineRepository;
        public AdminWineController() : this(new WineRepository()) 
        { }
        public AdminWineController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }
        //
        // GET: /WineAdmin/

        public ActionResult Index()
        {
            var wine = from w in _wineRepository.FindAllWines()
                       orderby w.WineId descending
                       select w;

            return View(wine);
        }

   
 

        //
        // GET: /WineAdmin/Create
        [MvcSiteMapNodeAttribute(Title = "Create Wine", ParentKey = "AdminWine")] 
        public ActionResult Create()
        {
            Wine wine = new Wine();
            return View(wine);
        } 

        //
        // POST: /WineAdmin/Create

        [HttpPost]
        public ActionResult Create(Wine wine)
        {
            try
            {
                _wineRepository.AddWine(wine);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /WineAdmin/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete Wine", ParentKey = "AdminWine")] 
        public ActionResult Delete(int id)
        {
           Wine wine =  _wineRepository.FindWineByWineId(id);
           return View(wine);
        }

        //
        // POST: /WineAdmin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Wine wine = _wineRepository.FindWineByWineId(id);
            try
            {
                _wineRepository.DeleteWine(wine);
                _wineRepository.Save();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(wine);
            }
        }

        //
        // GET: /WineAdmin/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Wine", ParentKey = "AdminWine")] 
        public ActionResult Edit(int id)
        {
            Wine wine = _wineRepository.FindWineByWineId(id);
            return View(wine);
        }

        //
        // POST: /WineAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id,FormCollection formValues)
        {
            Wine wine = _wineRepository.FindWineByWineId(id);
            try
            {

                UpdateModel(wine);
                _wineRepository.Save();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(wine);
            }
        }
    }
}
