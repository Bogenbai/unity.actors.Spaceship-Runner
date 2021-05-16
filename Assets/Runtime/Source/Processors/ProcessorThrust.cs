using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that rotates player's spaceship depending on it's movement
    sealed class ProcessorThrust : Processor, ITick
    {
        private Group<ComponentMovementData, ComponentMove, ComponentThrust> groupSpaceships =
            default;

        public void Tick(float delta)
        {
            foreach (var spaceship in groupSpaceships)
            {
                var movementData = spaceship.ComponentMovementData();
                var cThrust = spaceship.ComponentThrust();
                var speed = spaceship.ComponentMove().speed;
                var thrustRotationScale = movementData.Parameters.ThrustRotationScale;

                if (spaceship.ComponentMove().movementDirection.x < 0)
                {
                    speed = -speed;
                }

                cThrust.thrustRotation = Mathf.SmoothDamp(
                    cThrust.thrustRotation,
                    -speed * thrustRotationScale,
                    ref cThrust.thrustRotationVelocity,
                    movementData.Parameters.ThrustRotationSmooth);

                spaceship.transform.rotation = Quaternion.Euler(0, 0, cThrust.thrustRotation);
            }
        }
    }
}