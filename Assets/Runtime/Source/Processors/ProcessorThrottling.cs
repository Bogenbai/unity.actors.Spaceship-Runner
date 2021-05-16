using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class is a system that sets the player's spaceship movement data when it's throttles
    sealed class ProcessorThrottling : Processor, ITick
    {
        private Group<ComponentUserInput> userInputs = default;

        private Group<ComponentMove, ComponentMovementData, ComponentThrottling, ComponentRigidbody> groupThrottles =
            default;

        public void Tick(float delta)
        {
            foreach (var userInput in userInputs)
            {
                var inputDirection = userInput.ComponentUserInput().MoveDirection;

                foreach (var throttleEntity in groupThrottles)
                {
                    var cMovementData = throttleEntity.ComponentMovementData();
                    var cMove = throttleEntity.ComponentMove();
                    var rigidbody = throttleEntity.ComponentRigidbody().Rigidbody;
                    var movementData = cMovementData.Parameters;
                    var speed = cMove.speed;
                    var acceleration = movementData.Acceleration;

                    if (inputDirection.x != 0)
                    {
                        if ((rigidbody.velocity.x < 0 && inputDirection.x > 0 ||
                             rigidbody.velocity.x > 0 && inputDirection.x < 0) &&
                            speed > 0)
                        {
                            speed = -speed;
                        }

                        if (speed < 0)
                            acceleration = movementData.InterpolationAcceleration;

                        speed += acceleration * delta;
                    }

                    if (speed > movementData.MaxVelocityX)
                        speed = movementData.MaxVelocityX;

                    cMove.movementDirection = inputDirection;
                    cMove.speed = speed;
                }
            }
        }
    }
}