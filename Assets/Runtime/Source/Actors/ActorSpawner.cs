using Pixeye.Actors;
using Runtime.Source.Components.Spawn;

namespace Runtime.Source.Actors
{
    public class ActorSpawner : Actor
    {
        [FoldoutGroup("Components", true)]
        public ComponentSpawner componentSpawner;
        [FoldoutGroup("Components", true)]
        public ComponentCanSpawn componentCanSpawn;

        protected override void Setup()
        {
            entity.Set(componentSpawner);
            entity.Set(componentCanSpawn);
        }
    }
}