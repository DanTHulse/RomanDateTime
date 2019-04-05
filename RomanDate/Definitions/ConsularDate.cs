using System.Collections.Generic;
using System.Linq;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    internal class ConsularDate
    {
        public int Id { get; set; }
        public YearType Type { get; set; }
        public IEnumerable<Magistrate> Magistrates { get; set; }
        public string Override { get; set; }

        internal Magistrate ConsulPrior => Magistrates.FirstOrDefault(f => f.Type == MagistrateType.ConsulPrior);
        internal Magistrate ConsulPosterior => Magistrates.FirstOrDefault(f => f.Type == MagistrateType.ConsulPosterior);
        internal IEnumerable<Magistrate> ConsulSuffecti => Magistrates.Where(w => w.Type == MagistrateType.ConsulSuffectus);
        internal Magistrate Dictator => Magistrates.FirstOrDefault(f => f.Type == MagistrateType.Dictator);
        internal IEnumerable<Magistrate> Tribuni => Magistrates.Where(w => w.Type == MagistrateType.Tribune);
        internal IEnumerable<Magistrate> Decemviri => Magistrates.Where(w => w.Type == MagistrateType.Decemvir);
    }

    public class Magistrate
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        internal MagistrateType Type { get; set; }
    }

    public class Magistrates
    {
        internal ConsularDate Data { get; set; }
        internal Magistrates(ConsularDate data)
        {
            Data = data;
        }

        public IEnumerable<Magistrate> Consules => new Magistrate[] { Data.ConsulPrior, Data.ConsulPosterior };
        public IEnumerable<Magistrate> Suffecti => Data.ConsulSuffecti;
        public Magistrate Dictator => Data.Dictator;
        public IEnumerable<Magistrate> Tribuni => Data.Tribuni;
        public IEnumerable<Magistrate> Decemviri => Data.Decemviri;
    }
}