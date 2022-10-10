using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The home page of our website
    /// </summary>
    public class IndexModel : PageModel
    {

        //decalre variables
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Initialize the logger
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger, JsonFilePlantService plantService)
        {

            _logger = logger;

        }

        /// <summary>
        /// Currently unused. Will update comment if used
        /// </summary>
        public void OnGet()
        {

            return;

        }

    }

}