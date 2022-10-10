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
    /// plants to display it on pages. 
    /// </summary>
    public class JsonFilePlantService
    {
        // Declaring the WebHostEnvironment variable
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// IWebHostEnvironment: allow us to retrieve the JSON file
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFilePlantService(IWebHostEnvironment webHostEnvironment)
        {

            WebHostEnvironment = webHostEnvironment;

        }

        /// <summary>
        /// Get the file name of the json from the Data folder
        /// </summary>
        private string JsonFileName
        {

            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "PlantsData.json"); }

        }

        /// <summary>
        /// Retrieving the json text and converting it to the objects
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public IEnumerable<PlantModel> GetAllData(UserType type = UserType.Undefined)
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {

                // Making an array of objects. Read the json file to the end.
                var result = JsonSerializer.Deserialize<PlantModel[]>(jsonFileReader.ReadToEnd(),
                     new JsonSerializerOptions
                     {
                         // Dont really care about the upper case and lower case
                         // to make it less stressful 
                         PropertyNameCaseInsensitive = true
                     }
                     );

                if (type.Equals(UserType.Undefined))
                {

                    return result;

                }

                return result.Where(x => x.UserType.Equals(type));

            }

        }

        /// <summary>
        /// Updates and write to JSON file when passed in Object
        /// </summary>
        /// <param name="data"> PlantModel</param>
        /// <returns>Data of the selected plant model updated with user input</returns>
        public PlantModel UpdateData(PlantModel data)
        {
            // Getting a list of all the plants, saving it in products
            var products = GetAllData();

            // Creates a plant object, save in productData
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));

            //if no existing data found, do nothing
            if (productData == null)
            {

                return null;

            }

            productData.Title = data.Title;

            productData.Description = data.Description;

            productData.Image = data.Image;

            productData.PlantCategory = data.PlantCategory;

            //data.UserType = productData.UserType;

            //writes to file
            SaveData(products);

            return productData;

        }

        /// <summary>
        /// Save All products by writing to JSON file
        /// </summary>
        private void SaveData(IEnumerable<PlantModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<PlantModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }
                    ),

                    products

                );

            }

        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns>Returns the communityGalleryModel with the new post included</returns>
        public PlantModel CreateData(PlantModel communityGalleryModel, string createCodeID = null)
        {
            if (communityGalleryModel == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(createCodeID))
            {
                createCodeID = string.Empty;
            }

            if (!string.IsNullOrEmpty(communityGalleryModel.Title))
            {
                //set generated ID
                var id = System.Guid.NewGuid().ToString();

                communityGalleryModel.Id = id;

                if(createCodeID.Equals(UserType.USER.ToString()))
                {
                    communityGalleryModel.UserType = UserType.USER;
                }

                //grab all data and append
                var dataSet = GetAllData();

                dataSet = dataSet.Append(communityGalleryModel);

                //writes to JSON
                SaveData(dataSet); 
            }

            return communityGalleryModel;

        }

        /// <summary>
        /// Delete data from json file
        /// </summary>
        /// <param name="id"></param>
        /// <returns>dataset without the deleted post</returns>
        public PlantModel DeleteData(string id)
        {

            // Get the current set, and append the new record to it
            var dataSet = GetAllData();

            //Get the post to delete
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            if (data == null)
            {

                return null;

            }

            // Find all products whose id does not match and get that data set
            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            // Save the data to the JSON file
            SaveData(newDataSet);

            // Return dataset without the deleted data
            return data;
        }

    }

}