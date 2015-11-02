using StashNet.Contracts;

namespace StashNet.Internal
{
    internal class LevelTargetImpl :
        TargetBase,
        LevelTarget
    {
        public void Level(string name)
        {
            Target = name;
        }
    }
}