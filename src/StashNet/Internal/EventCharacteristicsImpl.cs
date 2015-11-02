using StashNet.Contracts;

namespace StashNet.Internal
{
    internal class EventCharacteristicsImpl :
        EventCharacteristics
    {
        public string status { get; set; }
        public string message { get; set; }


        public void With(string statusId, string eventMessage)
        {
            status = statusId;
            message = eventMessage;
        }
    }
}