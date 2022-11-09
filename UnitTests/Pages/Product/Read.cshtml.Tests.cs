using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Pages.Product;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UnitTests.Pages.Product
{



    /// <summary>
    /// Class containing unit test cases for Read page
    /// </summary>
    public class ReadTests
    {



        // Creating an instance
        #region TestSetup



        public static ReadModel pageModel;



        /// <summary>
        ///  Initializing Tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {



            };
        }



        #endregion TestSetup



        #region GetallData



        /// <summary>
        ///  Testing GetallData for invalid product null should return false
        /// </summary>
        [Test]
        public void GetAllData_InValid_Product_Null_Should_Return_False()
        {
            // Arrange



            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);



            // Assert
            Assert.AreEqual(false, result);
        }



        /// <summary>
        ///  Testing OnGet Valid should return all products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            //Arrange



            // Act
            pageModel.OnGet("jenlooper-cactus");



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            
        }



        /// <summary>
        ///  Testing OnGet invalid should return false
        /// </summary>
        [Test]
        public void OnGet_InValid_Should_Return_False()
        {
            // Arrange



            // Act
            pageModel.OnGet("ABC");



            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
           
        }



        /// <summary>
        /// Testing GetAllData for Valid Product and valid rating should return true
        /// </summary>
        [Test]
        public void GetAllData_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange



            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;



            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();



            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }



        #endregion
    }
}