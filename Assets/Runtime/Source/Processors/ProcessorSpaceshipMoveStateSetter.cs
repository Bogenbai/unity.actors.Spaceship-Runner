using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class represents a system which sets a certain movement state (Throttling, Braking) to spaceships in the game 
    sealed class ProcessorSpaceshipMoveStateSetter : Processor, ITick
    {
        private Group<ComponentUserInput> userInputs = default;
        private readonly Group<ComponentMove, ComponentMovementData> groupPlayerMovements = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < userInputs.length; i++)
            {
                var inputDirection = userInputs[i].ComponentUserInputMarker().MoveDirection;

                for (var j = 0; j < groupPlayerMovements.length; j++)
                {
                    var player = groupPlayerMovements[j];

                    if (inputDirection != Vector3.zero)
                    {
                        if (player.Has<ComponentBraking>())
                        {
                            player.Remove<ComponentBraking>();
                        }

                        if (player.Has<ComponentThrottling>() == false)
                        {
                            player.Get<ComponentThrottling>();
                        }
                    }
                    else
                    {
                        if (player.Has<ComponentBraking>() == false)
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
}