using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models.ENUM;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Controller
{

    /// <summary>
    /// unit test for plant controller
    /// </summary>
    class PlantControllerTest
    {

        #region TestSetup
        // Declaring the variable 
        public static PlantController controller;

        /// <summary>
        /// initialize the create model and PlantService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            controller = new PlantController(TestHelper.PlantService)
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

            //Getting UserTypes to compare
            var userCompare = UserType.ADMIN;

            // Act
            results = controller.Get();

            // Assert
            Assert.AreEqual(true,results.Any());

            Assert.AreEqual(true,!results.Select(x => x).Where(a => a.UserType != userCompare).Any());

        }

        #endregion
    }

}