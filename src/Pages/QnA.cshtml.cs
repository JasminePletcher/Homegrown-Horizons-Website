using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// QnA page will return all the data to show
    /// </summary>
    public class QnAModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public QnAModel(JsonFileQnAService service)
        {

            QService = service;

        }

        // QnA Service
        public JsonFileQnAService QService { get; }

        [BindProperty]

        // Creating an IEnumerable object of QnAModel
        public IEnumerable<Models.QnAModel> QnAList { get; private set; }

        /// <summary>
        /// get all QnA data
        /// </summary>
        public void OnGet()
        {

            QnAList = QService.GetAllData();

        }

    }

}