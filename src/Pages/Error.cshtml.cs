using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Class for error messages
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // declare the variable for requestId 
        public string RequestId { get; set; }

        // creating a boolean for the requestID if it is null or empty
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Creaeting a logger variable 
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// log the error message
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {

            _logger = logger;

        }

        /// <summary>
        /// get stack trace
        /// </summary>
        public void OnGet()
        {

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        }

    }

}