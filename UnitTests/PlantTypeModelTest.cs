using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Models.ENUM;
using NUnit.Framework;

namespace UnitTests
{

    /// <summary>
    /// Unit test for the PlantModelModel in the Model folder
    /// </summary>
    public class PlantTypeModelTest
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
        /// Test valid ToString method returns information about the tplant type
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_String()
        {

            // Arrange
            var test = new PlantTypeModel
            {

                ID = 1,

                Type = "Succulent", 

                Plant = "plant",

                Description= "answer",

                TabNum = TabNum.TAB2,

                Source = "source",

                Image = "image",

            };

            var testingstring = "{\"ID\":1,\"TabNum\":2,\"Type\":\"Succulent\",\"Description\":\"answer\",\"Plant\":\"plant\",\"Image\":\"image\",\"Source\":\"source\"}";

            // Act

            // Assert
            Assert.AreEqual(test.ToString(), testingstring);

        }

        #endregion

    }

}