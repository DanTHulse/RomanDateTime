using RomanDate.Definitions;
using RomanDate.Helpers;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private ConsularDate GetConsularDate()
        {
            var auc = 753;
            var year = (auc += this.DateTimeData.Year);
            return RomanDateHelpers.ReturnConsularYearData(year);
        }
    }
}