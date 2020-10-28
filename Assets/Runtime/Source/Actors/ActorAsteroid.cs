using Pixeye.Actors;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Game.Source
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class ActorAsteroid : Actor
    {
        [FoldoutGroup("Components", true)]
        public ComponentAsteroid componentAsteroid;
        [FoldoutGroup("Components", true)]
        public ComponentRigidbody componentRigidbody;
        [FoldoutGroup("Components", true)]
        public ComponentRandomRotatable componentRandomRotatable;
        [FoldoutGroup("Components", true)]
        public ComponentConstantMove componentConstantMove;
        [FoldoutGroup("Components", true)]
        public ComponentScaleTo componentScaleTo;
        [FoldoutGroup("Components", true)]
        public ComponentCanShatter componentCanShatter;
        [FoldoutGroup("Components", true)]
        public ComponentDamage componentDamage;
        [FoldoutGroup("Components", true)]
        public ComponentDestroyable componentDestroyable;


        protected override void Setup()
        {
            componentRigidbody.SetRigidbody(GetComponent<Rigidbody>());
            
            entity.Set(componentAsteroid);
            entity.Set(componentRigidbody);
            entity.Set(componentRandomRotatable);
            entity.Set(componentConstantMove);
            entity.Set(componentScaleTo);
            entity.Set(componentCanShatter);
            entity.Set(componentDamage);
            entity.Set(componentDestroyable);
        }
    }
}