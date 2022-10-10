using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// PlantTypeModel page will return all the data to show
    /// </summary>
    public class PlantTypeModel : PageModel
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service"></param>
        public PlantTypeModel(JsonFilePlantTypeService service)
        {

            PTService = service;

        }

        // Plant Type Service
        public JsonFilePlantTypeService PTService { get; }

        [BindProperty]

        // Creating an IEnumerable object of PlantTypeModel
        public IEnumerable<Models.PlantTypeModel> PTList { get; private set; }


        /// <summary>
        /// get all PlantType data
        /// </summary>
        public void OnGet()
        {

            PTList = PTService.GetAllData();

        }

    }

}