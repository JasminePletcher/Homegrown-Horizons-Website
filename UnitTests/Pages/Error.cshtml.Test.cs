using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Diagnostics;

namespace UnitTests.Pages
{
    /// <summary>
    /// Error unit test
    /// </summary>
    class Error
    {
        #region TestSetup
        //declare variables
        public static ErrorModel pageModel;

        /// <summary>
        /// initialize test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            //creating a mock of ILogger to write to
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            pageModel = new ErrorModel(MockLoggerDirect)
            {

                PageContext = TestHelper.PageContext,

                TempData = TestHelper.TempData,

            };

        }

        #endregion TestSetup

        /// <summary>
        /// get request ID
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {

            // Arrange
            Activity activity = new Activity("activity");

            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(activity.Id, pageModel.RequestId);

        }

        /// <summary>
        /// returns stack trace if errored
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual("trace", pageModel.RequestId);

            Assert.AreEqual(true, pageModel.ShowRequestId);

        }

        #endregion OnGet

    }

}