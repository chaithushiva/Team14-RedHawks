namespace UnitTests.Controllers
{
    using System.Linq;
    using ContosoCrafts.WebSite.Controllers;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the ProductController class.
    /// </summary>
    internal class ProductControllerTests
    {
        #region TestSetup

        // controller instance to test
        public static ProductsController controller;

        /// <summary>
        /// SetUp for the tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // Create a new controller instance
            controller = new ProductsController(TestHelper.ProductService);
        }

        #endregion TestSetup

        #region Get

        /// <summary>
        /// Test the API Get Http request method
        /// </summary>
        [Test]
        public void Get_Valid_Should_Returns_All_Product()
        {
            // Arrange
            var expected = TestHelper.ProductService.GetAllData().Count();

            // Act
            var actual = controller.Get().Count();

            // Assert
            Assert.AreEqual(true, controller.ModelState.IsValid);
            Assert.AreEqual(expected, actual);
        }

        #endregion Get
    }
}