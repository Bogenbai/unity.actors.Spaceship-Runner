using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    public class ActorTestRigidbody : Actor
    {
        [FoldoutGroup("Components"), SerializeField]
        private ComponentRigid componentRigid;

        protected override void Setup()
        {
            entity.Set(componentRigid);
        }
    }
}