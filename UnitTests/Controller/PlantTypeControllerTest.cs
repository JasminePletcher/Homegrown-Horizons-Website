using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Controller
{

    /// <summary>
    /// unit test for PlantTypeController
    /// </summary>
    public class PlantTypeControllerTest
    {

        #region TestSetup
        // Declaring the variable 
        public static PlantTypeController controller;

        /// <summary>
        /// initialize the QnAController and QnAService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            controller = new PlantTypeController(TestHelper.PlantTypeService)
            {

            };

        }

        #endregion TestSetup

        #region TestInitialization
        /// <summary>
        ///  valid return valid state of the model
        /// </summary>
        [Test]
        public void Controller_Valid_Should_Return_Valid_State()
        {
            //assert
            Assert.AreEqual(true, controller.ModelState.IsValid);

        }

        /// <summary>
        ///  valid should retrieve the JsonFileService
        /// </summary>
        [Test]
        public void Controller_Valid_Should_Get_JsonFileService()
        {
            //arrange
            JsonFilePlantTypeService results = new JsonFilePlantTypeService(TestHelper.MockWebHostEnvironment.Object);

            //act
            var control = new PlantTypeController(results);

            //assert
            Assert.AreEqual(results, control.PTService);
        }
        #endregion TestInitialization


    }

}