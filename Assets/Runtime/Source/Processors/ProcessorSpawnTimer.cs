using Pixeye.Actors;
using Runtime.Source.Components.Spawn;
using Runtime.Source.Data.ScriptableObjects;
using Runtime.Source.Tools;
using Random = Pixeye.Actors.Random;


namespace Runtime.Source.Processors
{
    // Class represents a system which purpose is to send signals to spawn certain entities depending on specified spawn data
    sealed class ProcessorSpawnTimer : Processor, ITick
    {
        private readonly Group<ComponentSpawner, ComponentCanSpawn> groupSpawners = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupSpawners.length; i++)
            {
                var spawner = groupSpawners[i];
                var componentSpawner = spawner.ComponentSpawner();
                var spawnerData = componentSpawner.SpawnerData;

                if (IsSpawnCooldownOver(componentSpawner, delta))
                    RequestSpawn(spawner, componentSpawner, spawnerData);
            }
        }

        private bool IsSpawnCooldownOver(ComponentSpawner componentSpawner, float delta)
        {
            componentSpawner.SpawnAfter -= delta;

            return componentSpawner.SpawnAfter <= 0;
        }

        private void RequestSpawn(ent spawnInitiator, ComponentSpawner spawner, SpawnerData spawnerData)
        {
            spawner.SpawnAfter = spawnerData.SpawnDelay;

            var spawnPosition = spawnerData.SpawnPositions[Random.Range(0, spawnerData.SpawnPositions.Count)];

            var componentSpawn = new ComponentSpawn()
            {
                SpawnerData = spawnerData, SpawnPosition = spawnPosition, SpawnInitiator = spawnInitiator
            };

            OneFramesCore.Register(Layer, componentSpawn);
        }
    }
}