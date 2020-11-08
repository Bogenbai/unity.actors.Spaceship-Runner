using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Events;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    sealed class ProcessorSpaceshipMove : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentPlayerMovementData> groupSpaceships = default;
        private Group<ComponentUserInputEvent> groupInputEvents = default;

        public void Tick(float delta)
        {
            for (int i = 0; i < groupInputEvents.length; i++)
            {
                var direction = groupInputEvents[i].ComponentUserInputEvent().MoveDirection;
                
                for (int j = 0; j < groupSpaceships.length; j++)
                {
                    var spaceship = groupSpaceships[j];
                    var componentPlayerMovementData = spaceship.ComponentPlayerMovementData();
                    var velocityX = componentPlayerMovementData.CurrentVelocityX;
                    componentPlayerMovementData.CurrentMoveDirectionNormalized = direction;
                
                    direction = new Vector3(velocityX * delta, 0, 0);
                    spaceship.transform.position += direction;
                }
                
                groupInputEvents[i].Release();
            }
        }
    }
}