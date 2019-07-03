using RomanDate.Helpers;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetConsularYear()
        {
            return this.ConsularData.ParseConsularYear();
        }
    }
}