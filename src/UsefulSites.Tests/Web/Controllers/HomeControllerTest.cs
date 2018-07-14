using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using UsefulSites.DataAccess.Api;
using UsefulSites.Web.Controllers;
using UsefulSites.Web.ViewModels;
using Xunit;

namespace UsefulSites.Tests.Web.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void CallIndex_NoData()
        {

            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            var resourceTypeDataAccess = Substitute.For<IResourceTypeDataAccess>();
            var categoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();

            var homeController = new HomeController(
                resourceTypeDataAccess, resourceDataAccess,
                categoryDataAccess);

            // Act
            var result = homeController.Index();

            // Assert
            ViewResult view = Assert.IsType<ViewResult>(result);
            MainViewModel viewModel = Assert.IsType<MainViewModel>(view.Model);
            Assert.Empty(viewModel.Categories);
            Assert.Empty(viewModel.TopResources);
        }
    }
}
