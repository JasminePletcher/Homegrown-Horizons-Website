using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Plants;

namespace UnitTests.Pages.Plants
{
    /// <summary>
    /// Unit test for index
    /// </summary>
    class IndexTests
    {
        #region TestSetup
        // Creating the PageContext variable 
        public static PageContext pageContext;

        // Creating the IndexModel variable 
        public static IndexModel pageModel;

        /// <summary>
        /// set up constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new IndexModel(TestHelper.PlantService)
            {

            };

        }

        #endregion TestSetup

        /// <summary>
        ///  valid products should return products
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, pageModel.Plants.ToList().Any());

        }

        #endregion OnGet

    }

}