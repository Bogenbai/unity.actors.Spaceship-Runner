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
    }
}