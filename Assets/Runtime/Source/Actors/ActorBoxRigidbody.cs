using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    public class ActorBoxRigidbody : Actor
    {
        [FoldoutGroup("Components"), SerializeField]
        private ComponentRigid componentRigid;

        [FoldoutGroup("Components"), SerializeField]
        private ComponentBoxCollider componentBoxCollider;

        protected override void Setup()
        {
            entity.Set(componentRigid);
            entity.Set(componentBoxCollider);
        }

        private void OnDrawGizmosSelected()
        {
            var previousColor = Gizmos.color;

            Gizmos.color = Color.green;

            var box = componentBoxCollider;
            var position = transform.position;
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, box.halfLength, box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, box.halfLength, box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, box.halfLength, -box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, -box.halfLength, box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, -box.halfLength, box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, -box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, -box.halfLength, -box.halfHeight));

            Gizmos.DrawLine(
                position + box.center + new Vector3(box.halfWidth, box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, box.halfLength, box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(-box.halfWidth, box.halfLength, box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(box.halfWidth, -box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, -box.halfLength, box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, -box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(-box.halfWidth, -box.halfLength, box.halfHeight));

            Gizmos.DrawLine(
                position + box.center + new Vector3(box.halfWidth, -box.halfLength, box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, box.halfLength, box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, -box.halfLength, box.halfHeight),
                position + box.center + new Vector3(-box.halfWidth, box.halfLength, box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(box.halfWidth, -box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(box.halfWidth, box.halfLength, -box.halfHeight));
            Gizmos.DrawLine(
                position + box.center + new Vector3(-box.halfWidth, -box.halfLength, -box.halfHeight),
                position + box.center + new Vector3(-box.halfWidth, box.halfLength, -box.halfHeight));

            Gizmos.color = previousColor;
        }
    }
}