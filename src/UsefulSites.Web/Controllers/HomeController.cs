using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UsefulSites.DataAccess.Api;
using UsefulSites.Web.ViewModels;

namespace UsefulSites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(IResourceTypeDataAccess resourceTypeDataAccess)
        {
            MainViewModel mainViewModel = new MainViewModel();
            var allResources = resourceTypeDataAccess.GetAllResources();
            foreach(var resource in allResources)
            {

            }

            //mainViewModel.TopResources = 

            return View();
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
