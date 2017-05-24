using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using MvcSiteMapProvider;

namespace MvcWine.Controllers
{
    public class AdminMadeByController : Controller
    {

        private IWineRepository _wineRepository;
        public AdminMadeByController() : this(new WineRepository()) { }
        public AdminMadeByController(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }
        //
        // GET: /MadeBy/

        public ActionResult Index()
        {
            var producers = from p in _wineRepository.FindAllProducers()
                           orderby p.ProducerId descending
                           select p;
            return View(producers);
        }



        //
        // GET: /MadeBy/Create
        [MvcSiteMapNodeAttribute(Title = "Create Producer", ParentKey = "AdminMadeBy")] 
        public ActionResult Create()
        {
            Producer p = new Producer();
            return View(p);
        } 

        //
        // POST: /MadeBy/Create

        [HttpPost]
        public ActionResult Create(Producer p, FormCollection collection)
        {
            try
            {
                _wineRepository.AddProducer(p);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MadeBy/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete Producer", ParentKey = "AdminMadeBy")] 
        public ActionResult Delete(int id)
        {
            var producer = _wineRepository.FindProducerById(id);
            
            return View(producer);
        }

        //
        // POST: /MadeBy/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var producer = _wineRepository.FindProducerById(id);
            try
            {
                _wineRepository.DeleteProducer(producer);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(producer);
            }
        }

        //
        // GET: /MadeBy/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Producer", ParentKey = "AdminMadeBy")] 
        public ActionResult Edit(int id)
        {
            var producer = _wineRepository.FindProducerById(id);
     
            return View(producer);
        }

        //
        // POST: /MadeBy/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var producer = _wineRepository.FindProducerById(id);
            try
            {
               
                UpdateModel(producer);
                _wineRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(producer);
            }
        }
    }
}
