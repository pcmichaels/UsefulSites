using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using UsefulSites.DataAccess.Api;
using UsefulSites.Web.Controllers;
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
    }
}
