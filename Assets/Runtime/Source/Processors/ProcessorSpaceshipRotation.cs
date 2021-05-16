using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that rotates player's spaceship depending on it's movement
    sealed class ProcessorSpaceshipRotation : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentMovementData, ComponentMove> groupSpaceships = default;

        public void Tick(float delta)
        {
            foreach (var spaceship in groupSpaceships)
            {
                var movementData = spaceship.ComponentMovementData();
                var speed = spaceship.ComponentMove().speed;
                var thrustRotationScale = movementData.Parameters.ThrustRotationScale;

                if (spaceship.ComponentMove().movementDirection.x < 0)
                {
                    speed = -speed;
                }

                movementData.thrustRotation = Mathf.SmoothDamp(
                    movementData.thrustRotation,
                    -speed * thrustRotationScale,
                    ref movementData.thrustRotationVelocity,
                    movementData.Parameters.ThrustRotationSmooth);

                spaceship.transform.rotation = Quaternion.Euler(0, 0, movementData.thrustRotation);
            }
        }
    }
}