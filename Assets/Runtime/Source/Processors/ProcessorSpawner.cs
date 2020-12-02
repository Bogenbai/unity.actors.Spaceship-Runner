using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Signals;

namespace Runtime.Source.Processors
{
    // Class represents a system which is handles spawn signals and spawns appropriate entities using the specified data
    internal sealed class ProcessorSpawner : Processor<SignalSpawn>
    {
        public override void ReceiveEcs(ref SignalSpawn signal, ref bool stopSignal)
        {
            var spawnerData = signal.SpawnerData;

            var spawnedActor = Layer.Actor.Create(
                spawnerData.Prefab, signal.SpawnPosition, true);

            var destroyData = spawnerData.DestroyData;

            if (destroyData != null)
            {
                spawnedActor.entity.Get<ComponentDestroyable>();
                spawnedActor.entity.ComponentDestroyable().DestroyData = destroyData;
            }

            spawnedActor.entity.transform.parent = signal.SpawnInitiator.transform;
        }
    }
}