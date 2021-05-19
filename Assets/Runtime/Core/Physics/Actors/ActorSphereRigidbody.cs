using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Core.Physics.Actors
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
            CollidersVisuals.DrawSphereCollider(componentSphereCollider, transform.position);
        }
    }
}