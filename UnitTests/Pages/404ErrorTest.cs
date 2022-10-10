using ContosoCrafts.WebSite.Pages;
using NUnit.Framework;

namespace UnitTests.Pages
{

    /// <summary>
    /// Unit testing for the 404 error page
    /// </summary>
    public class _404ErrorTest
    {

        #region TestSetup
        //declare variables
        public static _404ErrorModel pageModel;

        /// <summary>
        /// initialize test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new _404ErrorModel();

        }

        #endregion TestSetup


        /// <summary>
        /// OnGet unit test for the 404Error Page
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Null_Should_Return_Void()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

        }

    }

}