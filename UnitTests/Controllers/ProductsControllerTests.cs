﻿namespace UnitTests.Components
{
    using System.Linq;
    using Bunit;
    using ContosoCrafts.WebSite.Components;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.Extensions.DependencyInjection;

    using NUnit.Framework;


    /// <summary>
    /// Article list test set.
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup
        /// <summary>
        /// Initialize the test set.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        /// <summary>
        /// Test for returning list of articles. 
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            _ = Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Seattle Public School");
        }

        /// <summary>
        /// Unit test to validate Select Product click
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_jenlooper_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_jenlooper-cactus";
            var page = RenderComponent<ArticleList>();

            // Find More Info button specific to id
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Store markup for Assert statement
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("2445 3rd Ave. S, Seattle, WA 98134"));
        }

        /// <summary>
        /// Unit test for GetCurrentRatings method when no ratings exist
        /// </summary>
        [Test]
        public void GetCurrentRatings_Valid_Null_ProductRatings_Should_Return_Zeros()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_kate-lightshow";
            var page = RenderComponent<ArticleList>();

            // Find More Info button specific to id
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Store markup for Assert statement
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Eastside International School"));
        }

        /// <summary>
        /// Unit test for GetCurrentRating with multiple votes
        /// </summary>
        [Test]
        public void GetCurrentRatings_Valid_More_Than_One_Rating_Should_Return_True()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_jenlooper-cactus";
            var page = RenderComponent<ProductList>();

            // Find More Info button specific to id
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Store markup for Assert statement
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Votes"));

        }

        /// <summary>
        /// Unit test for GetCurrentRating with a single vote
        /// </summary>
        [Test]
        public void GetCurrentRatings_Valid_Single_Rating_Should_Return_True()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_sailorhg-corsage";
            var page = RenderComponent<ProductList>();

            // Find More Info button specific to id
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Store markup for Assert statement
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("1 Vote"));

        }
    }
}
