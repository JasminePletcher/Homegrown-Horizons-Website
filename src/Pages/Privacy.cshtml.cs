using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Page for our privacy
    /// </summary>
    public class PrivacyModel : PageModel
    {
        //declare variables
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// initialize logger
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {

            _logger = logger;

        }

        /// <summary>
        /// currently do nothing, will update once implemented
        /// </summary>
        public void OnGet()
        {

        }

    }

}