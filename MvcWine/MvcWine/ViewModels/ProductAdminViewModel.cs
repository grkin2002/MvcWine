using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWine.Models;
using System.Web.Mvc;

namespace MvcWine.ViewModels
{
    public class Cape
    {
        public int id { get; set; }
        public string CapType { get; set; }
    }
    public class Vintage
    {
        public int VintageValue { get; set; }
        public string VintageString { get; set; }
    }
    public class YearToDrink
    {
        public int YearValue { get; set; }
        public string YearString { get; set; }
    }

    public class ProductAdminViewModel
    {
        public Product Product { get; set; }
        public List<Country> Countries { get; set; }
      
        public List<Grape> Grapes { get; set; }
        public List<Wine> Wines { get; set; }
        public List<Producer> Producers { get; set; }
        public List<Promote> Promotes { get; set; }
        public List<Taste> Tastes { get; set; }
        public List<Cape> CapeTypes = new List<Cape>();
        public List<YearToDrink> DrinkYear = new List<YearToDrink>();
        public List<Vintage> Vintages = new List<Vintage>();

        public ProductAdminViewModel()
        {
            CapeTypes.Add(new Cape() { id = 1, CapType = "ScrewCape" });
            CapeTypes.Add(new Cape() { id=2, CapType ="Cork"});
            CapeTypes.Add(new Cape() { id = 3, CapType = "Synthetic cork" });

            for (int i = DateTime.Now.Year - 2; i <= DateTime.Now.Year + 20; i++)
                DrinkYear.Add(new YearToDrink { YearValue = i, YearString = i.ToString() });

            Vintages.Add(new Vintage() { VintageValue = 0, VintageString="Non Vintage"});
            Vintages.Add(new Vintage() { VintageValue = 1, VintageString = "Vintage and Prestige" });
            for (int i = DateTime.Now.Year-30; i <=DateTime.Now.Year; i++)
                Vintages.Add(new Vintage() { VintageValue = i, VintageString = i.ToString() });
        }




    }
}
