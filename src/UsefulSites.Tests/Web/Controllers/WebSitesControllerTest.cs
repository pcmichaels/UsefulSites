﻿using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.Data;
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
            var resourceCategoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess, resourceCategoryDataAccess);

            // Act
            var result = webSiteController.AddSite();

            // Assert
            ViewResult view = Assert.IsType<ViewResult>(result);
            WebSiteAddViewModel viewModel = Assert.IsType<WebSiteAddViewModel>(view.Model);
        }

        [Fact]
        public void CallAddSite_CategoriesLoaded()
        {

            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            var resourceCategoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();
            resourceCategoryDataAccess.GetAllCategories().Returns(new List<ResourceCategory>()
            {
                new ResourceCategory() {Id = 1, Name = "test"},
                new ResourceCategory() {Id = 2, Name = "test2"},
            });

            var webSiteController = new WebSitesController(
                resourceDataAccess, resourceCategoryDataAccess);

            // Act
            var result = webSiteController.AddSite();

            // Assert
            ViewResult view = Assert.IsType<ViewResult>(result);
            WebSiteAddViewModel viewModel = Assert.IsType<WebSiteAddViewModel>(view.Model);
            Assert.Equal(2, viewModel.Categories.Count());
        }

        [Fact]
        public void CallAddSite_Post()
        {

            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            var resourceCategoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess, resourceCategoryDataAccess);

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

        [Fact]
        public void GetSite_SingleEntry()
        {
            // Arrange
            int siteId = 1;

            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            resourceDataAccess.GetWebSite(siteId).Returns(new Resource() { Id = 1, Name = "test" });

            var resourceCategoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess, resourceCategoryDataAccess);

            // Act
            var result = webSiteController.GetSite(1);

            // Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            ResourceModel resource = Assert.IsType<ResourceModel>(viewResult.Model);            
            Assert.NotNull(resource);
            Assert.Equal("test", resource.Name);
            resourceDataAccess.Received(1).GetWebSite(siteId);            
        }

        [Fact]
        public void GetSite_NoData()
        {
            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            var resourceCategoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess, resourceCategoryDataAccess);

            int siteId = 1;

            // Act
            webSiteController.GetSite(1);

            // Assert
            resourceDataAccess.Received(1).GetWebSite(siteId);
        }

        [Fact]
        public void AddSite_NoCategory_RedirectError()
        {
            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            var resourceCategoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess, resourceCategoryDataAccess);

            var webSiteAddViewModel = new WebSiteAddViewModel()
            {
                Category = null,
                Description = "test",
                Url = "aa.test.com"
            };

            // Act
            var result = webSiteController.AddSite(webSiteAddViewModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("AddSite", redirectToActionResult.ActionName);
            
        }

        [Fact]
        public void AddSite_Success_RedirectGetSite()
        {
            // Arrange
            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            var resourceCategoryDataAccess = Substitute.For<IResourceCategoryDataAccess>();

            var webSiteController = new WebSitesController(
                resourceDataAccess, resourceCategoryDataAccess);

            var webSiteAddViewModel = new WebSiteAddViewModel()
            {
                Category = new CategoryModel(),
                Description = "test",
                Url = "aa.test.com"
            };

            // Act
            var result = webSiteController.AddSite(webSiteAddViewModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("GetSite", redirectToActionResult.ActionName);
        }

    }
}
