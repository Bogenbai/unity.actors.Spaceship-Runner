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