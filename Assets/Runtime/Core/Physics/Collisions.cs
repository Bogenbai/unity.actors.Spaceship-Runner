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

            var depth = (float) Math.Sqrt(
                (positionA.x - positionB.x) * (positionA.x - positionB.x) +
                (positionA.y - positionB.y) * (positionA.y - positionB.y) +
                (positionA.z - positionB.z) * (positionA.z - positionB.z));

            var hasCollision = depth < (a.Radius + b.Radius);
            var normal = positionA - positionB;

            return new CollisionPoints(positionA, positionB, normal, depth, hasCollision);
        }

        public static CollisionPoints FindBoxBoxCollisionPoints(
            ComponentBoxCollider a, Transform ta,
            ComponentBoxCollider b, Transform tb)
        {
            var positionA = ta.position;
            var positionB = tb.position;

            var aMinX = positionA.x - a.halfWidth;
            var aMaxX = positionA.x + a.halfWidth;

            var aMinY = positionA.y - a.halfHeight;
            var aMaxY = positionA.y + a.halfHeight;

            var aMinZ = positionA.z - a.halfLength;
            var aMaxZ = positionA.z + a.halfLength;

            var bMinX = positionB.x - b.halfWidth;
            var bMaxX = positionB.x + b.halfWidth;

            var bMinY = positionB.y - b.halfHeight;
            var bMaxY = positionB.y + b.halfHeight;

            var bMinZ = positionB.z - b.halfLength;
            var bMaxZ = positionB.z + b.halfLength;

            var hasCollision = (aMinX <= bMaxX && aMaxX >= bMinX) &&
                               (aMinY <= bMaxY && aMaxY >= bMinY) &&
                               (aMinZ <= bMaxZ && aMaxZ >= bMinZ);

            var normal = positionA - positionB;
            var depth = 0; // Depth with boxes is hard :(

            return new CollisionPoints(positionA, positionB, normal, depth, hasCollision);
        }

        public static CollisionPoints FindSphereBoxCollisionPoints(
            ComponentSphereCollider a, Transform ta,
            ComponentBoxCollider b, Transform tb)
        {
            var positionA = ta.position;
            var positionB = tb.position;
            
            var bMinX = positionB.x - b.halfWidth;
            var bMaxX = positionB.x + b.halfWidth;

            var bMinY = positionB.y - b.halfHeight;
            var bMaxY = positionB.y + b.halfHeight;

            var bMinZ = positionB.z - b.halfLength;
            var bMaxZ = positionB.z + b.halfLength;
            
            var x = Math.Max(bMinX, Math.Min(positionA.x, bMaxX));
            var y = Math.Max(bMinY, Math.Min(positionA.y, bMaxY));
            var z = Math.Max(bMinZ, Math.Min(positionA.z, bMaxZ));

            var depth = (float)Math.Sqrt(
                (x - positionA.x) * (x - positionA.x) +
                (y - positionA.y) * (y - positionA.y) +
                (z - positionA.z) * (z - positionA.z));

            var hasCollision = depth < a.Radius;
            var normal = positionA - positionB;
            
            return new CollisionPoints(positionA, positionB, normal, depth, hasCollision);
        }
    }
}