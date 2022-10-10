using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models.ENUM;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Manage the community board gallery page.
    /// </summary>
    public class CommunityBoardGalleryModel : PageModel
    {

        // Creating a logger varible 
        private readonly ILogger<PageModel> _logger;

        // Creating a userType variable 
        private UserType userType = UserType.USER;

        // Creating a service variable for JsonFilePlantService
        public JsonFilePlantService CommunityGalleryService { get; }

        // Creating an IEnumerable object of PlantModel 
        public IEnumerable<PlantModel> CommunityGalleries { get; private set; }

        /// <summary>
        /// Asking for a logger using the json file service for the Gallery
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="communityService"></param>
        public CommunityBoardGalleryModel(ILogger<PageModel> logger, JsonFilePlantService communityService)
        {

            _logger = logger;

            CommunityGalleryService = communityService;

        }

        /// <summary>
        /// This function shall call the GetCommunityGallery function from the
        /// retrieves all data made by USER
        /// </summary>
        public void OnGet()
        {

            CommunityGalleries = CommunityGalleryService.GetAllData(userType);

        }

    }

}