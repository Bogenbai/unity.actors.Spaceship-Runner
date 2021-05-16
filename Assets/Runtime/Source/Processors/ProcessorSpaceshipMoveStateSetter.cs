using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class represents a system which sets a certain movement state (Throttling, Braking) to spaceships in the game 
    sealed class ProcessorSpaceshipMoveStateSetter : Processor, ITick
    {
        private readonly Group<ComponentUserInput> userInputs = default;
        private readonly Group<ComponentSpaceship, ComponentMove> groupSpaceships = default;

        public void Tick(float delta)
        {
            foreach (var userInput in userInputs)
            {
                var inputDirection = userInput.ComponentUserInput().MoveDirection;

                foreach (var entity in groupSpaceships)
                {
                    if (inputDirection != Vector3.zero)
                    {
                        if (entity.Has<ComponentBraking>())
                        {
                            entity.Remove<ComponentBraking>();
                        }

                        if (entity.Has<ComponentThrottling>() == false)
                        {
                            entity.Get<ComponentThrottling>();
                        }
                    }
                    else
                    {
                        if (entity.Has<ComponentBraking>() == false)
                        {
                            entity.Get<ComponentBraking>();
                        }

                        if (entity.Has<ComponentThrottling>())
                        {
                            entity.Remove<ComponentThrottling>();
                        }
                    }
                }
            }
        }
    }
}