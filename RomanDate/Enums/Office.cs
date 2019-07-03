namespace RomanDate.Enums
{
    /// <summary>
    /// The type of office that a Magistrate assumed
    /// </summary>
    public enum Office
    {
        /// <summary>
        /// The First Consul, usually the man who won the most votes in the election, or the Emperor during the Roman Empire
        /// </summary>
        ConsulPrior = 1,

        /// <summary>
        /// The Second Consul, usually the man who was elected behind the Consul Prior, or the Emperor's Consular colleague
        /// </summary>
        ConsulPosterior = 2,

        /// <summary>
        /// Used to refer to any Consuls that assumed office after an election due to the death or resignation of another Consul
        /// </summary>
        ConsulSuffectus = 3,

        /// <summary>
        /// Emergency powers granted to an individual for upto 6 months. Had complete control over the entire Roman state
        /// </summary>
        Dictator = 4,

        /// <summary>
        /// Created to give the Plebians more power, in the early Republic could rule as a group in place of Consuls
        /// </summary>
        Tribune = 5,

        /// <summary>
        /// Ten man commisions that twice ruled in place of Consuls or Tribunes
        /// </summary>
        Decemvir = 6
    }
}