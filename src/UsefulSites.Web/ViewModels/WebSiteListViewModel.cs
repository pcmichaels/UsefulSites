using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefulSites.Web.Models;

namespace UsefulSites.Web.ViewModels
{
    public class WebSiteListViewModel
    {        
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
