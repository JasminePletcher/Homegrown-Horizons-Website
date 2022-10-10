using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{

    /// <summary>
    /// Unit test for CommmunityGalleryListTest.cs 
    /// </summary>
    public class CommunityGalleryListTest : BunitTestContext
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
        /// The community gallery list should return the content 
        /// </summary>
        [Test]
        public void CommunityGalleryList_Valid_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFilePlantService>(TestHelper.PlantService);

            // Act
            var page = RenderComponent<CommunityGalleryList>();

            // Get the cards returned
            var result = page.Markup;

            Assert.AreEqual(true, result.Contains("Snake Plant"));
        }

        /// <summary>
        /// SelectProduct Valid ID 17 Snake Plant Should Return Content
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_17_Snake_Plant_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFilePlantService>(TestHelper.PlantService);

            // id of button to test
            var id = "MoreInfoButton_17";

            // Render the page
            var page = RenderComponent<CommunityGalleryList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find matching button by Id
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("mother in law"));
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
            var id = "MoreInfoButton_17";

            var selectId = "category";

            // Render the page
            var page = RenderComponent<CommunityGalleryList>();

            // get dropdown
            var findSelect = page.FindAll("select").First(m => m.OuterHtml.Contains(selectId));

            // select option
            findSelect.Change("2");


            // Find the Buttons (more info)
            var buttonList = page.FindAll("button");

            // Find matching button by Id
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("mother in law"));

        }
    }

}