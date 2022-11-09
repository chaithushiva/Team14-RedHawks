namespace UnitTests.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using Bunit.Extensions;

    using ContosoCrafts.WebSite.Models;

    using NUnit.Framework;

    /// <summary>
    /// This class holds the tests for the main JsonFileProductService class.
    /// </summary>
    public class JsonFileProductServiceTests
    {

        #region TestSetup


        /// <summary>
        /// Initialize tests for JsonFileProductService class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup


        #region GetAllData

        /// <summary>
        /// Test of invalid state for GetAllData method
        /// </summary>
        [Test]
        public void GetAllData_Invalid_Does_Not_Return_Null_Or_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.GetAllData();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }

        /// <summary>
        /// Test for valid result of GetAllData method
        /// </summary>
        [Test]
        public void GetAllData_Valid_Returns_Contents_Of_Json_File_Should_Return_True()
        {
            // Arrange

            // read JSON file directly and convert to a string for comparison
            var jsonFileReader = File.OpenText("..\\..\\..\\..\\src\\wwwroot\\data\\products.json");

            IEnumerable<ProductModel> expected = JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            // Act
            var result = TestHelper.ProductService.GetAllData();

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        #endregion GetAllData

        #region AddRating
        /// <summary>
        /// Testing invalid null input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid empty string input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Data_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("Does not exist", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid megatove rating value for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Negative_Rating_Should_Return_False()
        {
            // Arrange
            var productID = TestHelper.ProductService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ProductService.AddRating(productID, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid, too high rating value for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Too_High_Rating_Should_Return_False()
        {
            // Arrange
            var productID = TestHelper.ProductService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ProductService.AddRating(productID, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing for creation of ratings array when a first rating is provided to AddRating method
        /// </summary>
        [Test]
        public void AddRating_Valid_Create_Data_Ratings_Array_Should_Return_True()
        {
            // Arrange
            // create a ProductModel with no ratings
            var data = TestHelper.ProductService.CreateData();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 4);

            // Assert
            Assert.AreEqual(true, result);

        }

        /// <summary>
        /// Testing typical, valid usage of AddRating method
        /// </summary>
        [Test]
        public void AddRating_Valid_product_Rating_5_Should_Return_True()
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
        #endregion AddRating

        #region CreateData

        /// <summary>
        /// Testing typical, valid usage of CreateData method
        /// </summary>
        [Test]
        public void CreateData_Valid_Last_Value_Matches_Created_Values_Should_Return_True()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.CreateData();
            var last = TestHelper.ProductService.GetAllData().Last();

            // Assert
            Assert.AreEqual("Default schoolname", result.SchoolName);
            Assert.AreEqual("School Address", result.SchoolAddress);
            Assert.AreEqual("School URL", result.Url);
            Assert.AreEqual("No image specified", result.Image);
            Assert.AreEqual(result.Id, last.Id);
        }
        #endregion CreateData

        #region UpdateData

        /// <summary>
        /// Testing typical, valid usage of UpdateData method
        /// </summary>
        [Test]
        public void UpdateData_Valid_Updated_Value_Matches_Should_Return_True()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var data2 = data;
            data2.SchoolName = "Test";

            // Act
            var result = TestHelper.ProductService.UpdateData(data2);

            // Reset
            _ = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(data2.SchoolName, result.SchoolName);
        }
        #endregion UpdateData
    }
}
