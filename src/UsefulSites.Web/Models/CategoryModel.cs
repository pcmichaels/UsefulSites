using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefulSites.Web.Interfaces;

namespace UsefulSites.Web.Models
{
    public class CategoryModel : ISearchResult
    {
        public string CategoryName { get; set; }
        public IEnumerable<WebSiteModel> WebSiteModels { get; set; }
        public int Id { get; set; }
        public string Description
        {
            get { return "Category: " + CategoryName; }
        }
    }
}
