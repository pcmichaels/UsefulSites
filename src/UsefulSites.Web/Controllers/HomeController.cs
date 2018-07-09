using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsefulSites.DataAccess.Api;
using UsefulSites.Web.Models;
using UsefulSites.Web.ViewModels;

namespace UsefulSites.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResourceTypeDataAccess _resourceTypeDataAccess;
        private readonly IResourceDataAccess _resourceDataAccess;

        public HomeController(IResourceTypeDataAccess resourceTypeDataAccess,
            IResourceDataAccess resourceDataAccess)
        {
            _resourceTypeDataAccess = resourceTypeDataAccess;
            _resourceDataAccess = resourceDataAccess;
        }

        public IActionResult Index()
        {
            MainViewModel mainViewModel = new MainViewModel()
            {
                TopResources = new List<ResourcesByTypeModel>()
            };

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

            return View(mainViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
