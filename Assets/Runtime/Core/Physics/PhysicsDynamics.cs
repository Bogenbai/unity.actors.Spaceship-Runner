using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Tools;
using UnityEngine;

namespace Runtime.Core.Physics
{
    public static class PhysicsDynamics
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

                if (cRigid.useGravity)
                    cRigid.force += cRigid.mass * Gravity;

                cRigid.velocity += cRigid.force / cRigid.mass * delta;
                entityTransform.position += cRigid.velocity * delta;

                cRigid.force = Vector3.zero;
            }
        }

        public static void ResolveCollisions(Layer layer, Group<ComponentSphereCollider> sphereColliders)
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

                        var cColliding = sphereColliderA.Get<ComponentColliding>();
                        if (cColliding.CollidingEntities.Contains(sphereColliderB) == false)
                            cColliding.CollidingEntities.Add(sphereColliderB);

                        cColliding = sphereColliderB.Get<ComponentColliding>();
                        if (cColliding.CollidingEntities.Contains(sphereColliderA) == false)
                            cColliding.CollidingEntities.Add(sphereColliderA);

                        var componentCollision = new ComponentCollision
                        {
                            ReceiverEntity = sphereColliderA,
                            SenderEntity = sphereColliderB,
                            CollisionPoints = collision
                        };

                        OneFramesCore.Register(layer, componentCollision);
                    }
                    else
                    {
                        HandleCollisionStop(sphereColliderA, sphereColliderB);
                        HandleCollisionStop(sphereColliderB, sphereColliderA);
                    }
                }
            }
        }

        public static void ResolveCollisions(Layer layer, Group<ComponentBoxCollider> boxColliders)
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

                        var cColliding = boxColliderA.Get<ComponentColliding>();
                        if (cColliding.CollidingEntities.Contains(boxColliderB) == false)
                            cColliding.CollidingEntities.Add(boxColliderB);

                        cColliding = boxColliderB.Get<ComponentColliding>();
                        if (cColliding.CollidingEntities.Contains(boxColliderA) == false)
                            cColliding.CollidingEntities.Add(boxColliderA);

                        var componentCollision = new ComponentCollision
                        {
                            ReceiverEntity = boxColliderA,
                            SenderEntity = boxColliderB,
                            CollisionPoints = collision
                        };

                        OneFramesCore.Register(layer, componentCollision);
                    }
                    else
                    {
                        HandleCollisionStop(boxColliderA, boxColliderB);
                        HandleCollisionStop(boxColliderB, boxColliderA);
                    }
                }
            }
        }


        public static void ResolveCollisions(Layer layer, Group<ComponentBoxCollider> boxColliders,
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

                        var cColliding = boxCollider.Get<ComponentColliding>();
                        if (cColliding.CollidingEntities.Contains(sphereCollider) == false)
                            cColliding.CollidingEntities.Add(sphereCollider);

                        cColliding = sphereCollider.Get<ComponentColliding>();
                        if (cColliding.CollidingEntities.Contains(boxCollider) == false)
                            cColliding.CollidingEntities.Add(boxCollider);

                        var componentCollision = new ComponentCollision
                        {
                            ReceiverEntity = boxCollider,
                            SenderEntity = sphereCollider,
                            CollisionPoints = collision
                        };

                        OneFramesCore.Register(layer, componentCollision);
                    }
                    else
                    {
                        HandleCollisionStop(boxCollider, sphereCollider);
                        HandleCollisionStop(sphereCollider, boxCollider);
                    }
                }
            }
        }

        private static void HandleCollisionStop(ent entity, ent toBeRemoved)
        {
            if (!entity.Has<ComponentColliding>()) return;

            var cColliding = entity.ComponentColliding();

            if (cColliding.CollidingEntities.Contains(toBeRemoved))
                cColliding.CollidingEntities.Remove(toBeRemoved);
        }
    }
}