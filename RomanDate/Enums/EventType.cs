using System.ComponentModel;

namespace RomanDate.Enums
{
    public enum EventType
    {
        NotSet = 0,

        [Description("Festival")]
        Festival = 1,

        [Description("Temple Dedication")]
        TempleDedication = 2,
    }
}
