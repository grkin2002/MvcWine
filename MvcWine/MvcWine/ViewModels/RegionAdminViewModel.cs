using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWine.Models;

namespace MvcWine.ViewModels
{
    public class RegionAdminViewModel
    {
        public Region Region { get; set; }
        public List<Country> Countries { get; set; }
    }
}
