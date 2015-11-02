using StashNet.Contracts;

namespace StashNet.Internal
{
    internal class StatusTargetImpl :
        TargetBase,
        StatusTarget
    {
        public void Status(string name)
        {
            Target = name;
        }
    }
}