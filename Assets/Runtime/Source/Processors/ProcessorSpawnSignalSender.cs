using Pixeye.Actors;
using Runtime.Source.Components.Spawn;
using Runtime.Source.Signals;
using Random = Pixeye.Actors.Random;


namespace Runtime.Source.Processors
{
    sealed class ProcessorSpawnSignalSender : Processor, ITick
    {
        private Group<ComponentSpawner, ComponentCanSpawn> groupSpawners = default;

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

                var signal = new SignalSpawn
                {
                    SpawnerData = spawnerData, SpawnPosition = spawnPosition, SpawnInitiator = spawnInitiator
                };
                Ecs.Send(signal);
            }
        }
    }
}