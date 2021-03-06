﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using UsefulSites.DataAccess.Api;
using UsefulSites.DataAccess.DataContext;

namespace UsefulSites.Tools.PopulateTestData
{
    class Program
    {
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("This tool will clear and then repopulate the data in the database.");
            Console.WriteLine("Press Y to continue, or any other key to cancel.");

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key != ConsoleKey.Y) return;

            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));

            var options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                     .EnableSensitiveDataLogging()
                     .Options;
            ApplicationDbContext applicationDbContext = new ApplicationDbContext(options);

            var dataAccess = new ResourceDataAccess(applicationDbContext);
            ResourceCategoryDataAccess resourceCategoryDataAccess = new ResourceCategoryDataAccess(applicationDbContext);

            int[] categories = GetCategories(resourceCategoryDataAccess);

            for (int i = 1; i <= 100; i++)
            {
                int category = _random.Next(categories.Length);
                string webSiteAddress = $"www.{CreateWebAddress()}.{GetExtension()}";

                dataAccess.CreateWebSite(categories[category], $"Test web site {i}", webSiteAddress);
            }
        }

        private static int[] GetCategories(ResourceCategoryDataAccess resourceCategoryDataAccess)
        {
            int[] categories = new int[3];
            var resourceCategories = resourceCategoryDataAccess.GetAllCategories();
            if (resourceCategories.Any())
            {
                categories[0] = resourceCategories.First().Id;
                categories[1] = resourceCategories.Skip(1).First().Id;
                categories[2] = resourceCategories.Skip(2).First().Id;
            }
            else
            {
                categories[0] = resourceCategoryDataAccess.AddCategory("Software Development");
                categories[1] = resourceCategoryDataAccess.AddCategory("Travel");
                categories[2] = resourceCategoryDataAccess.AddCategory("Gambling");
            }
            return categories;
        }

        private static string CreateWebAddress()
        {
            int length = _random.Next(20) + 5;
            string returnString = string.Empty;
            for (int i = 1; i < length; i++)
            {
                returnString += (char)(_random.Next(26) + 97);
            }

            return returnString;
        }

        private static string GetExtension()
        {
            string extension;
            switch (_random.Next(4))
            {
                case 0:
                    extension = "com";
                    break;
                case 1:
                    extension = "co.uk";
                    break;
                case 2:
                    extension = "org";
                    break;
                default:
                    extension = "uk";
                    break;                
            }
            return extension;
        }
    }
}
