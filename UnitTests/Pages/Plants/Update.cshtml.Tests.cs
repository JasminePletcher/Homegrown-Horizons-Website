using ContosoCrafts.WebSite.Pages.Plants;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models.ENUM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace UnitTests.Pages.Plants
{
    /// <summary>
    /// Unit test for the Update in Plants folder from Pages 
    /// </summary>
    public class UpdateTests
    {

        //declare variables
        #region TestSetup
        public static UpdateModel pageModel;

        /// <summary>
        /// initialize the create model and PlantService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new UpdateModel(TestHelper.PlantService)
            {

                PageContext = TestHelper.PageContext,

            };


        }
        #endregion TestSetup

        #region Teardown
        /// <summary>
        /// Clear modelstate to avoid issues
        /// </summary>
        [TearDown]
        public void RunAfterEveryTest()
        {

            pageModel.ModelState.Clear();

        }
        #endregion Teardown

        /// <summary>
        /// Test on Get to return the plants 
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Plants()
        {

            // Arrange
            pageModel.Plant = new PlantModel
            {

                UserType = UserType.ADMIN,

                Id = "testin",

                Title = "testing title",

                Image = "image",

                Description = "description",

                Wikilink = "wikilink"

            };

            //creating sample plant based off of Arrange
            var result = pageModel.ProductService.CreateData(pageModel.Plant); 

            // Act
            pageModel.OnGet(result.Id);

            //Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(result.Id, pageModel.Plant.Id);

        }

        /// <summary>
        /// Test null plant object to return index page
        /// </summary>
        [Test]
        public void OnGet_Invalid_Should_Redirect_To_Index_Page()
        {

            // Arrange
            var testID = "-99999999"; //should be null

            // Act
            IActionResult result = pageModel.OnGet(testID);

            // Assert
            RedirectToPageResult redirect = result as RedirectToPageResult; 
            Assert.AreEqual("./Index", redirect.PageName);

        }


        #endregion OnGet


        #region OnPost

        /// <summary>
        /// test user type = 2 to return to the community gallery
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Redirect_To_Community_Gallery_Page()
        {
            var queryString = $"?goto={UserType.USER}";
            TestHelper.PageContext.HttpContext.Request.QueryString = new QueryString(queryString);
            var user = UserType.USER;
            var plant = pageModel.ProductService.GetAllData(user).FirstOrDefault();

            // Arrange
            plant.Description = "test";
            pageModel.Plant = plant;

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("CommunityBoardGallery"));
            Assert.AreEqual("/CommunityBoardGallery", result.PageName);
        }

        /// <summary>
        /// Test on Post when should return the plants 
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Plants()
        {

            // Arrange
            TestHelper.PageContext.HttpContext.Request.QueryString = new QueryString("?");
            pageModel.Plant = new PlantModel
            {

                UserType = UserType.ADMIN,

                Id = "1",

                Title = "title",

                Image = "image",

                Description = "description",

                Wikilink = "wikilink"


            };

            // Act

            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, result.PageName.Contains("Index")); 

        }

        /// <summary>
        /// Test on Post when should it is not valid return the page
        /// </summary>
        [Test]
        public void OnPost_Invalid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);

        }

        #endregion OnPost

    }

}