using Pixeye.Actors;
using UnityEngine;
using Random = Pixeye.Actors.Random;


namespace Game.Source
{
    sealed class ProcessorCreateSpawnEvents : Processor, ITick
    {
        Group<ComponentSpawner, ComponentCanSpawn> groupSpawners = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupSpawners.length; i++)
            {
                var spawner = groupSpawners[i];
                var componentSpawner = spawner.ComponentSpawner();
                
                Spawn(spawner, componentSpawner, delta);
            }
        }

        private void Spawn(ent spawnInitiator, ComponentSpawner spawner, float delta)
        {
            var spawnerData = spawner.SpawnerData;
            spawner.SpawnAfter -= delta;

            if (spawner.SpawnAfter <= 0)
            {
                spawner.SpawnAfter = spawnerData.SpawnDelay;
                
                var spawnPosition = spawnerData.SpawnPositions[Random.Range(0, spawnerData.SpawnPositions.Count)];

                var spawnEventEntity = Entity.Create(DB.Prefabs.EmptyObject, Vector3.zero, true);
                spawnEventEntity.transform.gameObject.name = "Spawn Event";
                var spawnEvent = new ComponentSpawnEvent
                {
                    SpawnerData = spawnerData, SpawnPosition = spawnPosition, SpawnInitiator = spawnInitiator
                };
                spawnEventEntity.Set(spawnEvent);
            }
        }
    }
}