using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Models.ENUM;
using NUnit.Framework; 
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Controller
{
    /// <summary>
    /// unit test for controller
    /// </summary>
    class CommunityGalleryControllerTest
    {

        #region TestSetup
        // Delcaring the variable
        public static CommunityGalleryController controller;

        /// <summary>
        /// initialize the create model and PlantService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            controller = new CommunityGalleryController(TestHelper.PlantService)
            {

            };

        }

        #endregion TestSetup

        #region Controller get
        /// <summary>
        ///  valid products should return products
        /// </summary>
        [Test]
        public void Controller_Valid_Get_Should_Return_Values()
        {

            // Arrange
            IEnumerable<PlantModel> results;
            // Getting UserTypes to compare
            var userCompare = UserType.USER;

            // Act
            results = controller.Get();

            // Assert
            Assert.AreEqual(true,results.Any());

            Assert.AreEqual(true,!results.Select(x => x).Where(a => a.UserType != userCompare).Any());

        }

        #endregion

    }

}