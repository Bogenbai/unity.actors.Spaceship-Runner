using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that limits player's spaceship movement zone
    sealed class ProcessorSpaceshipMoveBounds : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentMovementData> groupSpaceships = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupSpaceships.length; i++)
            {
                var spaceship = groupSpaceships[i];
                var movementData = spaceship.ComponentMovementData();
                var leftBoundX = movementData.Parameters.LeftMovementBoundX;
                var rightBoundX = movementData.Parameters.RightMovementBoundX;

                if (spaceship.transform.position.x <= leftBoundX)
                {
                    var position = spaceship.transform.position;
                    position = new Vector3(leftBoundX, position.y, position.z);
                    spaceship.transform.position = position;
                }

                if (spaceship.transform.position.x >= rightBoundX)
                {
                    var position = spaceship.transform.position;
                    position = new Vector3(rightBoundX, position.y, position.z);
                    spaceship.transform.position = position;
                }
            }
        }
    }
}