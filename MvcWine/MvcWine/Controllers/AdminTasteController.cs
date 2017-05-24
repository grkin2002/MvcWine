using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{
    public class AdminTasteController : Controller
    {

                IWineRepository _wineRepository;
        public AdminTasteController() : this(new WineRepository()) 
        { }
        public AdminTasteController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }
        //
        // GET: /AdminTaste/

        public ActionResult Index()
        {
            var taste = _wineRepository.FindAllTastes();
                        
            return View(taste);
        }

   

        //
        // GET: /AdminTaste/Create
        [MvcSiteMapNodeAttribute(Title = "Create Taste", ParentKey = "AdminTaste")] 
        public ActionResult Create()
        {
            Taste taste = new Taste();
            return View(taste);
        } 

        //
        // POST: /AdminTaste/Create

        [HttpPost]
        public ActionResult Create(Taste taste)
        {
            try
            {
                _wineRepository.AddTaste(taste);
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(taste);
            }
        }

        //
        // GET: /AdminTaste/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete Taste", ParentKey = "AdminTaste")] 
        public ActionResult Delete(string id)
        {
            Taste taste = _wineRepository.FindTasteById(id);
            return View(taste);
        }

        //
        // POST: /AdminTaste/Delete/5

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            Taste taste = _wineRepository.FindTasteById(id);
            try
            {
                _wineRepository.DeleteTaste(taste);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminTaste/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Taste", ParentKey = "AdminTaste")] 
        public ActionResult Edit(string id)
        {
            Taste taste = _wineRepository.FindTasteById(id);
            return View(taste);
        }

        //
        // POST: /AdminTaste/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            Taste taste = _wineRepository.FindTasteById(id);
            try
            {
                UpdateModel(taste);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(taste);
            }
        }
    }
}
