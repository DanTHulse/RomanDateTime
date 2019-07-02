using System.ComponentModel;

namespace RomanDate.Enums
{
    public enum YearType
    {
        [Description("Consulship")]
        Consulship = 1,
        [Description("Tribunate")]
        Tribunship = 2,
        [Description("Dictatorship")]
        Dictatorship = 3,
        [Description("Decemviri")]
        Decemvirate = 4
    }
}
