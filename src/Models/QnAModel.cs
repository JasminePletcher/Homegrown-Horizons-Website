using ContosoCrafts.WebSite.Models.ENUM;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// stores the Q and A details
    /// </summary>
    public class QnAModel
    {
        //Q n A Id
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        //question or title of the section
        [JsonPropertyName("Question")]
        public string Question { get; set; }

        //answer to the question
        [JsonPropertyName("Answer")]
        public string Answer { get; set; }

        //tab number on the page
        [JsonPropertyName("TabNum")]
        public TabNum TabNum { get; set; }

        //the website source
        [JsonPropertyName("Source")]
        public string Source { get; set; }

        //the image of the post
        [JsonPropertyName("Image")]
        public string Image { get; set; }

        //Want string representation of a the gallery product 
        public override string ToString() => JsonSerializer.Serialize<QnAModel>(this);

    }

}