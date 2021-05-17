using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    public class ActorTestRigidbody : Actor
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
    }
}