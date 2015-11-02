using StashNet.Contracts;

namespace StashNet.Internal
{
    internal class StatusCharacteristicsImpl :
        StatusCharacteristics
    {
        public string name { get; set; }
        public string description { get; set; }

        public void IdentifiedAs(string name, string description)
        {
           this.name = name;
            this.description = description;
        }
    }
}