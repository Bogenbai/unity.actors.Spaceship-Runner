using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class ActorDecorativeAsteroid : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentRigidbody componentRigidbody;
        [FoldoutGroup("Components", true)] public ComponentRandomRotatable componentRandomRotatable;
        [FoldoutGroup("Components", true)] public ComponentConstantMove componentConstantMove;
        [FoldoutGroup("Components", true)] public ComponentScaleTo componentScaleTo;
        [FoldoutGroup("Components", true)] public ComponentDestroyable componentDestroyable;

        protected override void Setup()
        {
            componentRigidbody.SetRigidbody(GetComponent<Rigidbody>());
            
            entity.Set(componentRigidbody);
            entity.Set(componentRandomRotatable);
            entity.Set(componentConstantMove);
            entity.Set(componentScaleTo);
            entity.Set(componentDestroyable);
        }
    }
}