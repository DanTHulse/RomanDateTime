using System.Collections.Generic;
using System.Linq;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    public class Magistrates
    {
        internal ConsularDate Data { get; set; }
        internal Magistrates(ConsularDate data)
        {
            Data = data;
        }

        public Magistrate ConsulPrior => Data.Magistrates.FirstOrDefault(f => f.Type == MagistrateType.ConsulPrior);
        public Magistrate ConsulPosterior => Data.Magistrates.FirstOrDefault(f => f.Type == MagistrateType.ConsulPosterior);
        public IEnumerable<Magistrate> Suffecti => Data.Magistrates.Where(w => w.Type == MagistrateType.ConsulSuffectus);
        public Magistrate Dictator => Data.Magistrates.FirstOrDefault(f => f.Type == MagistrateType.Dictator);
        public IEnumerable<Magistrate> Tribuni => Data.Magistrates.Where(w => w.Type == MagistrateType.Tribune);
        public IEnumerable<Magistrate> Decemviri => Data.Magistrates.Where(w => w.Type == MagistrateType.Decemvir);
    }

    public class Magistrate
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        internal MagistrateType Type { get; set; }
    }
}