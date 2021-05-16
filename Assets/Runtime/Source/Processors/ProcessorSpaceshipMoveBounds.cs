using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that limits player's spaceship movement zone
    sealed class ProcessorSpaceshipMoveBounds : Processor, ITick
    {
        private Group<ComponentBounds> groupBounded = default;

        public void Tick(float delta)
        {
            foreach (var entity in groupBounded)
            {
                var cBounds = entity.ComponentBounds();
                var leftBoundX = cBounds.leftMovementBoundX;
                var rightBoundX = cBounds.rightMovementBoundX;

                if (entity.transform.position.x <= leftBoundX)
                {
                    var position = entity.transform.position;
                    position = new Vector3(leftBoundX, position.y, position.z);
                    entity.transform.position = position;
                    entity.Get<ComponentBraking>();
                }
                else if (entity.transform.position.x >= rightBoundX)
                {
                    var position = entity.transform.position;
                    position = new Vector3(rightBoundX, position.y, position.z);
                    entity.transform.position = position;
                    entity.Get<ComponentBraking>();
                }
                else entity.Get<ComponentThrottling>();
            }
        }
    }
}