using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    sealed class ProcessorSpaceshipThrottling : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentPlayerMovementData, ComponentThrottling> groupSpaceships = default;

        public void Tick(float delta)
        {
            for (int j = 0; j < groupSpaceships.length; j++)
            {
                var spaceship = groupSpaceships[j];
                var componentMovementData = spaceship.ComponentPlayerMovementData();
                var movementData = componentMovementData.Parameters;
                var speedX = componentMovementData.CurrentVelocityX;
                var direction = componentMovementData.CurrentMoveDirectionNormalized;
                var acceleration = movementData.Acceleration;

                if (direction != Vector3.zero)
                {
                    if (direction.x > 0)
                    {
                        if (speedX < 0)
                            acceleration *= movementData.AccelerationBrakingScale;
                        speedX += acceleration * delta;
                    }

                    if (direction.x < 0)
                    {
                        if (speedX > 0)
                            acceleration *= movementData.AccelerationBrakingScale;
                        speedX -= acceleration * delta;
                    }

                    if (speedX > movementData.MaxVelocityX)
                        speedX = movementData.MaxVelocityX;
                    else if (speedX < -movementData.MaxVelocityX)
                        speedX = -movementData.MaxVelocityX;
                }

                componentMovementData.CurrentVelocityX = speedX;
            }
        }
    }
}