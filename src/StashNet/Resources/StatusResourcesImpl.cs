using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using StashNet.Extensions;
using StashNet.Models;
using StashNet.Contracts;
using System;
using StashNet.Internal;

namespace StashNet.Resources
{
    internal class StatusResourcesImpl :
        StashboardResourcesBase,
        StatusResources
    {
        public StatusResourcesImpl(RestClient client) :
            base(client)
        {
        }

        public Task<StatusRoot> GetAll(CancellationToken cancellationToken = default(CancellationToken))
        {
            const string url = "/admin/api/v1/statuses";
            return base.Get(url, cancellationToken).As<StatusRoot>(cancellationToken);
        }

        public Task<Status> Get(Action<StatusTarget> status, CancellationToken cancellationToken = default(CancellationToken))
        {
            var statusTargetImpl = new StatusTargetImpl();
            status(statusTargetImpl);

            string url = string.Format("/api/v1/statuses/{0}", statusTargetImpl.Target);
            return base.Get(url, cancellationToken).As<Status>(cancellationToken);
        }

        public Task<Status> New(Action<StatusCharacteristics> characteristics, Action<LevelTarget> level, 
            Action<ImageTarget> image, CancellationToken cancellationToken = default(CancellationToken))
        {
            var statusCharacteristics = new StatusCharacteristicsImpl();
            characteristics(statusCharacteristics);

            var levelTargetImpl = new LevelTargetImpl();
            level(levelTargetImpl);

            var imageTargetImpl = new ImageTargetImpl();
            image(imageTargetImpl);

            string url = string.Format("/api/v1/statuses", statusCharacteristics, levelTargetImpl.Target, imageTargetImpl.Target);

            return base.Post(url, cancellationToken).As<Status>(cancellationToken);
        }

        public Task<Status> Delete(Action<StatusTarget> status, CancellationToken cancellationToken = default(CancellationToken))
        {
            var statusTargetImpl = new StatusTargetImpl();
            status(statusTargetImpl);

            string url = ("/api/v1/statuses");

            return base.Post(url, cancellationToken).As<Status>(cancellationToken);
        }
    }
}