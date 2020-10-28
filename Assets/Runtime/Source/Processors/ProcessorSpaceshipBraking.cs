using System;
using Pixeye.Actors;
using Runtime.Source.Tools;


namespace Game.Source
{
    sealed class ProcessorSpaceshipBraking : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentPlayerMovementData, ComponentBraking> groupSpaceships = default;

        public void Tick(float delta)
        {
            for (int j = 0; j < groupSpaceships.length; j++)
            {
                var spaceship = groupSpaceships[j];
                var componentMovementData = spaceship.ComponentPlayerMovementData();
                var movementData = componentMovementData.Parameters;
                var speedX = componentMovementData.CurrentVelocityX;
                var acceleration = movementData.InterpolationAcceleration;

                if (speedX > Toolbox.Tolerance || speedX < -Toolbox.Tolerance)
                {
                    var value = Toolbox.InterpolateValueToZeroSmooth(acceleration, speedX);
                    value = Math.Abs(value);

                    if (speedX > 0)
                    {
                        speedX -= value * Time.deltaTime;
                    }
                    else if (speedX < 0)
                    {
                        speedX += value * Time.deltaTime;
                    }

                    componentMovementData.CurrentVelocityX = speedX;
                }
                else componentMovementData.CurrentVelocityX = 0;
            }
        }
    }
}