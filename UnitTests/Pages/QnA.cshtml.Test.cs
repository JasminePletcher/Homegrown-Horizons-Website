using ContosoCrafts.WebSite.Pages;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Pages
{

    /// <summary>
    /// unit test for the Q n A page
    /// </summary>
    class QnA
    {

        // declare variables
        #region TestSetup
        public static QnAModel pageModel;


        /// <summary>
        /// initialize the logger for the QnA model
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            pageModel = new QnAModel(TestHelper.QnAService)
            {

            };

        }

        #endregion TestSetup

        /// <summary>
        ///  valid products should return products
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {

            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);

            Assert.AreEqual(true, pageModel.QnAList.ToList().Any());

        }

        #endregion

    }

}