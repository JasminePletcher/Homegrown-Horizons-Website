using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models.ENUM;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Setting the controller for the community gallery page 
    /// </summary>
    public class CommunityGalleryController : Controller
    {
        // Creating a JsonFilePlantService variable 
        public JsonFilePlantService CommunityBoardGalleryService { get; }

        // Declaring the UserType
        private UserType userType = UserType.USER;

        /// <summary>
        ///  This function set the controller for the plant service from the
        /// </summary>
        /// <param name="communityBoardGalleryService"></param>
        public CommunityGalleryController(JsonFilePlantService communityBoardGalleryService)
        {

            CommunityBoardGalleryService = communityBoardGalleryService;

        }

        [HttpGet]
        /// <summary>
        ///  This function will return the GetGallery function from the
        /// </summary>
        /// <returns>all plants by User</returns>
        public IEnumerable<PlantModel> Get()
        {

            return CommunityBoardGalleryService.GetAllData(userType);

        }

    }

}