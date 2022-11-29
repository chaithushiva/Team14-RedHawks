namespace UnitTests.Pages
{
    using ContosoCrafts.WebSite.Pages;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class for the Privacy page
    /// </summary>
    public class PrivacyTests
    {
        #region TestSetup

        // page model for class
        public static PrivacyModel pageModel;

        /// <summary>
        /// Setup the test prior to execution
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();

            pageModel = new PrivacyModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }
        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test OnGet method for valid result
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {

            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}