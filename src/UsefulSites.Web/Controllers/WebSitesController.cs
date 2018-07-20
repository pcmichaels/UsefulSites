using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.Data;
using UsefulSites.Web.Extensions;
using UsefulSites.Web.Models;
using UsefulSites.Web.ViewModels;

namespace UsefulSites.Web.Controllers
{
    public class WebSitesController : Controller
    {
        private readonly IResourceDataAccess _webSiteAccess;
        private readonly IResourceCategoryDataAccess _resourceCategoryDataAccess;

        public WebSitesController(IResourceDataAccess webSiteAccess, IResourceCategoryDataAccess resourceCategoryDataAccess)
        {
            _webSiteAccess = webSiteAccess;
            _resourceCategoryDataAccess = resourceCategoryDataAccess;
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
        public IActionResult AddSite(WebSiteAddViewModel webSiteAddViewModel)
        {
            if (webSiteAddViewModel.Category == null)
            {                
                return RedirectToAction("AddSite", routeValues: "Category Not Valid");
            }

            int result = _webSiteAccess.CreateWebSite(webSiteAddViewModel.Category.Id, webSiteAddViewModel.Description, webSiteAddViewModel.Url);

            return RedirectToAction("GetSite", result);
        }

        [HttpGet("{id}")]
        public IActionResult GetSite(int id)
        {
            Resource result = _webSiteAccess.GetWebSite(id);
            if (result == null)
            {
                return NotFound();
            }

            var resource = result.ToResourceModel();
            return View(resource);
        }

        [HttpGet("{error}")]
        public IActionResult AddSite(string error)
        {
            var webSiteViewModel = new WebSiteAddViewModel();
            webSiteViewModel.Categories = _resourceCategoryDataAccess.GetAllCategories().ToCategoryModels();
            webSiteViewModel.Error = error;

            return View(webSiteViewModel);

        }

        [HttpGet]
        public IActionResult AddSite()
        {
            return AddSite(string.Empty);
        }

    }
}