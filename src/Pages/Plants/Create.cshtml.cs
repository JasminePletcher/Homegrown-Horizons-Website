using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models.ENUM;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Plants
{
    /// <summary>
    /// Manage the Creation of a single plant
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier
        public JsonFilePlantService PlantService { get; }
        //used to indentify which page directed into this create page
        public string CreateCode { get; set; }

        /// <summary>
        /// Default Construtor
        /// </summary>
        /// <param name="productService"></param>
        public CreateModel(JsonFilePlantService productService)
        {

            PlantService = productService;

        }

        // The data to show, bind to it for the post
        [BindProperty]
        public PlantModel Product { get; set; }

        /// <summary>
        /// Getting the id for create code which reference to which page redirected to this page
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {

            CreateCode = id;

        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(string id = null)
        {

            if (!ModelState.IsValid)
            {

                return Page();

            }

            PlantService.CreateData(Product, id);

            if(id == UserType.USER.ToString())
            {
                return RedirectToPage("/CommunityBoardGallery");
            }

            return RedirectToPage("/Plants/Index");
        }

    }

}