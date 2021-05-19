using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics.Actors
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
            CollidersVisuals.DrawBoxCollider(componentBoxCollider, transform.position);
        }
    }
}