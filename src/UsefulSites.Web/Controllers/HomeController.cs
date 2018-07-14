using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsefulSites.DataAccess.Api;
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
            var categories = _categoryDataAccess.GetAllCategories();

            mainViewModel.Categories = categories
                .Select(a => new CategoryModel()
                {
                    CategoryName = a.Name,
                    WebSiteModels = new List<WebSiteModel>()
                }).ToList();
        }

        private void GetResources(MainViewModel mainViewModel)
        {
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

                foreach (var resource in resources.Take(5))
                {
                    resourcesByTypeModel.Resources.Add(
                        new ResourceModel()
                        {
                            Name = resource.Name,
                            Description = resource.Description
                        });
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
