using System.Collections.Generic;

namespace API.RomanDate.Models
{
    public class MagistratesFull
    {
        public string Name { get; set; } = "";
        public IEnumerable<ElectedOffice> ElectedOffices { get; set; } = new List<ElectedOffice>();
    }
}
