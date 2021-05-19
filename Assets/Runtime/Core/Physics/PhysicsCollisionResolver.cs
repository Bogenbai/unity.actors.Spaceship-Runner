using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Tools;

namespace Runtime.Core.Physics
{
    public static partial class PhysicsEngine
    {
        public static void Resolve(Layer layer, Group<ComponentSphereCollider> sphereColliders)
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
                        SetCollidingComponent(sphereColliderA, sphereColliderB);

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

        public static void Resolve(Layer layer, Group<ComponentBoxCollider> boxColliders)
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
                        SetCollidingComponent(boxColliderA, boxColliderB);

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

        public static void Resolve(Layer layer, Group<ComponentBoxCollider> boxColliders,
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
                        SetCollidingComponent(boxCollider, sphereCollider);

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

        private static void SetCollidingComponent(ent entityA, ent entityB)
        {
            var cColliding = entityA.Get<ComponentColliding>();
            if (cColliding.CollidingEntities.Contains(entityB) == false)
                cColliding.CollidingEntities.Add(entityB);

            cColliding = entityB.Get<ComponentColliding>();
            if (cColliding.CollidingEntities.Contains(entityA) == false)
                cColliding.CollidingEntities.Add(entityA);
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