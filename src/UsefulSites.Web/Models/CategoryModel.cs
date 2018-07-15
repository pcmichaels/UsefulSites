using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsefulSites.Web.Models
{
    public class CategoryModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<WebSiteModel> WebSiteModels { get; set; }
        public int Id { get; set; }
    }
}
