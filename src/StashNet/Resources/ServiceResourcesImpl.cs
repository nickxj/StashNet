using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using StashNet.Contracts;
using StashNet.Extensions;
using StashNet.Models;
using StashNet.Internal;

namespace StashNet.Resources
{
    internal class ServiceResourcesImpl :
        StashboardResourcesBase,
        ServiceResources
    {
        public ServiceResourcesImpl(RestClient client) :
            base(client)
        {
        }

        public Task<ServiceRoot> GetAll(CancellationToken cancellationToken = default(CancellationToken))
        {
            const string url = "/admin/api/v1/services";
            return base.Get(url, cancellationToken).As<ServiceRoot>(cancellationToken);
        }

        public Task<Service> New(Action<ServiceCharacteristics> characteristics, CancellationToken cancellationToken = new CancellationToken())
        {
            var characteristicsImpl = new ServiceCharacteristicsImpl();
            characteristics(characteristicsImpl);

            string url = string.Format("/admin/api/v1/services");

            return base.Post(url, characteristicsImpl, cancellationToken).As<Service>(cancellationToken);
        }

        public Task<Service> Delete(Action<ServiceTarget> service,
                                   CancellationToken cancellationToken = default(CancellationToken))
        {
            var serviceTargetImpl = new ServiceTargetImpl();
            service(serviceTargetImpl);

            string url = string.Format("/admin/api/v1/services/{0}", serviceTargetImpl.Target);

            return base.Delete(url, cancellationToken).As<Service>(cancellationToken);
        }

    }
}