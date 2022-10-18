using ContosoCrafts.WebSite.Models.ENUM;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// This class will create an object for each plant 
    /// </summary> 
    public class PlantModel
    {

        // Get and set the type of the user
        [JsonPropertyName("UserType")]
        public UserType UserType { get; set; }

        // Get and set the id of each user 
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        // Get and set the title of their post 
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        // Mapping out the image.
        [JsonPropertyName("Image")]
        public string Image { get; set; }

        // PlantCategory enum
        [JsonPropertyName("PlantCategory")]
        public string PlantCategory { get; set; }

        // Get and set the description of the plant
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        // Get and set the wikilink of the plant 
        [JsonPropertyName("WikiLink")]
        public string Wikilink { get; set; }

        // String of a gallery product 
        public override string ToString() => JsonSerializer.Serialize<PlantModel>(this);
  
    }

}