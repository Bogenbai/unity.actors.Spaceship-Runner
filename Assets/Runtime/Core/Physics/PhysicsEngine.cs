using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics
{
    public static partial class PhysicsEngine
    {
        private static Vector3 _gravity = new Vector3(0, -9.81f, 0);

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

                if (cRigid.useGravity)
                    cRigid.force += cRigid.mass * _gravity;

                cRigid.velocity += cRigid.force / cRigid.mass * delta;
                entityTransform.position += cRigid.velocity * delta;

                cRigid.force = Vector3.zero;
            }
        }

        public static void SetGravity(float x, float y, float z)
        {
            _gravity.x = x;
            _gravity.y = y;
            _gravity.z = z;
        }
    }
}