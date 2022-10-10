using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Controller
{
    /// <summary>
    /// unit test for QnAController 
    /// </summary>
    public class QnAControllerTest
    {

        #region TestSetup
        // Declaring the variable 
        public static QnAController controller;

        /// <summary>
        /// initialize the QnAController and QnAService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            controller = new QnAController(TestHelper.QnAService)
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
            Assert.AreEqual(true,controller.ModelState.IsValid);           
            
        }


        /// <summary>
        ///  valid should retrieve the JsonFileService
        /// </summary>
        [Test] 
        public void Controller_Valid_Should_Get_JsonFileService()
        {
            //arrange
            JsonFileQnAService results = new JsonFileQnAService(TestHelper.MockWebHostEnvironment.Object);

            //act
            var control = new QnAController(results);

            //assert
            Assert.AreEqual(results, control.QService); 
        }
        #endregion TestInitialization

    }
    
}