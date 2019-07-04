using RomanDate.Definitions;

namespace RomanDate
{
    public partial struct RomanDateTime
    {
        private ElectedMagistrates? GetMagistrates()
        {
            if (this.ConsularData != null)
            {
                return new ElectedMagistrates(this.ConsularData);
            }

            return null;
        }
    }
}