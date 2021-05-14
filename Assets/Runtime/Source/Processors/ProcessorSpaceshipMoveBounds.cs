using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that limits player's spaceship movement zone
    sealed class ProcessorSpaceshipMoveBounds : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentPlayerMovementData> groupSpaceships = default;

        public void Tick(float delta)
        {
            for (int i = 0; i < groupSpaceships.length; i++)
            {
                var spaceship = groupSpaceships[i];
                var movementData = spaceship.ComponentPlayerMovementData();
                var speedX = movementData.currentVelocityX;
                var direction = movementData.currentMoveDirectionNormalized;
                var acceleration = movementData.Parameters.Acceleration;
                var accelerationBrakingScale = movementData.Parameters.AccelerationBrakingScale;
                var leftBoundX = movementData.Parameters.LeftMovementBoundX;
                var rightBoundX = movementData.Parameters.RightMovementBoundX;

                if (spaceship.transform.position.x <= leftBoundX && speedX < 0)
                {
                    var position = spaceship.transform.position;
                    position = new Vector3(leftBoundX, position.y, position.z);
                    spaceship.transform.position = position;

                    if (direction.x < 0 && speedX < -1f)
                        speedX += acceleration * accelerationBrakingScale * delta;
                    else if (direction.x < 0)
                        speedX += acceleration * delta;
                }

                if (spaceship.transform.position.x > rightBoundX)
                {
                    var position = spaceship.transform.position;
                    position = new Vector3(rightBoundX, position.y, position.z);
                    spaceship.transform.position = position;

                    if (direction.x > 0 && speedX > 1f)
                        speedX -= acceleration * accelerationBrakingScale * delta;
                    else if (direction.x > 0)
                        speedX -= acceleration * delta;
                }

                movementData.currentVelocityX = speedX;
            }
        }
    }
}