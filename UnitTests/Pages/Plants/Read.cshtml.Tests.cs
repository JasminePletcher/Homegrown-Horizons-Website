using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Plants;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models.ENUM;

namespace UnitTests.Pages.Plants
{
    /// <summary>
    /// Tests the functionality of the Read pages
    /// </summary>
    class ReadTests
    {
        //declare variables
        #region TestSetup
        public static ReadModel pageModel;

        /// <summary>
        /// constructor for model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new ReadModel(TestHelper.PlantService)
            {

            };

        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        ///  valid products should return products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Plants()
        {

            // Arrange
            pageModel.Plant = new PlantModel
            {
                UserType = UserType.ADMIN,

                Id = "testing",

                Title = "testing title",

                Image = "image",

                Description = "description",

                Wikilink = "wikilink"
            };

            //creating sample plant based off of Arrange
            var result = pageModel.PlantService.CreateData(pageModel.Plant);

            // Act
            pageModel.OnGet(result.Id);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(result.Id, pageModel.Plant.Id);

        }

        [Test]
        public void OnGet_InValid_Id_NotValid_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("NotValid") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }

        #endregion OnGet

    }

}