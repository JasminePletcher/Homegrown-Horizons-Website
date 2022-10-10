using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTests.Pages
{
    /// <summary>
    /// unit test for the TeamInfo page
    /// </summary>
    class TeamInfo
    {
        // declare variables
        #region TestSetup
        public static TeamInfoModel pageModel;


        /// <summary>
        /// initialize the logger for the QnA model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            //Creating a mock of ILogger to write to
            var MockLoggerDirect = Mock.Of<ILogger<TeamInfoModel>>();

            pageModel = new TeamInfoModel(MockLoggerDirect)
            {

                PageContext = TestHelper.PageContext,

                TempData = TestHelper.TempData,

            };

        }

        #endregion TestSetup


        /// <summary>
        /// Test that onGet() is returning the Request ID
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {

            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

        }

        #endregion

    }

}