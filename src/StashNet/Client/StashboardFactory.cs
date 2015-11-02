using System;
using StashNet.Contracts;
using StashNet.Exceptions;
using StashNet.Internal;

namespace StashNet.Client
{
    public static class StashboardFactory
    {
        public static StashboardClient New(Action<StashboardClientBehavior> args)
        {
            try
            {
                var init = new StashboardClientBehaviorImpl();
                args(init);
                var client = new StashboardClientImpl(init);

                return client;
            }
            catch (Exception e)
            {
                throw new StashboardClientInitException("Unable to initialize the Stashboard client.", e);
            }
        }
    }
}