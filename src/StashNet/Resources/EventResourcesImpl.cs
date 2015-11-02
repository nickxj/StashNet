using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using StashNet.Contracts;
using StashNet.Internal;
using StashNet.Models;
using StashNet.Extensions;


namespace StashNet.Resources
{
    internal class EventResourcesImpl :
        StashboardResourcesBase,
        EventResources
    {
        public EventResourcesImpl(RestClient client) :
            base(client)
        {
        }

        public Task<EventRoot> GetAll(Action<ServiceTarget> service, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var serviceTargetImpl = new ServiceTargetImpl();
            service(serviceTargetImpl);

            var url = string.Format("/admin/api/v1/services/{0}/events", serviceTargetImpl.Target);
            return base.Get(url, cancellationToken).As<EventRoot>(cancellationToken);
        }

        public Task<Event> New(Action<ServiceTarget> service, Action<EventCharacteristics> characteristics, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var serviceTargetImpl = new ServiceTargetImpl();
            service(serviceTargetImpl);

            var characteristicsImpl = new EventCharacteristicsImpl();
            characteristics(characteristicsImpl);

            var url = string.Format("/admin/api/v1/services/{0}/events", serviceTargetImpl.Target);
            return base.Post(url, characteristicsImpl, cancellationToken).As<Event>(cancellationToken);

        }
    }
}