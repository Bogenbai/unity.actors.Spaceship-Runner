using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Spawn;

namespace Runtime.Source.Processors
{
    // Class represents a system which is handles spawn signals and spawns appropriate entities using the specified data
    internal sealed class ProcessorSpawner : Processor, ITick
    {
        private readonly Group<ComponentSpawn> spawnSignals = default;

        public void Tick(float dt)
        {
            for (var i = 0; i < spawnSignals.length; i++)
            {
                var componentSpawn = spawnSignals[i].ComponentSpawn();
                var spawnerData = componentSpawn.SpawnerData;

                var spawnedActor = Layer.Actor.Create(
                    spawnerData.Prefab, componentSpawn.SpawnPosition, true);

                var destroyData = spawnerData.DestroyData;

                if (destroyData != null)
                {
                    spawnedActor.entity.Get<ComponentDestroyable>();
                    spawnedActor.entity.ComponentDestroyable().DestroyData = destroyData;
                }

                spawnedActor.entity.transform.parent = componentSpawn.SpawnInitiator.transform;
            }
        }
    }
}