using UnityEngine;

namespace Runtime.Core.Physics
{
    public class CollisionPoints
    {
        public Vector3 A { get; private set; }
        public Vector3 B { get; private set; }
        public Vector3 Normal { get; private set; }
        public float Depth { get; private set; }
        public bool HasCollision { get; private set; }

        public CollisionPoints(Vector3 A, Vector3 B, Vector3 normal, float depth, bool hasCollision)
        {
            this.A = A;
            this.B = B;
            this.Normal = normal;
            this.Depth = depth;
            this.HasCollision = hasCollision;
        }
    }
}