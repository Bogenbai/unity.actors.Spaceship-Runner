using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics.Processors
{
    sealed class ProcessorCollisionVisualizer : Processor, ITick
    {
        private readonly Group<ComponentColliding> groupColliding = default;

        public void Tick(float dt)
        {
            foreach (var entity in groupColliding)
            {
                var cColliding = entity.ComponentColliding();
                var renderer = entity.transform.GetComponent<MeshRenderer>();

                if (renderer != null)
                {
                    if (cColliding.CollidingEntities.Count > 0)
                    {
                        renderer.material.color = Color.red;
                    }
                    else
                    {
                        renderer.material.color = Color.white;
                    }
                }
            }
        }
    }
}