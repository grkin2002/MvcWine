using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{
    public class AdminPromoteController : Controller
    {
        
        IWineRepository _wineRepository;
        public AdminPromoteController() : this(new WineRepository()) 
        { }
        public AdminPromoteController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        //
        // GET: /AdminPromote/

        public ActionResult Index()
        {
            var promote = from p in _wineRepository.FindAllPromotes() select p;
            return View(promote);
        }


        //
        // GET: /AdminPromote/Create
        [MvcSiteMapNodeAttribute(Title = "Create Promote", ParentKey = "AdminPromote")] 
        public ActionResult Create()
        {
            Promote promote = new Promote();
            return View(promote);
        } 

        //
        // POST: /AdminPromote/Create

        [HttpPost]
        public ActionResult Create(Promote promote)
        {

            try
            {
                _wineRepository.AddPromote(promote);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminPromote/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete Promote", ParentKey = "AdminPromote")] 
        public ActionResult Delete(string  id)
        {
            Promote promote = _wineRepository.FindPromoteById(id);

            return View(promote);
        }

        //
        // POST: /AdminPromote/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            Promote promote = _wineRepository.FindPromoteById(id);
            try
            {
                _wineRepository.DeletePromote(promote);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminPromote/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Promote", ParentKey = "AdminPromote")] 
        public ActionResult Edit(string id)
        {
            Promote promote = _wineRepository.FindPromoteById(id);
            return View(promote);
        }

        //
        // POST: /AdminPromote/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            Promote promote = _wineRepository.FindPromoteById(id);

            try
            {
                UpdateModel(promote);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(promote);
            }
        }
    }
}
