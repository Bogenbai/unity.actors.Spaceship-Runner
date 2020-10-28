using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
    internal sealed class ProcessorSpawner : Processor, ITick
    {
        private Group<ComponentSpawnEvent> groupSpawnEvents = default;

        public void Tick(float delta)
        {
            for (int i = 0; i < groupSpawnEvents.length; i++)
            {
                var spawnEvent = groupSpawnEvents[i];
                var componentSpawnEvent = spawnEvent.ComponentSpawnEvent();
                var spawnerData = spawnEvent.ComponentSpawnEvent().SpawnerData;

                var spawnedActor = Layer.Actor.Create(
                    spawnerData.Prefab, componentSpawnEvent.SpawnPosition, true);

                var destroyData = spawnerData.DestroyData;

                if (destroyData != null)
                {
                    spawnedActor.entity.Get<ComponentDestroyable>();
                    spawnedActor.entity.ComponentDestroyable().DestroyData = destroyData;
                }

                spawnedActor.entity.transform.parent = componentSpawnEvent.SpawnInitiator.transform;

                spawnEvent.Release();
            }
        }
    }
}