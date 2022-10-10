using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;

namespace UnitTests
{
    /// <summary>
    /// Helper to hold the web start settings
    ///
    /// HttpClient
    /// 
    /// Action Contect
    /// 
    /// The View Data and Teamp Data
    /// 
    /// The Product Service
    /// </summary>
    public static class TestHelper
    {
        // Delcaring the variable
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;

        // Delcaring the variable
        public static IUrlHelperFactory UrlHelperFactory;

        // Delcaring the variable
        public static DefaultHttpContext HttpContextDefault;

        // Delcaring the variable
        public static IWebHostEnvironment WebHostEnvironment;

        // Delcaring the variable
        public static ModelStateDictionary ModelState;

        // Delcaring the variable
        public static ActionContext ActionContext;

        // Delcaring the variable
        public static EmptyModelMetadataProvider ModelMetadataProvider;

        // Delcaring the variable
        public static ViewDataDictionary ViewData;

        // Delcaring the variable
        public static TempDataDictionary TempData;

        // Delcaring the variable
        public static PageContext PageContext;

        // Delcaring the variable
        public static JsonFilePlantService PlantService;

        // Delcaring the variable
        public static JsonFileQnAService QnAService;

        // Delcaring the variable
        public static JsonFilePlantTypeService PlantTypeService;


        /// <summary>
        /// Default Constructor
        /// </summary>
        static TestHelper()
        {

            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();

            MockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");

            MockWebHostEnvironment.Setup(m => m.WebRootPath).Returns(TestFixture.DataWebRootPath);

            MockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            HttpContextDefault = new DefaultHttpContext()
            {

                TraceIdentifier = "trace",

            };

            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            ModelState = new ModelStateDictionary();

            ActionContext = new ActionContext(HttpContextDefault, HttpContextDefault.GetRouteData(), new PageActionDescriptor(), ModelState);

            ModelMetadataProvider = new EmptyModelMetadataProvider();

            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);

            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            PageContext = new PageContext(ActionContext)
            {

                ViewData = ViewData,

                HttpContext = HttpContextDefault
            };

            PlantService = new JsonFilePlantService(MockWebHostEnvironment.Object);

            QnAService = new JsonFileQnAService(MockWebHostEnvironment.Object);

            PlantTypeService = new JsonFilePlantTypeService(MockWebHostEnvironment.Object);

            JsonFilePlantTypeService plantTypeService;

            JsonFileQnAService qnAService;

            JsonFilePlantService plantService;

            plantTypeService = new JsonFilePlantTypeService(TestHelper.MockWebHostEnvironment.Object);

            plantService = new JsonFilePlantService(TestHelper.MockWebHostEnvironment.Object);

            qnAService = new JsonFileQnAService(TestHelper.MockWebHostEnvironment.Object);

        }

    }

}