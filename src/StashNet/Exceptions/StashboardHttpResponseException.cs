using System;

namespace StashNet.Exceptions
{

    [Serializable]
    public class StashboardHttpResponseException : Exception
    {
        public StashboardHttpResponseException() { }
        public StashboardHttpResponseException(string message) : base(message) { }
        public StashboardHttpResponseException(string message, Exception inner) : base(message, inner) { }
        protected StashboardHttpResponseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
