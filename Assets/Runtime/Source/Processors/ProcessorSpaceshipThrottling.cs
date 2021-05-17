using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class is a system that sets the player's spaceship movement data when it's throttles
    sealed class ProcessorSpaceshipThrottling : Processor, ITick
    {
        private readonly Group<ComponentSpaceship, ComponentThrottling, ComponentRigidbody> groupThrottles = default;

        public void Tick(float delta)
        {
            foreach (var throttleEntity in groupThrottles)
            {
                var spaceship = throttleEntity.ComponentSpaceship();
                var cMove = throttleEntity.ComponentMove();
                var rigidbody = throttleEntity.ComponentRigidbody().Rigidbody;
                var parameters = spaceship.Parameters;
                var speed = cMove.speed;
                var acceleration = parameters.Acceleration;

                if (cMove.moveDirection.x != 0)
                {
                    if ((rigidbody.velocity.x < 0 && cMove.moveDirection.x > 0 ||
                         rigidbody.velocity.x > 0 && cMove.moveDirection.x < 0) &&
                        speed > 0)
                    {
                        speed = -speed;
                    }

                    if (speed < 0)
                        acceleration = parameters.InterpolationAcceleration;

                    speed += acceleration * delta;
                }

                if (speed > parameters.MaxVelocityX)
                    speed = parameters.MaxVelocityX;

                cMove.speed = speed;
            }
        }
    }
}