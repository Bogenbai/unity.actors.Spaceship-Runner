using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics
{
    public static class CollidersVisuals
    {
        public static void DrawBoxCollider(ComponentBoxCollider box, Vector3 objectPosition)
        {
            var previousColor = Gizmos.color;

            Gizmos.color = Color.green;

            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, box.halfHeight, box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, box.halfHeight, box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, box.halfHeight, -box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, -box.halfHeight, box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, -box.halfHeight, box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, -box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, -box.halfHeight, -box.halfLength));

            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(box.halfWidth, box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, box.halfHeight, box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(-box.halfWidth, box.halfHeight, box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(box.halfWidth, -box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, -box.halfHeight, box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, -box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(-box.halfWidth, -box.halfHeight, box.halfLength));

            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(box.halfWidth, -box.halfHeight, box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, box.halfHeight, box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, -box.halfHeight, box.halfLength),
                objectPosition + box.center + new Vector3(-box.halfWidth, box.halfHeight, box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(box.halfWidth, -box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(box.halfWidth, box.halfHeight, -box.halfLength));
            Gizmos.DrawLine(
                objectPosition + box.center + new Vector3(-box.halfWidth, -box.halfHeight, -box.halfLength),
                objectPosition + box.center + new Vector3(-box.halfWidth, box.halfHeight, -box.halfLength));

            Gizmos.color = previousColor;
        }

        public static void DrawSphereCollider(ComponentSphereCollider sphere, Vector3 objectPosition)
        {
            var previousColor = Gizmos.color;

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(objectPosition + sphere.center, sphere.Radius);
        
            Gizmos.color = previousColor;
        }
    }
}
