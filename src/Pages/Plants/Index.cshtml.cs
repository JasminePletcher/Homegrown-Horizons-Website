using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Plants
{
    /// <summary>
    /// Index Page will return all the data to show
    /// </summary>
    public class IndexModel : PageModel
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public IndexModel(JsonFilePlantService plantService)
        {

            PlantService = plantService;

        }

        // Plant Data Service
        public JsonFilePlantService PlantService { get; }

        [BindProperty]

        // public PlantModel Plant { get; set; }
        public IEnumerable<PlantModel> Plants { get; private set; }

        /// <summary>
        /// get all plant data
        /// </summary>
        public void OnGet()
        {

            Plants = PlantService.GetAllData();


        }

    }

}