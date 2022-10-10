using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Plants
{
    /// <summary>
    /// Manage the Read of a single plant
    /// </summary>
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFilePlantService PlantService { get; }

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="PlantService"></param>
        public ReadModel(JsonFilePlantService plantService)
        {

            PlantService = plantService;

        }

        // The data to show
        public PlantModel Plant;

        /// <summary>
        /// REST Get request, fetches data of the plant 
        /// </summary>
        /// <param name="id">id of the plant to get</param>
        public IActionResult OnGet(string id)
        {

            Plant = PlantService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));

            if (Plant == null)
            {

                return RedirectToPage("./Index");

            }

            return Page();
        }

    }

}