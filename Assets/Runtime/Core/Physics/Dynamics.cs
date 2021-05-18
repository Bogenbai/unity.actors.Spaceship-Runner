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

        public static void ResolveCollisions(Group<ComponentSphereCollider> sphereColliders)
        {
            for (var i = 0; i < sphereColliders.length; i++)
            {
                var sphereColliderA = sphereColliders[i];

                for (var j = 0; j < sphereColliders.length; j++)
                {
                    var sphereColliderB = sphereColliders[j];

                    if (sphereColliderA == sphereColliderB) break;

                    var collision = Collisions.FindSphereSphereCollisionPoints(
                        sphereColliderA.ComponentSphereCollider(),
                        sphereColliderA.transform,
                        sphereColliderB.ComponentSphereCollider(),
                        sphereColliderB.transform);

                    if (collision.HasCollision)
                    {
                        Debug.Log("Spheres collision");
                    }
                }
            }
        }

        public static void ResolveCollisions(Group<ComponentBoxCollider> boxColliders)
        {
            for (var i = 0; i < boxColliders.length; i++)
            {
                var boxColliderA = boxColliders[i];

                for (var j = 0; j < boxColliders.length; j++)
                {
                    var boxColliderB = boxColliders[j];

                    if (boxColliderA == boxColliderB) break;

                    var collision = Collisions.FindBoxBoxCollisionPoints(
                        boxColliderA.ComponentBoxCollider(),
                        boxColliderA.transform,
                        boxColliderB.ComponentBoxCollider(),
                        boxColliderB.transform);

                    if (collision.HasCollision)
                    {
                        Debug.Log("Boxes collision");
                    }
                }
            }
        }

        public static void ResolveCollisions(
            Group<ComponentBoxCollider> boxColliders,
            Group<ComponentSphereCollider> sphereColliders)
        {
            for (var i = 0; i < boxColliders.length; i++)
            {
                var boxCollider = boxColliders[i];

                for (var j = 0; j < sphereColliders.length; j++)
                {
                    var sphereCollider = sphereColliders[j];

                    var collision = Collisions.FindSphereBoxCollisionPoints(
                        sphereCollider.ComponentSphereCollider(),
                        sphereCollider.transform,
                        boxCollider.ComponentBoxCollider(),
                        boxCollider.transform);

                    if (collision.HasCollision)
                    {
                        Debug.Log("Box and sphere collision");
                    }
                }
            }
        }
    }
}