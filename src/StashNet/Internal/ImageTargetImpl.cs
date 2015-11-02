using StashNet.Contracts;

namespace StashNet.Internal
{
    internal class ImageTargetImpl :
        TargetBase,
        ImageTarget
    {
        public void Image(string name)
        {
            Target = name;
        }
    }
}