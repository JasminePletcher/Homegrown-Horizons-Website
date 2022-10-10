using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// TeamInfo Page will return all the data to show
    /// </summary>
    public class TeamInfoModel : PageModel
    {

        // Create a Ilogger variable 
        private readonly ILogger<TeamInfoModel> _logger;

        /// <summary>
        /// initialize logger
        /// </summary>
        /// <param name="logger"></param>
        public TeamInfoModel(ILogger<TeamInfoModel> logger)
        {

            _logger = logger;

        }

        /// <summary>
        /// get TeamInfo data
        /// </summary>
        /// <param name="logger"></param>
        public void OnGet()
        {

        }

    }

}