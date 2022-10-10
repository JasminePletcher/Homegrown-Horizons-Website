using System.Runtime.Serialization;


namespace ContosoCrafts.WebSite.Models.ENUM
{
    /// <summary>
    /// Plant category enum categories
    /// </summary>
    public enum PlantCategory
    {
        // Succulent variable 
        [EnumMember(Value = "SUCCULENT")]
        SUCCULENT = 1,

        // Tropical variable 
        [EnumMember(Value = "TROPICAL")]
        TROPICAL = 2,

        // Air variable 
        [EnumMember(Value = "AIR")]
        AIR = 3,

        // Edible variable 
        [EnumMember(Value = "EDIBLE")]
        EDIBLE = 4,

        // Undefined variable 
        Undefined = 0
    }

}