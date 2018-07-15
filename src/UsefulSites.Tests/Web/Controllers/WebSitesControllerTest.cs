using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using UsefulSites.DataAccess.Api;
using UsefulSites.Web.Controllers;
using UsefulSites.Web.Models;
using UsefulSites.Web.ViewModels;
using Xunit;

namespace UsefulSites.Tests.Web.Controllers
{
    public class WebSitesControllerTest
    {
        [Fact]
        public void CallAddSite_NoData()
        {

            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess);

            // Act
            var result = webSiteController.AddSite();

            // Assert
            ViewResult view = Assert.IsType<ViewResult>(result);
            WebSiteAddViewModel viewModel = Assert.IsType<WebSiteAddViewModel>(view.Model);
        }

        [Fact]
        public void CallAddSite_Post()
        {

            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess);

            int categoryId = 1;

            var webSiteViewModel = new WebSiteAddViewModel()
            {
                Url = "https://www.test.com",
                Description = "Testing",
                Category = new CategoryModel() { CategoryName = "test", Id = categoryId }
            };

            // Act
            webSiteController.AddSite(webSiteViewModel);

            // Assert
            resourceDataAccess.Received(1).CreateWebSite(categoryId, "Testing", "https://www.test.com");
        }

    }
}
