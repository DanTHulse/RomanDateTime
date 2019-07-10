using System.ComponentModel;

namespace RomanDate.Enums
{
    /// <summary>
    /// The type of office that a Magistrate assumed
    /// </summary>
    public enum Office
    {
        NotSet = 0,

        /// <summary>
        /// The First Consul, usually the man who won the most votes in the election, or the Emperor during the Roman Empire
        /// </summary>
        [Description("Consul Prior")]
        ConsulPrior = 1,

        /// <summary>
        /// The Second Consul, usually the man who was elected behind the Consul Prior, or the Emperor's Consular colleague
        /// </summary>
        [Description("Consul Posterior")]
        ConsulPosterior = 2,

        /// <summary>
        /// Used to refer to any Consuls that assumed office after an election due to the death or resignation of another Consul
        /// </summary>
        [Description("Consul Suffectus")]
        ConsulSuffectus = 3,

        /// <summary>
        /// Emergency powers granted to an individual for upto 6 months. Had complete control over the entire Roman state
        /// </summary>
        [Description("Dictator")]
        Dictator = 4,

        /// <summary>
        /// Created to give the Plebians more power, in the early Republic could rule as a group in place of Consuls
        /// </summary>
        [Description("Consular Tribune")]
        Tribune = 5,

        /// <summary>
        /// Ten man commisions that twice ruled in place of Consuls or Tribunes
        /// </summary>
        [Description("Decemvir")]
        Decemvir = 6,

        /// <summary>
        /// A position open only to Plebians, there were 10 of them each year and they exercised veto power over all other public officials.
        /// </summary>
        [Description("Plebian Tribune")]
        PlebianTibune = 7,

        /// <summary>
        /// Elected to serve with a Legion as a stepping stone on a political career and to serve as a form of officer training
        /// </summary>
        [Description("Military Tribune")]
        MilitaryTribune = 8,

        /// <summary>
        /// Served as financial and administrative advisors within the City or out in a Province under a Governor
        /// </summary>
        [Description("Quaestor")]
        Quaestor = 9,

        /// <summary>
        /// Given charge of the upkeep of Rome's temples and other public buidlings, also organised festivals and public events such as the games
        /// </summary>
        [Description("Aedile")]
        Aedile = 10,

        /// <summary>
        /// Served as Judges and prescided over Rome's legal system alongide the Consuls. Also would command Legions in place of Consuls
        /// </summary>
        [Description("Praetor")]
        Praetor = 11,

        /// <summary>
        /// In charge of the offical membership rolls for the Senate, also organised the Roman census.
        /// </summary>
        [Description("Censor")]
        Censor = 12,

        /// <summary>
        /// After a term as Praetor or Consul, the Senator was eligible to take command of a Roman province as a Propraetor or Proconsul repectively
        /// </summary>
        [Description("Governor")]
        Governor = 13
    }
}