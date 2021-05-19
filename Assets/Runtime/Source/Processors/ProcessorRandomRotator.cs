using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Source.Processors
{
    // Class is a system that rotates entities in a random direction
    sealed class ProcessorRandomRotator : Processor, ITick
    {
        private readonly Group<ComponentRandomRotatable> groupRotatable = default;
        
        // public override void HandleEcsEvents()
        // {
        //     foreach (var entity in groupRotatable.added)
        //     {
        //         var rigidbody = entity.ComponentRigidbody().Rigidbody;
        //         var tumble = entity.ComponentRandomRotatable().Tumble;
        //         
        //         RandomRotate(rigidbody, tumble);
        //     }
        // }
        
        // private void RandomRotate(Rigidbody rigidbody, float tumble)
        // {
        //     rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
        // }

        public void Tick(float dt)
        {
            foreach (var entity in groupRotatable)
            {
                var cRotatable = entity.ComponentRandomRotatable();
                entity.transform.rotation *= Quaternion.Euler(GetRandomVector3() * cRotatable.Tumble);
            }
        }
        
        private Vector3 GetRandomVector3()
        {
            return new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        }
    }
}