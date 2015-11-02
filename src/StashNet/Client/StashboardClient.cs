using System;
using StashNet.Contracts;
using StashNet.Resources;

namespace StashNet.Client
{
    public interface StashboardClient
    {
        T Factory<T>(Action<OAuthCredentials> oAuthCredentials)
            where T : ResourceClient;

        void CancelPendingRequests();
    }
}
