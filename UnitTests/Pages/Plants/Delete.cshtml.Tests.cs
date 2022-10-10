using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Plants;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Plants
{
    /// <summary>
    /// unit test for delete
    /// </summary>
    public class DeleteTests
    {
        //declare variable
        #region TestSetup
        public static DeleteModel pageModel;

        /// <summary>
        /// sets up the test helper service
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new DeleteModel(TestHelper.PlantService)
            {

            };

        }

        #endregion TestSetup

        /// <summary>
        /// get valid products should return products
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {

            // Arrange

            // Act
            pageModel.OnGet("4");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual("Monstera", pageModel.Plant.Title);

        }

        /// <summary>
        ///  invalid deletion of a product should result in taking user back to 
        ///  index page
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_NotValid_Should_Return_Index_Page()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("BogusPage") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }

        #endregion OnGet

        /// <summary>
        ///  valid products should return products
        /// </summary>
        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {

            // Arrange
            PlantModel newModel = new PlantModel();

            // First Create the product to delete
            pageModel.Plant = TestHelper.PlantService.CreateData(newModel);

            pageModel.Plant.Title = "Example to Delete";

            TestHelper.PlantService.UpdateData(pageModel.Plant);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.PlantService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Plant.Id)));

        }

        /// <summary>
        ///  invalid products should return products
        /// </summary>
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

        #endregion OnPost

    }

}