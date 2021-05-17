using System;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics
{
    public static class Collisions
    {
        public static CollisionPoints FindSphereSphereCollisionPoints(
            ComponentSphereCollider a, Transform ta,
            ComponentSphereCollider b, Transform tb)
        {
            var positionA = ta.position;
            var positionB = tb.position;

            var distance = (float) Math.Sqrt(
                (positionA.x - positionB.x) * (positionA.x - positionB.x) +
                (positionA.y - positionB.y) * (positionA.y - positionB.y) +
                (positionA.z - positionB.z) * (positionA.z - positionB.z));

            var hasCollision = distance < (a.Radius + b.Radius);
            var normal = positionA - positionB;

            return new CollisionPoints(positionA, positionB, normal, distance, hasCollision);
        }

        public static CollisionPoints FindBoxBoxCollisionPoints(
            ComponentBoxCollider a, Transform ta,
            ComponentBoxCollider b, Transform tb)
        {
            var positionA = ta.position;
            var positionB = tb.position;

            var hasCollision = -a.HalfWidth <= b.HalfWidth && a.HalfWidth >= -b.HalfWidth && 
                               -a.HalfHeight <= b.HalfHeight && a.HalfHeight >= -b.HalfHeight && 
                               -a.HalfLength <= b.HalfLength && a.HalfLength >= -b.HalfLength;

            var normal = positionA - positionB;
            var depth = 0; // How to calculate it with box colliders??? Custom 3d physics hard :(

            return new CollisionPoints(positionA, positionB, normal, depth, hasCollision);
        }
    }
}