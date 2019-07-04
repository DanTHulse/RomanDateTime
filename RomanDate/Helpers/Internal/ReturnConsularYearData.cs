using System.Linq;
using RomanDate.Definitions;

namespace RomanDate.Helpers
{
    public static partial class RomanDateHelpers
    {
        internal static ConsularDate ReturnConsularYearData(int aucYear)
        {
            var data = LoadConsularData();

            var item = data.FirstOrDefault(f => f.Id == aucYear);

            return item;
        }
    }
}