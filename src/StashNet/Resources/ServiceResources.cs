using StashNet.Contracts;
using StashNet.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StashNet.Resources
{
    public interface ServiceResources :
        ResourceClient
    {

        /// <summary>
        /// Returns a list of all current services tracked by Stashboard
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ServiceRoot> GetAll(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new service and returns the new service object.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Service> New(Action<ServiceCharacteristics> behavior,
                                 CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a service and returns the deleted service object
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Service> Delete(Action<ServiceTarget> service,
                                    CancellationToken cancellationToken = default(CancellationToken));

    }
}