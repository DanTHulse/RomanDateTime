using RomanDate.Helpers;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private string GetConsularYear() => this.ConsularData.ParseConsularYear();
    }
}