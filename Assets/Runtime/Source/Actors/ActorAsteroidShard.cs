using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class ActorAsteroidShard : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentDestroyable componentDestroyable;
        [FoldoutGroup("Components", true)] public ComponentRigid componentRigid;
        [FoldoutGroup("Components", true)] public ComponentMove componentMove;

        protected override void Setup()
        {
            entity.Set(componentRigid);
            entity.Set(componentMove);
            entity.Set(componentDestroyable);
        }
    }
}