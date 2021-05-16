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
            foreach (var entity in spawnSignals)
            {
                var cSpawn = entity.ComponentSpawn();
                var spawnerData = cSpawn.SpawnerData;

                var spawnedActor = Layer.Actor.Create(
                    spawnerData.Prefab, cSpawn.SpawnPosition, true);

                var destroyData = spawnerData.DestroyData;

                if (destroyData != null)
                {
                    var cDestroyable = spawnedActor.entity.Get<ComponentDestroyable>();
                    cDestroyable.DestroyData = destroyData;
                }

                spawnedActor.entity.transform.parent = cSpawn.SpawnInitiator.transform;
            }
        }
    }
}