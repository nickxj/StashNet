using System;

namespace StashNet.Exceptions
{
    public class StashboardClientInitException :
        Exception
    {
        public StashboardClientInitException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}