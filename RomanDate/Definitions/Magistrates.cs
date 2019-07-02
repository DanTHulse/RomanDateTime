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
            this.Data = data;
        }

        public Magistrate ConsulPrior => this.Data.Magistrates.FirstOrDefault(f => f.Type == MagistrateType.ConsulPrior);
        public Magistrate ConsulPosterior => this.Data.Magistrates.FirstOrDefault(f => f.Type == MagistrateType.ConsulPosterior);
        public IEnumerable<Magistrate> Suffecti => this.Data.Magistrates.Where(w => w.Type == MagistrateType.ConsulSuffectus);
        public Magistrate Dictator => this.Data.Magistrates.FirstOrDefault(f => f.Type == MagistrateType.Dictator);
        public IEnumerable<Magistrate> Tribuni => this.Data.Magistrates.Where(w => w.Type == MagistrateType.Tribune);
        public IEnumerable<Magistrate> Decemviri => this.Data.Magistrates.Where(w => w.Type == MagistrateType.Decemvir);
    }

    public class Magistrate
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public MagistrateType Type { get; set; }
    }
}