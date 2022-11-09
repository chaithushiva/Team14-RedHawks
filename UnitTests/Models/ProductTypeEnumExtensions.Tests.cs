using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    /// <summary>
    /// Test class for ArticleTypeEnumExtensions
    /// </summary>
    public class ProductTypeEnumExtensions
    {

        [Test]
        public void ProductTyepEnum_Valid_Null_ID_Should_Return_True()
        {
            // Arrange

            // Act
            var result1 = ProductTypeEnum.Undefined.DisplayName();
            var result2 = ProductTypeEnum.Laptops.DisplayName();
            var result3 = ProductTypeEnum.Projectors.DisplayName();
            var result4 = ProductTypeEnum.Desks.DisplayName();
            var result5 = ProductTypeEnum.SmartBoards.DisplayName();
            var result6 = ProductTypeEnum.NoteBooks.DisplayName();

            // Assert
            Assert.AreEqual("", result1);
            Assert.AreEqual("Electronic Items", result2);
            Assert.AreEqual("Electronic Items", result3);
            Assert.AreEqual("Stationery Items", result4);
            Assert.AreEqual("Electronic Items", result5);
            Assert.AreEqual("Stationery Items", result6);

        }
    }
}