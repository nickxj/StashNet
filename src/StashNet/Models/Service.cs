using System.Collections.Generic;
using Newtonsoft.Json;

namespace StashNet.Models
{
    public class ServiceRoot
    {
        [JsonProperty("services")]
        public IEnumerable<Service> Services { get; set; }
    }

    public class Service
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("list")]
        public object List { get; set; }

        [JsonProperty("current-event")]
        public Event Event { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}