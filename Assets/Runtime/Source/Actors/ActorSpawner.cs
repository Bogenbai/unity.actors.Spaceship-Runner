using Pixeye.Actors;


namespace Game.Source
{
    public class ActorSpawner : Actor
    {
        [Sirenix.OdinInspector.FoldoutGroup("Components", true)]
        public ComponentSpawner componentSpawner;
        [Sirenix.OdinInspector.FoldoutGroup("Components", true)]
        public ComponentCanSpawn componentCanSpawn;

        protected override void Setup()
        {
            entity.Set(componentSpawner);
            entity.Set(componentCanSpawn);
        }
    }
}