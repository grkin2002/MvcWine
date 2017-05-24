using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWine.ViewModels
{
    public class RegionIndexViewModel
    {
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string PhotoUrl { get; set; }
        public string IntroText { get; set; }

    }
}
