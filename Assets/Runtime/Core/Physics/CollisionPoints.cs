using UnityEngine;

namespace Runtime.Core.Physics
{
    public class CollisionPoints
    {
        public Vector3 A { get; }
        public Vector3 B { get; }
        public Vector3 Normal { get; }
        public float Depth { get; }
        public bool HasCollision { get; }

        public CollisionPoints(Vector3 a, Vector3 b, Vector3 normal, float depth, bool hasCollision)
        {
            A = a;
            B = b;
            Normal = normal;
            Depth = depth;
            HasCollision = hasCollision;
        }
    }
}