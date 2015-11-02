using System;
using System.Threading;
using System.Threading.Tasks;
using StashNet.Contracts;
using StashNet.Models;

namespace StashNet.Resources
{
    public interface EventResources 
        : ResourceClient
    {
        /// <summary>
        /// Returns all events associated with a given service in reverse chronological order.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<EventRoot> GetAll(Action<ServiceTarget> service, 
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new event for the given service and returns the newly created event object. 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="characteristics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Event> New(Action<ServiceTarget> service, Action<EventCharacteristics> characteristics,
                                 CancellationToken cancellationToken = default(CancellationToken));

    }
}