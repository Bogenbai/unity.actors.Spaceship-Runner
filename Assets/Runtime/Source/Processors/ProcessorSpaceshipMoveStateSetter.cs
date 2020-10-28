using Pixeye.Actors;
using UnityEngine;

namespace Game.Source
{
    sealed class ProcessorSpaceshipMoveStateSetter : Processor, ITick
    {
        Group<ComponentSpaceship, ComponentPlayerMovementData> groupPlayerMovements = default;

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
