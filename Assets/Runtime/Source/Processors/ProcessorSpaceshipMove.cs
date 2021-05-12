using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Markers;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that moves player spaceship depending on it's movement data
    sealed class ProcessorSpaceshipMove : Processor, ITickFixed
    {
        private Group<ComponentSpaceship, ComponentPlayerMovementData> groupSpaceships = default;
        private Group<ComponentUserInputMarker> groupInputMarkers = default;

        public void TickFixed(float delta)
        {
            for (int i = 0; i < groupInputMarkers.length; i++)
            {
                var direction = groupInputMarkers[i].ComponentUserInputMarker().MoveDirection;

                for (int j = 0; j < groupSpaceships.length; j++)
                {
                    var spaceship = groupSpaceships[j];
                    var componentPlayerMovementData = spaceship.ComponentPlayerMovementData();
                    var velocityX = componentPlayerMovementData.CurrentVelocityX;
                    componentPlayerMovementData.CurrentMoveDirectionNormalized = direction;

                    direction = new Vector3(velocityX * delta, 0, 0);
                    spaceship.transform.position += direction;
                }
            }
        }
    }
}