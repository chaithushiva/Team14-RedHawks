namespace UnitTests.Components
{
    using ContosoCrafts.WebSite.Components;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.Extensions.DependencyInjection;

    using NUnit.Framework;


    /// <summary>
    /// Product list test set.
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
        /// Test for returning list of products. 
        /// </summary>
        [Test]
        public void Product_Default_Should_Return_Content()
        {
            // Arrange
            _ = Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Seattle Public School"));
        }
    }
}