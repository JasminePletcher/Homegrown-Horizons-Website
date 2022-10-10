using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Setting the controller for the QnA
    /// </summary>
    public class QnAController : Controller
    {
        // Delcaring a variable for the JsonFileQnAService
        public JsonFileQnAService QService { get; }

        /// <summary>
        /// This function set the controller for the QnA service from the
        /// </summary>
        /// <param name="service"></param>
        public QnAController(JsonFileQnAService service)
        {

            QService = service;

        }

    }

}