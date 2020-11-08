using Pixeye.Actors;
using Runtime.Source.Signals;


namespace Game.Source
{
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