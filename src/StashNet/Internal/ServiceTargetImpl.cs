using StashNet.Contracts;
using StashNet.Models;

namespace StashNet.Internal
{
    internal class ServiceTargetImpl :
        TargetBase,
        ServiceTarget
    {
        public void Service(string serviceId)
        {
            Target = serviceId;
        }
    }
}