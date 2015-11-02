using Newtonsoft.Json;
using System.Collections.Generic;

namespace StashNet.Models
{
    public class StatusRoot
    {
        [JsonProperty("statuses")]
        public IEnumerable<Status> Statuses { get; set; }
    }
    public class Status
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}