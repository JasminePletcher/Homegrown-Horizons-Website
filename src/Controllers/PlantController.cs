using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models.ENUM;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    ///<summary>
    /// This class is for setting the controller for the plant gallery
    ///</summary> 
    public class PlantController : ControllerBase
    {
        // Delcaring a variable for the JsonFilePlantService
        public JsonFilePlantService PlantService { get; }

        // Delcaring the userType variable 
        private UserType userType = UserType.ADMIN;
        

        /// <summary>
        /// This function set the controller for the plant service from the
        /// </summary>
        /// <param name="plantService"></param>
        public PlantController(JsonFilePlantService plantService)
        {

            PlantService = plantService;

        }

        [HttpGet]
        /// <summary>
        /// This function will returns all plants by ADMIN
        /// </summary>
        /// <returns>all plants by ADMIN</returns>
        public IEnumerable<PlantModel> Get()
        {

            return PlantService.GetAllData(userType);

        }

    }

}