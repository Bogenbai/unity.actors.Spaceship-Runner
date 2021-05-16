using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Source.Processors
{
    // Class is a system that rotates entities in a random direction
    sealed class ProcessorRigidbodyRandomRotator : Processor
    {
        private readonly Group<ComponentRandomRotatable, ComponentRigidbody> groupRotatable = default;

        public override void HandleEcsEvents()
        {
            foreach (var entity in groupRotatable.added)
            {
                var rigidbody = entity.ComponentRigidbody().Rigidbody;
                var tumble = entity.ComponentRandomRotatable().Tumble;
                
                RandomRotate(rigidbody, tumble);
            }
        }

        private void RandomRotate(Rigidbody rigidbody, float tumble)
        {
            rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
        }
    }
}