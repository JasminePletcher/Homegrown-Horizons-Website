using ContosoCrafts.WebSite.Models.ENUM;
using NUnit.Framework;
using System.Linq;

namespace UnitTests.Services
{
    /// <summary>
    /// unit test for the JsonFileQnAService page
    /// </summary>
    class JsonFileQnAServiceTest
    {


        #region GetAllData
        /// <summary>
        /// Test that GetAllData with valid tabNum returns that tab 
        /// </summary>
        [Test]
        public void GetAllData_Returns_Single_Tab_If_Valid()
        {

            // Arrange

            // Act
            //result gets all questions with tab index 2
            var result = TestHelper.QnAService.GetAllData(TabNum.TAB2);

            //hardcoded IDs for tab 2
            int[] expectedId = new int[3] { 4, 5, 6 };

            for(int i=0; i<expectedId.Length; i++)
            {
                //expectedResult gets individual post
                var expectedResult = result.Where(x => x.Id == expectedId[i]);
                // Assert
                Assert.IsNotNull(expectedResult);
                Assert.AreEqual(TabNum.TAB2, expectedResult.ElementAt(0).TabNum);

            }
            Assert.AreEqual(3, result.Count());

        }

        #endregion GetAllData

    }

}