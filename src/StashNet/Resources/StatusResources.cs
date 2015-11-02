using System.Threading;
using System.Threading.Tasks;
using StashNet.Models;
using StashNet.Contracts;
using System;

namespace StashNet.Resources
{
    /// <summary>
    /// Status resource represents a possible status for a service.
    /// </summary>
    public interface StatusResources
        : ResourceClient
    {
        /// <summary>
        /// Returns all service statuses
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<StatusRoot> GetAll(
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns a status object
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Status> Get(Action<StatusTarget> status,
                       CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new status and returns this newly created status.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Status> New(Action<StatusCharacteristics> characteristics, Action<LevelTarget> level, 
            Action<ImageTarget> image, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete the given status and return the deleted status
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Status> Delete(Action<StatusTarget> status,
               CancellationToken cancellationToken = default(CancellationToken));


    }
}
