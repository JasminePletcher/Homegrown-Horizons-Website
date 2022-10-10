using System.Runtime.Serialization;

namespace ContosoCrafts.WebSite.Models.ENUM
{

    /// <summary>
    /// Users categories 
    /// </summary>
    public enum UserType
    {

        // Admin variable 
        [EnumMember(Value = "ADMIN")]
        ADMIN = 1,

        // User variable 
        [EnumMember(Value = "USER")]
        USER = 2,

        // Undefined variable
        Undefined = 0
    }

}