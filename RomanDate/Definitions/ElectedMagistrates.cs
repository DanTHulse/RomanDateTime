using System.Collections.Generic;
using System.Linq;
using RomanDate.Enums;

namespace RomanDate.Definitions
{
    /// <summary>
    /// The elected magistrates for any given year split by office
    /// </summary>
    public class ElectedMagistrates
    {
        internal ConsularDate Data { get; set; }

        internal ElectedMagistrates(ConsularDate data)
        {
            this.Data = data;
        }

        /// <summary>
        /// The elected Consul Prior (First Consul) for the year
        /// </summary>
        public Magistrate ConsulPrior => this.Data.Magistrates.FirstOrDefault(f => f.Office == Office.ConsulPrior);

        /// <summary>
        /// The elected Consul Posterior (Second Consul) for the year
        /// </summary>
        public Magistrate ConsulPosterior => this.Data.Magistrates.FirstOrDefault(f => f.Office == Office.ConsulPosterior);

        /// <summary>
        /// Any other Consuls that assumed office this year, due to the death or resignation of another Consul
        /// </summary>
        public IEnumerable<Magistrate> Suffecti => this.Data.Magistrates.Where(w => w.Office == Office.ConsulSuffectus);

        /// <summary>
        /// The Dictator that assumed office this year
        /// </summary>
        public Magistrate Dictator => this.Data.Magistrates.FirstOrDefault(f => f.Office == Office.Dictator);

        /// <summary>
        /// Any Consular Tribunes elected into office this year
        /// </summary>
        public IEnumerable<Magistrate> Tribuni => this.Data.Magistrates.Where(w => w.Office == Office.Tribune);

        /// <summary>
        /// Any Decemvir (member of a 10 man commision) that assumed office this year
        /// </summary>
        public IEnumerable<Magistrate> Decemviri => this.Data.Magistrates.Where(w => w.Office == Office.Decemvir);
    }
}