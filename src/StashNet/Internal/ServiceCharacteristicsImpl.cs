using StashNet.Contracts;
using Newtonsoft.Json;

namespace StashNet.Internal
{

    internal class ServiceCharacteristicsImpl :
        ServiceCharacteristics
    {
        public ServiceCharacteristicsImpl()
        {
        }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description", Order = 2, Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        public void WithDescription(string serviceDescription)
        {
            Description = serviceDescription;
        }

        public void WithName(string serviceName)
        {
            Name = serviceName;
        }
    }
}