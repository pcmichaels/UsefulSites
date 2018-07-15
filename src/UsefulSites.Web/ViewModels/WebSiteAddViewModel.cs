using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefulSites.Web.Models;

namespace UsefulSites.Web.ViewModels
{
    public class WebSiteAddViewModel
    {
        public CategoryModel Category { get; set; }
        public string Url { get; set; }

        public string Description { get; set; }
    }
}
