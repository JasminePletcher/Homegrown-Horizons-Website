using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Models.ENUM;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services
{
    /// <summary>
    /// unit test for the JsonFilePlantService page
    /// </summary>
    class JsonFilePlantServiceTest
    {


        #region CreateData
        /// <summary>
        /// Test that createData with null plant should return null 
        /// </summary>
        [Test]
        public void CreateData_Invalid_Plant_Model_Should_Return_Invalid()
        {

            // Arrange

            // Act
            var result = TestHelper.PlantService.CreateData(null);

            // Assert
            Assert.AreEqual(null, result);

        }

        /// <summary>
        /// Test that Creating a plant model with create code 2 sets the Usertype to 2
        /// </summary>
        [Test]
        public void CreateData_Valid_Plant_Model_Create_Code_ID_Should_Be_Usertype_2()
        {

            // Arrange
            var Plant = new PlantModel
            {

                UserType = UserType.USER,

                Id = "1000",

                Title = "testing title",

                Image = "image",

                Description = "description",

                Wikilink = "wikilink"

            };

            // Act
            var result = TestHelper.PlantService.CreateData(Plant,UserType.USER.ToString());

            // Assert
            Assert.AreEqual(UserType.USER, result.UserType);

        }

        #endregion CreateData


        #region DeleteData
        /// <summary>
        /// Test that DeleteData should return a list of products sans deleted product if 
        /// valid product is provided to delete 
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products_After_Deletion()
        {

            // Arrange
           var Plant = new PlantModel
            {

                UserType = UserType.ADMIN,

                Id = "1000",

                Title = "testing title",

                Image = "image",

                Description = "description",

                Wikilink = "wikilink"

            };


            // Act
            var result = TestHelper.PlantService.CreateData(Plant);

            var deleted = TestHelper.PlantService.DeleteData(Plant.Id);

            // Assert
            Assert.AreEqual(true, TestHelper.ModelState.IsValid);

            // Confirm the item is deleted
            Assert.AreEqual(deleted.Id,Plant.Id);

            Assert.AreEqual(result.Id, Plant.Id);

            // Is there any results that match the deleted plants idea -- should return false
            Assert.AreEqual(true,!TestHelper.PlantService.GetAllData().Where(x => x.Id == deleted.Id).Any());

        }

        #endregion DeleteData

    }

}