using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Models.ENUM;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// This class is focus on retrieving the Json that contain the data of
    /// Questions and Answers to display it on pages. 
    /// </summary>
    public class JsonFileQnAService
    {
        // Declaring the WebHostEnvironment variable
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// IWebHostEnvironment: allow us to retrieve the JSON file
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileQnAService(IWebHostEnvironment webHostEnvironment)
        {

            WebHostEnvironment = webHostEnvironment;

        }

        /// <summary>
        /// Get the file name of the json from the Data folder
        /// </summary>
        private string JsonFileName
        {

            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "QnA.json"); }

        }

        /// <summary>
        /// Retrieving the json text and converting it to the objects
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public IEnumerable<QnAModel> GetAllData(TabNum tab = TabNum.Undefined)
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {

                // Making an array of objects. Read the json file to the end.
                var result = JsonSerializer.Deserialize<QnAModel[]>(jsonFileReader.ReadToEnd(),
                     new JsonSerializerOptions
                     {
                         // Dont really care about the upper case and lower case
                         // to make it less stressful 
                         PropertyNameCaseInsensitive = true

                     }
                     );

                if (tab.Equals(TabNum.Undefined))
                {

                    return result;

                }

                return result.Where(x => x.TabNum.Equals(tab));

            }

        }

    }

}