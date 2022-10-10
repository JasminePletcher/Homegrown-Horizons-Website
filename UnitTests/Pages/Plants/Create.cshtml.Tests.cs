using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Plants;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Models.ENUM;

namespace UnitTests.Pages.Plants
{

    /// <summary>
    /// Unit test for the create model
    /// </summary>
    public class CreateTests
    {
        //declare variables
        #region TestSetup
        public static CreateModel pageModel;

        /// <summary>
        /// initialize the create model and PlantService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new CreateModel(TestHelper.PlantService)
            {

            };

        }

        #endregion TestSetup

        #region Plant Set

        /// <summary>
        /// Testing public property set and should return new values
        /// </summary>
        [Test]
        public void Plant_Valid_Set_Should_Return_New_Values()
        {

            // Arrange
            var plant = new PlantModel()
            {

                Id = "1111",

                Title = "test"

            };

            // Act
            pageModel.Product = plant;

            // Assert
            Assert.AreEqual(plant, pageModel.Product);

        }

        /// <summary>
        /// Test on Post when error on page model
        /// </summary>
        #endregion

        #region OnPost
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {

            // Arrange
            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);

        }

        /// <summary>
        /// Test valid products and should save to JSON
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Save_Plant_Json()
        {
            // Arrange
            var plant = new PlantModel()
            {
                Id = "111111111",

                Title = "test"

            };

            //creating sample plant based off of Arrange
            var newData = TestHelper.PlantService.CreateData(plant);

            // Act
            pageModel.OnPost();

            //reset
            var getDataFromJson = TestHelper.PlantService.GetAllData().Where(x => x.Id == plant.Id).FirstOrDefault();

            // Assert
            Assert.NotNull(getDataFromJson);

            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(newData.Id, getDataFromJson.Id);

        }

        /// <summary>
        /// Test when valid code redirects to a page
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Redirect_To_Community_Gallery_Page()
        {

            // Arrange
            var code = UserType.USER.ToString();

            // Act

            var result = pageModel.OnPost(code) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("CommunityBoardGallery"));
            Assert.AreEqual("/CommunityBoardGallery", result.PageName);
        }

        #endregion


        #region OnGet
        /// <summary>
        /// test get for the create code
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Create_Code()
        {

            // Arrange
            var createCode = "Test";

            // Act
            pageModel.OnGet(createCode);

            //Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(createCode, pageModel.CreateCode);

        }

        #endregion

    }

}