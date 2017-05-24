using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWine.Models;
using Webdiyer.WebControls.Mvc;

namespace MvcWine.ViewModels
{
    public class ProductViewModel
    {
        public PagedList<Product> Products { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public SubRegion SubRegion { get; set; }

        //filter 
        public string CountryCode { get; set; }
        public string RegionCode { get; set; }
        public string SubRegionCode { get; set; }
        public int GrapeId { get; set; }
        public int WineId { get; set; }
        public int ProducerId { get; set; }
        public string PromoteType { get; set; }
        public string TasteType { get; set; }
        public string CapType { get; set; }


    }
}
