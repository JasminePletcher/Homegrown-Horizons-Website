using ContosoCrafts.WebSite.Models.ENUM;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services
{

    /// <summary>
    /// unit test for the JsonFilePlantTypeService page
    /// </summary>
    class JsonFilePlantTypeServiceTest
    {

        #region GetAllData
        /// <summary>
        /// Test that GetAllData with valid tabNum returns that tab 
        /// </summary>
        [Test]
        public void GetAllData_Returns_Single_Tab_If_Valid()
        {

            // Arrange
            var tabNum = TabNum.TAB2;

            // Act
            //result gets all questions with tab index 2
            var result = TestHelper.PlantTypeService.GetAllData(tabNum);

            //Assert
            Assert.AreEqual(tabNum, result.FirstOrDefault().TabNum);
            Assert.False(result.Where(x => !x.TabNum.Equals(tabNum)).Any());
        }

        #endregion GetAllData

    }

}