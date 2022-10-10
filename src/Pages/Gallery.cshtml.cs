using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models.ENUM;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// This class ask for a logger and ask for the objects from the json file
    /// </summary>
    public class GalleryModel : PageModel
    {
        // Creating a logger variable 
        private readonly ILogger<PageModel> _logger;

        // Creating a service for the JsonFilePlantService
        public JsonFilePlantService GalleryService { get; }

        // Creating an IEnumerable object of PlantModel
        public IEnumerable<PlantModel> Galleries { get; private set; }

        //to string the ENUM value of ADMIN
        private UserType userType = UserType.ADMIN;

        /// <summary>
        /// Asking for a logger using the json file service for the Gallery
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="galleryService"></param>
        public GalleryModel(ILogger<PageModel> logger, JsonFilePlantService galleryService)
        {

            _logger = logger;

            GalleryService = galleryService;

        }

        /// <summary>
        /// This function shall call the GetGallery function from the
        /// JsonFileGalleryService.cs to get the object 
        /// </summary>
        public void OnGet()
        {

            Galleries = GalleryService.GetAllData(userType);
            
        }

    }

}