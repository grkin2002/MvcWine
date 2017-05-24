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
    public class AdminProductController : Controller
    {
        private IWineRepository _wineRepository;
        public AdminProductController() : this(new WineRepository()) { }
        public AdminProductController(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }
        //
        // GET: /AdminProduct/

        public ActionResult Index()
        {
            var product = from p in _wineRepository.FindAllProds()
                          orderby p.ProductId descending
                          select p;
            return View(product);
        }



        //
        // GET: /AdminProduct/Create
        [MvcSiteMapNodeAttribute(Title = "Create Product", ParentKey = "AdminProduct")] 
        public ActionResult Create()
        {
            ProductAdminViewModel viewModel = new ProductAdminViewModel()
            {
                Product = new Product(),
                Countries = _wineRepository.FindAllCountries().ToList(),
                Grapes = _wineRepository.FindAllGrapes().ToList(),
                Wines = _wineRepository.FindAllWines().ToList(),
                Producers = _wineRepository.FindAllProducers().ToList(),
                Promotes = _wineRepository.FindAllPromotes().ToList(),
                Tastes = _wineRepository.FindAllTastes().ToList()
            };
            return View(viewModel);
        }

        //
        // POST: /AdminProduct/Create

        [HttpPost]
        public ActionResult Create(Product product, FormCollection form)
        {
            try
            {
                product.PhotoUrl = form["PhotoUrl"].ToString();
                _wineRepository.AddProd(product);
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminProduct/Delete/5
        [MvcSiteMapNodeAttribute(Title = "Delete Product", ParentKey = "AdminProduct")] 
        public ActionResult Delete(int id)
        {
            Product prod = _wineRepository.FindProdById(id);

            return View(prod);
        }

        //
        // POST: /AdminProduct/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Product prod = _wineRepository.FindProdById(id);

            try
            {
                _wineRepository.DeleteProd(prod);
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminProduct/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Edit Product", ParentKey = "AdminProduct")] 
        public ActionResult Edit(int id)
        {
            ProductAdminViewModel viewModel = new ProductAdminViewModel()
            {
                Product = _wineRepository.FindProdById(id),
                Countries = _wineRepository.FindAllCountries().ToList(),
                Grapes = _wineRepository.FindAllGrapes().ToList(),
                Wines = _wineRepository.FindAllWines().ToList(),
                Producers = _wineRepository.FindAllProducers().ToList(),
                Promotes = _wineRepository.FindAllPromotes().ToList(),
                Tastes = _wineRepository.FindAllTastes().ToList()

            };
            
            return View(viewModel);
        }

        //
        // POST: /AdminProduct/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            Product product = _wineRepository.FindProdById(id);
            try
            {
                
                UpdateModel(product, "Product");
                product.PhotoUrl = form["PhotoUrl"].ToString();
                _wineRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                ProductAdminViewModel viewModel = new ProductAdminViewModel()
                {
                    Product = product,
                    Countries = _wineRepository.FindAllCountries().ToList(),
                    Grapes = _wineRepository.FindAllGrapes().ToList(),
                    Wines = _wineRepository.FindAllWines().ToList(),
                    Producers = _wineRepository.FindAllProducers().ToList(),
                    Promotes = _wineRepository.FindAllPromotes().ToList(),
                    Tastes = _wineRepository.FindAllTastes().ToList()

                };
                return View();
            }
        }
    }
}
