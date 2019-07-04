using System.ComponentModel;

namespace RomanDate.Enums
{
    /// <summary>
    /// Different descriptions for the year, based on the primary Magistrate in office that year
    /// </summary>
    public enum YearOf
    {
        NotSet = 0,

        /// <summary>
        /// A year in which the primary Magistrates where a pair (or occasinally single) Consul
        /// </summary>
        [Description("Consulship")]
        Consulship = 1,

        /// <summary>
        /// A year in which the primary Magistrates where a group of between 2-6 Tribunes
        /// </summary>
        [Description("Tribunate")]
        Tribunship = 2,

        /// <summary>
        /// A year in which the primary Magistrate was a Dictator
        /// </summary>
        [Description("Dictatorship")]
        Dictatorship = 3,

        /// <summary>
        /// A year in which the primary Magistrates where a 10 man commision known as a Decemviri
        /// </summary>
        [Description("Decemviri")]
        Decemvirate = 4
    }
}
