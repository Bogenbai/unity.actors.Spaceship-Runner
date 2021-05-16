using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that limits player's spaceship movement zone
    sealed class ProcessorSpaceshipMoveBounds : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentMovementData, ComponentRigidbody> groupSpaceships = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupSpaceships.length; i++)
            {
                var entity = groupSpaceships[i];
                var movementData = entity.ComponentMovementData();
                var leftBoundX = movementData.Parameters.LeftMovementBoundX;
                var rightBoundX = movementData.Parameters.RightMovementBoundX;

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