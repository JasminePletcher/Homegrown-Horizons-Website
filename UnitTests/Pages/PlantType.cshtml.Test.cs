using ContosoCrafts.WebSite.Pages;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Pages
{

    /// <summary>
    /// unit test for the Plant Type page
    /// </summary>
    class PlantType
    {

        // declare variables
        #region TestSetup
        public static PlantTypeModel pageModel;

        /// <summary>
        /// initialize the logger for the PlantType model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new PlantTypeModel(TestHelper.PlantTypeService)
            {

            };

        }

        #endregion TestSetup

        /// <summary>
        ///  valid planttypes should return plant types
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Plant_Types()
        {

            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, pageModel.PTList.ToList().Any());

        }

        #endregion

    }

}