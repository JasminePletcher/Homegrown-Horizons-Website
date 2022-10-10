using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTests.Pages
{
    /// <summary>
    /// Unit tests for the Index page (default home page)
    /// </summary>
    class Index
    {

        #region TestSetup

        // declare variables
        public static IndexModel pageModel;

        /// <summary>
        /// initialize the loggers and the plant service 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            //creating a mock of ILogger to write to
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(MockLoggerDirect, TestHelper.PlantService)
            {

            };

        }

        #endregion TestSetup

        /// <summary>
        /// Test that onGet() is returning nothing at the moment. 
        /// -- OnGet() it is not returning any plants to the index homepage for our website.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.IsEmpty(pageModel.ModelState);

        }

        #endregion OnGet

    }

}