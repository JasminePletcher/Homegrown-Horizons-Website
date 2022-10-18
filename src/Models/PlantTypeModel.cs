using ContosoCrafts.WebSite.Models.ENUM;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Stores the Plant types details
    /// </summary>
    public class PlantTypeModel
    {
        
        // Plant Type Id
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        // Tab number on the page
        [JsonPropertyName("TabNum")]
        public TabNum TabNum { get; set; }

        // Type of plant
        [JsonPropertyName("Type")]
        public string Type { get; set; }

        // Description of the planttype
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        // The plant example
        [JsonPropertyName("Plant")]
        public string Plant { get; set; }

        // The image of the post
        [JsonPropertyName("Image")]
        public string Image { get; set; }

        // The website source
        [JsonPropertyName("Source")]
        public string Source { get; set; }

        // String representation of a the gallery product 
        public override string ToString() => JsonSerializer.Serialize<PlantTypeModel>(this);

    }

}