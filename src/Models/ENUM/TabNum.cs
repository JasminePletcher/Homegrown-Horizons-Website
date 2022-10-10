using System.Runtime.Serialization;

namespace ContosoCrafts.WebSite.Models.ENUM
{
    /// <summary>
    /// Tab Num enum categories
    /// </summary>
    public enum TabNum
    {
        // Tab1 variable 
        [EnumMember(Value = "TAB1")]
        TAB1 = 1,

        // Tab2 variable 
        [EnumMember(Value = "TAB2")]
        TAB2 = 2,

        // Tab3 variable 
        [EnumMember(Value = "TAB3")]
        TAB3 = 3,

        // Tab4 variable 
        [EnumMember(Value = "TAB4")]
        TAB4 = 4,

        // Undefined variable 
        Undefined = 0
    }

}