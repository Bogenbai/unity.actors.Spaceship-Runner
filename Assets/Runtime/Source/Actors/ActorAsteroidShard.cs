using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class ActorAsteroidShard : Actor
    {
        [Sirenix.OdinInspector.FoldoutGroup("Components", true)]
        public ComponentDestroyable componentDestroyable;
        [Sirenix.OdinInspector.FoldoutGroup("Components", true)]
        public ComponentRigidbody componentRigidbody;
        [Sirenix.OdinInspector.FoldoutGroup("Components", true)]
        public ComponentConstantMove componentConstantMove;

        protected override void Setup()
        {
            componentRigidbody.SetRigidbody(GetComponent<Rigidbody>());
            
            entity.Set(componentRigidbody);
            entity.Set(componentConstantMove);
            entity.Set(componentDestroyable);
        }
    }
}