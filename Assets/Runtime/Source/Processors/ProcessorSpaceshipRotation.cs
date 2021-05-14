using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that rotates player's spaceship depending on it's movement
    sealed class ProcessorSpaceshipRotation : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentPlayerMovementData> groupSpaceships = default;

        public void Tick(float delta)
        {
            for (int i = 0; i < groupSpaceships.length; i++)
            {
                var spaceship = groupSpaceships[i];
                var movementData = spaceship.ComponentPlayerMovementData();
                var speedX = movementData.currentVelocityX;
                var thrustRotationScale = movementData.Parameters.ThrustRotationScale;

                movementData.currentThrustRotation = Mathf.SmoothDamp(movementData.currentThrustRotation,
                    -speedX * thrustRotationScale, ref movementData.currentThrustRotationVelocity,
                    movementData.Parameters.ThrustRotationSmooth);

               spaceship.transform.rotation = Quaternion.Euler(0, 0, movementData.currentThrustRotation);
            }
        }
    }
}