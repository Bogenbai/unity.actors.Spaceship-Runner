using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that rotates player's spaceship depending on it's movement
    sealed class ProcessorSpaceshipThrust : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentMove, ComponentThrust> groupSpaceships = default;

        public void Tick(float delta)
        {
            foreach (var entity in groupSpaceships)
            {
                var parameters = entity.ComponentSpaceship().Parameters;
                var cThrust = entity.ComponentThrust();
                var speed = entity.ComponentMove().speed;
                var thrustRotationScale = parameters.ThrustRotationScale;

                if (entity.ComponentMove().moveDirection.x < 0)
                {
                    speed = -speed;
                }

                cThrust.thrustRotation = Mathf.SmoothDamp(
                    cThrust.thrustRotation,
                    -speed * thrustRotationScale,
                    ref cThrust.thrustRotationVelocity,
                    parameters.ThrustRotationSmooth);

                entity.transform.rotation = Quaternion.Euler(0, 0, cThrust.thrustRotation);
            }
        }
    }
}