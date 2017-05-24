using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWine.Models;

namespace MvcWine.ViewModels
{
    public class SubRegionAdminViewModel
    {
        public SubRegion SubRegion { get; set; }
        public List<Country> Countries { get; set; }
        public List<Region> Regions { get; set; }

    }
}
