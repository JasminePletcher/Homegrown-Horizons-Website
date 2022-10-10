using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Models.ENUM;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// Unit test for the QnAModel in the Model folder
    /// </summary>
    class QnAModelTest
    {
        #region TestSetup

        /// <summary>
        /// Initializing the test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        #region ToString
        /// <summary>
        /// Test on tostring when a string should be return 
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_String()
        {

            // Arrange
            var test = new QnAModel
            {

                Id = 1,

                Question = "question",

                Answer = "answer",

                TabNum = TabNum.TAB2,

                Source = "source",

                Image = "image",

            };

            var testingstring = "{\"Id\":1,\"Question\":\"question\",\"Answer\":\"answer\",\"TabNum\":2,\"Source\":\"source\",\"Image\":\"image\"}";

            // Act

            // Assert
            Assert.AreEqual(test.ToString(), testingstring);

        }

        #endregion

    }

}