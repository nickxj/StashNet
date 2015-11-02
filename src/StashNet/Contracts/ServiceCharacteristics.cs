namespace StashNet.Contracts
{
    public interface ServiceCharacteristics
    {

        /// <summary>
        /// Name of service
        /// </summary>
        /// <param name="serviceName"></param>
        void WithName(string serviceName);

        /// <summary>
        /// Description of service
        /// </summary>
        /// <param name="serviceDescription"></param>
        void WithDescription(string serviceDescription);

    }
}