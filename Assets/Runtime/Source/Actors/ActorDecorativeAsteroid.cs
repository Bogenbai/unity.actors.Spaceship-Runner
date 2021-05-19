using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class ActorDecorativeAsteroid : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentRigid componentRigid;
        [FoldoutGroup("Components", true)] public ComponentRandomRotatable componentRandomRotatable;
        [FoldoutGroup("Components", true)] public ComponentMove componentMove;
        [FoldoutGroup("Components", true)] public ComponentScaleTo componentScaleTo;
        [FoldoutGroup("Components", true)] public ComponentDestroyable componentDestroyable;

        protected override void Setup()
        {
            entity.Set(componentRigid);
            entity.Set(componentRandomRotatable);
            entity.Set(componentMove);
            entity.Set(componentScaleTo);
            entity.Set(componentDestroyable);
        }
    }
}