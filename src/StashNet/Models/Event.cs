using Newtonsoft.Json;
using System.Collections.Generic;

namespace StashNet.Models
{

    public class EventRoot
    {
        [JsonProperty("events")]
        public IEnumerable<Event> Events { get; set; }
    }

    public class Event
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("sid")]
        public string Sid { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("informational")]
        public bool Informational { get; set; }
    }
}