using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class is a system that sets the player's spaceship movement data when it's braking
    sealed class ProcessorBraking : Processor, ITick
    {
        private Group<ComponentMove, ComponentMovementData, ComponentBraking> groupBraking = default;

        public void Tick(float delta)
        {
            foreach (var entity in groupBraking)
            {
                var cMovementData = entity.ComponentMovementData();
                var cMove = entity.ComponentMove();
                var movementData = cMovementData.Parameters;
                var acceleration = movementData.AccelerationBrakingScale;

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