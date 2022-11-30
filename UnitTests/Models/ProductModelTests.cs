using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTests.Models
{

    /// <summary>
    /// Test class for ProductModel
    /// </summary>
    public class ProductModelTests
    {

        /// <summary>
        /// Method to test valid input of an product
        /// </summary>
        [Test]
        public void ToString_Valid_Null_ID_Should_Return_True()
        {

            // Arrange
            var data = TestHelper.ProductService.GetAllData().First(x => x.Id == "jenlooper-cactus");

            // Act
            var result = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(data.ToString(), result.ToString());

        }
    }
}