using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.Data;
using UsefulSites.Web.Models;
using UsefulSites.Web.ViewModels;

namespace UsefulSites.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResourceTypeDataAccess _resourceTypeDataAccess;
        private readonly IResourceDataAccess _resourceDataAccess;
        private readonly IResourceCategoryDataAccess _categoryDataAccess;

        public HomeController(IResourceTypeDataAccess resourceTypeDataAccess,
            IResourceDataAccess resourceDataAccess, IResourceCategoryDataAccess categoryDataAccess)
        {
            _resourceTypeDataAccess = resourceTypeDataAccess;
            _resourceDataAccess = resourceDataAccess;
            _categoryDataAccess = categoryDataAccess;
        }

        public IActionResult Index()
        {
            MainViewModel mainViewModel = new MainViewModel()
            {
                TopResources = new List<ResourcesByTypeModel>(),
                Categories = new List<CategoryModel>()
            };

            GetResources(mainViewModel);
            GetCategories(mainViewModel);

            return View(mainViewModel);
        }

        private void GetCategories(MainViewModel mainViewModel)
        {
            IEnumerable<ResourceCategory> categories = _categoryDataAccess.GetAllCategories();

            mainViewModel.Categories = categories
                .Select(a => new CategoryModel()
                {
                    Id = a.Id,
                    CategoryName = a.Name,
                    WebSiteModels = new List<WebSiteModel>()
                }).ToList();
        }

        private void GetResources(MainViewModel mainViewModel)
        {
            mainViewModel.AllWebSites = new List<WebSiteModel>();
            int topResourceCount = 5;

            var allResourceTypes = _resourceTypeDataAccess.GetAllResourceTypes();

            foreach (var resourceType in allResourceTypes)
            {
                ResourcesByTypeModel resourcesByTypeModel = new ResourcesByTypeModel()
                {
                    ResourceTypeModel = new ResourceTypeModel()
                    {
                        Name = resourceType.Name,
                        Description = ""
                    },
                    Resources = new List<ResourceModel>()
                };

                List<ResourceModel> resourceModels = new List<ResourceModel>();
                var resources = _resourceDataAccess.GetResourceByType(resourceType.Id);

                int resourceCount = 0;
                foreach (var resource in resources.OrderByDescending(a => a.Rating))
                {
                    var resourceModel = new WebSiteModel()
                    {
                        Name = resource.Name,
                        Description = resource.Description
                    };

                    if (resourceCount++ < topResourceCount)
                    {
                        resourcesByTypeModel.Resources.Add(resourceModel);
                    }
                    mainViewModel.AllWebSites.Add(resourceModel);
                }

                mainViewModel.TopResources.Add(resourcesByTypeModel);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Useful Sites.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
