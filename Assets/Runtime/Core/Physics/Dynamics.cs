using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics
{
    public static class Dynamics
    {
        public static Vector3 Gravity = new Vector3(0, -9.81f, 0);

        public static void Step(Group<ComponentRigid> rigidbodies, float delta)
        {
            foreach (var entity in rigidbodies)
            {
                var cRigid = entity.ComponentRigid();
                var entityTransform = entity.transform;

                if (cRigid.mass <= 0)
                {
                    Debug.LogError(
                        $"Rigidbody {entityTransform.name} mass cannot be less then zero. GameObject: ",
                        entityTransform);

                    cRigid.mass = 0.01f;
                }

                cRigid.force += cRigid.mass * Gravity;

                cRigid.velocity += cRigid.force / cRigid.mass * delta;
                entityTransform.position += cRigid.velocity * delta;

                cRigid.force = Vector3.zero;
            }
        }
    }
}