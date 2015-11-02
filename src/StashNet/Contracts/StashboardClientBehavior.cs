using System;

namespace StashNet.Contracts
{
    public interface StashboardClientBehavior
    {
        void ConnectTo(string hostUrl);

        void TimeoutAfter(TimeSpan timeout);
    }
}