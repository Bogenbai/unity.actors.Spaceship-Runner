using System;
using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    public class ActorSphereRigidbody : Actor
    {
        [FoldoutGroup("Components"), SerializeField]
        private ComponentRigid componentRigid;

        [FoldoutGroup("Components"), SerializeField]
        private ComponentSphereCollider componentSphereCollider;

        protected override void Setup()
        {
            entity.Set(componentRigid);
            entity.Set(componentSphereCollider);
        }

        private void OnDrawGizmosSelected()
        {
            var previousColor = Gizmos.color;

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(
                transform.position + componentSphereCollider.center,
                componentSphereCollider.Radius);

            Gizmos.color = previousColor;
        }
    }
}