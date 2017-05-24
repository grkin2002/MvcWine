using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWine.Models;
using MvcSiteMapProvider;
using MvcWine.ViewModels;
using Webdiyer.WebControls.Mvc;
using MvcWine.Helpers;

namespace MvcWine.Controllers
{
    public class ListController : Controller
    {

        IWineRepository _wineRepository;
        public ListController()
            : this(new WineRepository())
        { }
        public ListController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        //
        // GET: /Country/;
        // GET: /Country/Index

        public ActionResult Index()
        {
            var country = _wineRepository.FindAllCountries();
            return View(country);
        }

        //
        // GET: /List/ListByCountry/0010
        [MvcSiteMapNodeAttribute(Title = "List By Country", ParentKey = "List")]
        public ActionResult ListByCountry(string id, int? pageIndex)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Country = _wineRepository.FindCountryByCode(id);

            var Products = from p in _wineRepository.FindAllProds()
                           where p.CountryCode.Trim() == id.Trim()
                           select p;

            viewModel.Products = Products.ToPagedList(pageIndex?? 1, ConstName.PageSize);
            if (Request.IsAjaxRequest())
                return PartialView("ListProductUserControl", viewModel.Products);

            return View(viewModel);
        }

        //GET: /List/ListByRegion/001010
        [MvcSiteMapNodeAttribute(Title = "List By Region", ParentKey = "List")]
        public ActionResult ListByRegion(string id, int? pageIndex)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Region = _wineRepository.FindRegionByCode(id);

            var Products = from p in _wineRepository.FindAllProds()
                           where p.RegionCode.Trim() == id.Trim()
                           select p;
            viewModel.Products = Products.ToPagedList(pageIndex?? 1,ConstName.PageSize);
            if (Request.IsAjaxRequest())
                return PartialView("ListProductUserControl", viewModel.Products);
            return View(viewModel);
        }

        //GET: /List/ListBySubRegion/00101010
        [MvcSiteMapNodeAttribute(Title = "List By SubRegion", ParentKey = "List")]
        public ActionResult ListBySubRegion(string id, int? pageIndex)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.SubRegion = _wineRepository.FindSubRegionByCode(id);
            var Products = from p in _wineRepository.FindAllProds()
                           where p.SubRegionCode.Trim() == id.Trim()
                           select p;
            viewModel.Products = Products.ToPagedList(pageIndex?? 1, ConstName.PageSize);
            if (Request.IsAjaxRequest())
                return PartialView("ListProductUserControl", viewModel.Products);
            return View(viewModel);
        }


    }
}
