using System;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;
using StashNet.Contracts;
using StashNet.Internal;
using StashNet.Resources;

namespace StashNet.Client
{
    internal class StashboardClientImpl :
        StashboardClient
    {
        public StashboardClientImpl(StashboardClientBehaviorImpl args)
        {
            Behavior = args;
        }

        private StashboardClientBehaviorImpl Behavior { get; }
        public RestClient Client { get; set; }

        public T Factory<T>(Action<OAuthCredentials> oAuthCredentials)
            where T : ResourceClient
        {
            var oAuthCredentialsImpl = new OAuthCredentialsImpl();
            oAuthCredentials(oAuthCredentialsImpl);

            var uri = new Uri($"{Behavior.HostUrl}/");

            var consumerKey = "anonymous";
            var consumerSecret = "anonymous";

            // var client = new HttpClient(handler) {BaseAddress = uri};
            var client = new RestClient(uri)
            {
                Authenticator = OAuth1Authenticator.ForProtectedResource(
                    consumerKey, 
                    consumerSecret, 
                    oAuthCredentialsImpl.Token, 
                    oAuthCredentialsImpl.Secret)
            };
            


            if (Behavior.Timeout != TimeSpan.Zero)
                client.Timeout = (int)Behavior.Timeout.TotalMilliseconds;

            Client = client;

            var type = typeof (T);
            var implClass = GetType().Assembly
                .GetTypes()
                .FirstOrDefault(x => type.IsAssignableFrom(x) && !x.IsInterface);

            return (T) Activator.CreateInstance(implClass, client);
        }

        public void CancelPendingRequests()
        {
            //Client.CancelPendingRequests();
        }
    }
}