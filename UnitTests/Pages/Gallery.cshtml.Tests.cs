using ContosoCrafts.WebSite.Pages;
using System.Linq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Pages.Gallery
{
    /// <summary>
    /// Unit test for the Gallery 
    /// </summary>
    public class GalleryTests
    {
        //declare variables
        #region TestSetup
        public static GalleryModel pageModel;

        /// <summary>
        /// initialize the loggers and the plant service 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            //creating a mock of ILogger to write to
            var MockLoggerDirect = Mock.Of<ILogger<GalleryModel>>();
            
            pageModel = new GalleryModel(MockLoggerDirect, TestHelper.PlantService)
            {

            };

        }

        #endregion TestSetup

        /// <summary>
        /// Test on Get to return the plants made by the user 
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_All_Data_Made_By_User()
        {

            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, pageModel.Galleries.ToList().Any()); 
          
        }

        #endregion OnGet

    }

}