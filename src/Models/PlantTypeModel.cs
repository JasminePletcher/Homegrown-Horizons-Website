using ContosoCrafts.WebSite.Models.ENUM;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// stores the Plant types details
    /// </summary>
    public class PlantTypeModel
    {
        
        // Plant Type Id
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        //tab number on the page
        [JsonPropertyName("TabNum")]
        public TabNum TabNum { get; set; }

        // type of plant
        [JsonPropertyName("Type")]
        public string Type { get; set; }

        // Description of the planttype
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        //the plant example
        [JsonPropertyName("Plant")]
        public string Plant { get; set; }

        //the image of the post
        [JsonPropertyName("Image")]
        public string Image { get; set; }

        //the website source
        [JsonPropertyName("Source")]
        public string Source { get; set; }

        //Want string representation of a the gallery product 
        public override string ToString() => JsonSerializer.Serialize<PlantTypeModel>(this);

    }

}