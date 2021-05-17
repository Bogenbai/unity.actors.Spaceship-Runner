using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics
{
    public static class Dynamics
    {
        public static Vector3 Gravity = new Vector3(0, -9.81f, 0);

        public static void Step(
            Group<ComponentRigid> rigidbodies,
            float delta)
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
                    cRigid.force += cRigid.mass * Gravity;

                cRigid.velocity += cRigid.force / cRigid.mass * delta;
                entityTransform.position += cRigid.velocity * delta;

                cRigid.force = Vector3.zero;
            }
        }

        public static void ResolveCollisions(Group<ComponentSphereCollider> sphereColliders, float delta)
        {
            for (var i = 0; i < sphereColliders.length; i++)
            {
                var sphereColliderA = sphereColliders[i];

                for (var j = 0; j < sphereColliders.length; j++)
                {
                    var sphereColliderB = sphereColliders[j];

                    if (sphereColliderA == sphereColliderB) break;

                    var points = Collisions.FindSphereSphereCollisionPoints(
                        sphereColliderA.ComponentSphereCollider(),
                        sphereColliderA.transform,
                        sphereColliderB.ComponentSphereCollider(),
                        sphereColliderB.transform);

                    if (points.HasCollision)
                    {
                        Debug.Log("Collision");
                    }
                }
            }
        }
        
        public static void ResolveCollisions(Group<ComponentBoxCollider> boxColliders, float delta)
        {
            for (var i = 0; i < boxColliders.length; i++)
            {
                var boxColliderA = boxColliders[i];

                for (var j = 0; j < boxColliders.length; j++)
                {
                    var boxColliderB = boxColliders[j];

                    if (boxColliderA == boxColliderB) break;

                    var points = Collisions.FindBoxBoxCollisionPoints(
                        boxColliderA.ComponentBoxCollider(),
                        boxColliderA.transform,
                        boxColliderB.ComponentBoxCollider(),
                        boxColliderB.transform);

                    if (points.HasCollision)
                    {
                        Debug.Log("Collision");
                    }
                }
            }
        }
    }
}