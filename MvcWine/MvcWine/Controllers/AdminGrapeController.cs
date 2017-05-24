using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{
    public class AdminGrapeController : Controller
    {
        IWineRepository _wineRepository;
        public AdminGrapeController() : this(new WineRepository()) { }
        public AdminGrapeController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public ActionResult Index()
        {
            var grapes = from g in  _wineRepository.FindAllGrapes()
                         orderby g.GrapeId descending
                         select g;

            return View(grapes);
        }

 

        //
        // GET: /GrapeAdmin/Create
        [MvcSiteMapNodeAttribute(Title = "Create GrapeType", ParentKey = "AdminGrape")] 
        public ActionResult Create()
        {
            Grape grape = new Grape();
            return View(grape);
        } 

        //
        // POST: /GrapeAdmin/Create

        [HttpPost]
        public ActionResult Create(Grape grape)
        {
            try
            {
                _wineRepository.AddGrape(grape);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GrapeAdmin/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete GrapeType", ParentKey = "AdminGrape")] 
        public ActionResult Delete(int id)
        {
            Grape grape = _wineRepository.FindGrapeByGrapeId(id);
            return View(grape);
        }

        //
        // POST: /GrapeAdmin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Grape grape = _wineRepository.FindGrapeByGrapeId(id);
            try
            {
                _wineRepository.DeleteGrape(grape);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GrapeAdmin/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Grape", ParentKey = "AdminGrape")] 
        public ActionResult Edit(int id)
        {
            Grape grape = _wineRepository.FindGrapeByGrapeId(id);
            return View(grape);
        }

        //
        // POST: /GrapeAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Grape grape = _wineRepository.FindGrapeByGrapeId(id);
            try
            {
               UpdateModel(grape,null, null, new string[]{ "GrapeId"});
               _wineRepository.Save();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(grape);
            }
        }
    }
}
