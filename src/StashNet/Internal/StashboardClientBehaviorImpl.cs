using System;
using StashNet.Contracts;

namespace StashNet.Internal
{

    internal class StashboardClientBehaviorImpl :
        StashboardClientBehavior
    {
        public string HostUrl { get; private set; }
        public TimeSpan Timeout { get; private set; }

        public void ConnectTo(string hostUrl)
        {
            HostUrl = hostUrl;
        }

        public void TimeoutAfter(TimeSpan timeout)
        {
            Timeout = timeout;
        }
    }
}