using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsefulSites.DataAccess.Api;
using UsefulSites.Web.Models;

namespace UsefulSites.Web.Controllers
{
    public class WebSitesController : Controller
    {
        private readonly IWebSiteDataAccess _webSiteAccess;

        public WebSitesController(IWebSiteDataAccess webSiteAccess)
        {
            _webSiteAccess = webSiteAccess;
        }

        public IActionResult WebSiteList()
        {
            var allSites = _webSiteAccess.GetAllWebSites();
            WebSiteListModel webSiteListModel = new WebSiteListModel()
            {
                Categories = allSites.GroupBy(a => a.ResourceCategoryId).Select(a => new CategoryModel()
                {
                    WebSiteModels = a.Select(b => new WebSiteModel()
                    {
                        Url = b.Name,
                        Description = b.Description
                    })
                })
            };

            return View(webSiteListModel);
        }
    }
}