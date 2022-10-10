using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Plants
{
    /// <summary>
    /// Manage the Delete of the data for a single record
    /// </summary>
    public class DeleteModel : PageModel
    {
        // Data middletier
        public JsonFilePlantService PlantService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="plantService"></param>
        public DeleteModel(JsonFilePlantService plantService)
        {

            PlantService = plantService;

        }

        // The data to show, bind to it for the post
        [BindProperty]
        public PlantModel Plant { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {

            Plant = PlantService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));

            // defensive programming in case a plant that doesn't exist is attempting to be deleted
            if (Plant == null)
            {

                return RedirectToPage("./Index");

            }

            return Page();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Delete that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {

                return Page();

            }

            PlantService.DeleteData(Plant.Id);

            return RedirectToPage("./Index");
        }

    }

}