using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{

    /// <summary>
    /// Unit test for PlantList
    /// </summary>
    public class PlantListTest : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// initialize the empty test function 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }
        #endregion TestSetup

        /// <summary>
        /// The plant list should return the content 
        /// </summary>
        [Test]
        public void PlantList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFilePlantService>(TestHelper.PlantService);

            // Act
            var page = RenderComponent<PlantList>();

            // Get the cards returned
            var result = page.Markup;

            Assert.AreEqual(true, result.Contains("Jade Bonsai"));
        }

        /// <summary>
        /// SelectProduct_Valid_ID_2_Jade_Bonsai_Should_Return_Content
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_2_Jade_Bonsai_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFilePlantService>(TestHelper.PlantService);

            // id of button to test
            var id = "MoreInfoButton_2";

            // Render the page
            var page = RenderComponent<PlantList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find matching button by Id
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            //Assert
            Assert.AreEqual(true, pageMarkup.Contains("Water: Let plant dry out between watering. Water until soil is moist"));
        }

        ///<summary>
        ///Selecting a category should return plant content
        /// </summary>
        [Test]
        public void Select_Plant_Category_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFilePlantService>(TestHelper.PlantService);

            // id of button to test
            var id = "MoreInfoButton_2";

            // name of select dropdwon
            var selectId = "category";

            // render the page
            var page = RenderComponent<PlantList>();

            // get dropdown
            var findSelect = page.FindAll("select").First(m => m.OuterHtml.Contains(selectId));

            //Select first option
            findSelect.Change("1");

            // find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // find matching button by Id
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Water: Let plant dry out between watering. Water until soil is moist"));

        }

    }

}