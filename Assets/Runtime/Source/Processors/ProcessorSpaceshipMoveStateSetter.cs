using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class represents a system which sets a certain movement state (Throttling, Braking) to spaceships in the game 
    sealed class ProcessorSpaceshipMoveStateSetter : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentPlayerMovementData> groupPlayerMovements = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupPlayerMovements.length; i++)
            {
                var player = groupPlayerMovements[i];
                var direction = player.ComponentPlayerMovementData().CurrentMoveDirectionNormalized;

                if (direction != Vector3.zero)
                {
                    if (player.Has<ComponentBraking>())
                    {
                        player.Remove<ComponentBraking>();
                    }

                    if (!player.Has<ComponentThrottling>())
                    {
                        player.Get<ComponentThrottling>();
                    }
                }
                else
                {
                    if (!player.Has<ComponentBraking>())
                    {
                        player.Get<ComponentBraking>();
                    }

                    if (player.Has<ComponentThrottling>())
                    {
                        player.Remove<ComponentThrottling>();
                    }
                }
            }
        }
    }
}
