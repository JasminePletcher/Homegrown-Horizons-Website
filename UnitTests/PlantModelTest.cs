using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests
{
    /// <summary>
    /// Unit test for the PlantModel in the Model folder
    /// </summary>
    public class PlantModelTest
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
            var test = new PlantModel
            {

                UserType = ContosoCrafts.WebSite.Models.ENUM.UserType.ADMIN,

                Id = "testin",

                Title = "testing title",

                Image = "image",

                PlantCategory = null,

                Description = "description",

                Wikilink = "wikilink"


            };

            var testingstring = "{\"UserType\":1,\"Id\":\"testin\",\"Title\":\"testing title\",\"Image\":\"image\",\"PlantCategory\":null,\"Description\":\"description\",\"WikiLink\":\"wikilink\"}";

            // Act

            // Assert
            Assert.AreEqual(test.ToString(), testingstring);

        }

        #endregion

    }

}