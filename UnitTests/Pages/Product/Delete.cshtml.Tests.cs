namespace UnitTests.Pages.Product
{
    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Pages.Product;
    using Microsoft.AspNetCore.Mvc;

    using NUnit.Framework;

    /// <summary>
    /// This class holds the tests for the Delete.cshtml.Tests.cs.
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup

        // Data field to hold page model specific to the Delete function
        public static DeleteModel pageModel;

        /// <summary>
        /// Setup test prior to execution.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test a valid result for OnGet method
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("sailorhg-kit");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Cleveland High School", pageModel.Product.SchoolName);
        }
        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// Test a valid result for OnPost method
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "selinazawacki-moon",
                SchoolName = "schoolname",
                SchoolAddress = "schooladdress",
                Url = "url",
                Image = "image"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        /// <summary>
        /// Test an invalid result for OnPost method
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "bogus",
                SchoolName = "bogus",
                SchoolAddress = "bogus",
                Url = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            _ = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}
