using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Runtime.Source.Processors
{
    sealed class ProcessorRigidbodyRandomRotator : Processor, ITick
    {
        private Group<ComponentRandomRotatable, ComponentRigidbody> groupRigidbodyRotatable = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupRigidbodyRotatable.length; i++)
            {
                var entity = groupRigidbodyRotatable[i];
                var rigidbody = entity.ComponentRigidbody().Rigidbody;

                var tumble = entity.ComponentRandomRotatable().Tumble;
                RandomRotate(rigidbody, tumble);
                entity.Remove<ComponentRandomRotatable>();
            }
        }

        private void RandomRotate(Rigidbody rigidbody, float tumble)
        {
            rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
        }
    }
}