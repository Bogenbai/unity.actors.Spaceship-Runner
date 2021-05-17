using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class is a system that sets the player's spaceship movement data when it's braking
    sealed class ProcessorSpaceshipBraking : Processor, ITick
    {
        private readonly Group<ComponentSpaceship, ComponentMove, ComponentBraking> groupBraking = default;

        public void Tick(float delta)
        {
            foreach (var entity in groupBraking)
            {
                var parameters = entity.ComponentSpaceship().Parameters;
                var cMove = entity.ComponentMove();
                var acceleration = parameters.AccelerationBrakingScale;

                if (cMove.speed != 0)
                {
                    if (cMove.speed > 0)
                    {
                        cMove.speed -= acceleration * delta;
                    }
                    else cMove.speed = 0;
                }
            }
        }
    }
}