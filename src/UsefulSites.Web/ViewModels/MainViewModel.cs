using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefulSites.Web.Interfaces;
using UsefulSites.Web.Models;

namespace UsefulSites.Web.ViewModels
{
    public class MainViewModel
    {
        public IList<WebSiteModel> AllWebSites { get; set; }
        public IList<ResourcesByTypeModel> TopResources { get; set; }
        public IList<CategoryModel> Categories { get; set; }

        public IEnumerable<ISearchResult> SearchResults
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SearchText)) return new List<ISearchResult>();

                var categorySearch = Categories.Where(a => a.Description.Contains(SearchText)).Select(a => (ISearchResult)a);
                var resourceSearch = AllWebSites.Where(a => a.Description.Contains(SearchText)).Select(a => (ISearchResult)a);

                return categorySearch
                    .Union(resourceSearch);
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

            }
        }
    }
}
