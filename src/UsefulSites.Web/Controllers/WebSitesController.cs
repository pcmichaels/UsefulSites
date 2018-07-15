using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsefulSites.DataAccess.Api;
using UsefulSites.Web.Models;
using UsefulSites.Web.ViewModels;

namespace UsefulSites.Web.Controllers
{
    public class WebSitesController : Controller
    {
        private readonly IResourceDataAccess _webSiteAccess;

        public WebSitesController(IResourceDataAccess webSiteAccess)
        {
            _webSiteAccess = webSiteAccess;
        }

        public IActionResult WebSiteList()
        {
            var allSites = _webSiteAccess.GetAllWebSites();
            WebSiteListViewModel webSiteListModel = new WebSiteListViewModel()
            {
                Categories = allSites.GroupBy(a => a.ResourceCategoryId).Select(a => new CategoryModel()
                {
                    WebSiteModels = a.Select(b => new WebSiteModel()
                    {
                        Url = b.Name,
                        Description = b.Description
                    }),
                    CategoryName = a.First().ResourceCategory.Name
                })
            };

            return View(webSiteListModel);
        }

        [HttpPost]
        public void AddSite(WebSiteAddViewModel webSiteAddViewModel)
        {
            _webSiteAccess.CreateWebSite(webSiteAddViewModel.Category.Id, webSiteAddViewModel.Description, webSiteAddViewModel.Url);
        }

        public IActionResult AddSite()
        {
            return View(new WebSiteAddViewModel());
        }
    }
}