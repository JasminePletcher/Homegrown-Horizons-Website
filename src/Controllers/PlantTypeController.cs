using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Setting the controller for the PlantType
    /// </summary>
    public class PlantTypeController: Controller
    {

        // Declaring a variable for the JsonFilePlantTypeService
        public JsonFilePlantTypeService PTService { get; }


        /// <summary>
        /// This function sets the controller for the PlantType service 
        /// </summary>
        /// <param name="service"></param>
        public PlantTypeController(JsonFilePlantTypeService service)
        {

            PTService = service;

        }

    }

}