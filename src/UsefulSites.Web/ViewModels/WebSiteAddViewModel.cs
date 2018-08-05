using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefulSites.Web.Models;

namespace UsefulSites.Web.ViewModels
{
    public class WebSiteAddViewModel
    {
        public string Category { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }        
        public string Url { get; set; }

        public string Description { get; set; }

        public string Error { get; set; }
    }
}
