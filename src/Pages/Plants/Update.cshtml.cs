using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models.ENUM;

namespace ContosoCrafts.WebSite.Pages.Plants
{
    /// <summary>
    /// Manage the Update of the data for a single record
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Data middletier
        public JsonFilePlantService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UpdateModel(JsonFilePlantService productService)
        {

            ProductService = productService;

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

            //will need to add update for Admins
            Plant = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            
            // check if Plant is null, if so redirect back to index
            if (Plant == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {

                return Page();

            }

            //plant with updated info
            ProductService.UpdateData(Plant);
            
            //query to determine where the user will be routed after submitting
            string query = Request.QueryString.ToString();

            var routeQuery = $"goto={UserType.USER}";

            if (query.Contains(routeQuery))
            {
                return RedirectToPage("/CommunityBoardGallery");
            }

            return RedirectToPage("/Plants/Index");
        }

    }

}