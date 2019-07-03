using System.Collections.Generic;
using System.Linq;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    public class ElectedMagistrates
    {
        internal ConsularDate Data { get; set; }
        internal ElectedMagistrates(ConsularDate data)
        {
            this.Data = data;
        }

        public Magistrate ConsulPrior => this.Data.Magistrates.FirstOrDefault(f => f.Type == Magistrates.ConsulPrior);
        public Magistrate ConsulPosterior => this.Data.Magistrates.FirstOrDefault(f => f.Type == Magistrates.ConsulPosterior);
        public IEnumerable<Magistrate> Suffecti => this.Data.Magistrates.Where(w => w.Type == Magistrates.ConsulSuffectus);
        public Magistrate Dictator => this.Data.Magistrates.FirstOrDefault(f => f.Type == Magistrates.Dictator);
        public IEnumerable<Magistrate> Tribuni => this.Data.Magistrates.Where(w => w.Type == Magistrates.Tribune);
        public IEnumerable<Magistrate> Decemviri => this.Data.Magistrates.Where(w => w.Type == Magistrates.Decemvir);
    }

    public class Magistrate
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public Magistrates Type { get; set; }
    }
}