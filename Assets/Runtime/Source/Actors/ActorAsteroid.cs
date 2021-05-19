using Pixeye.Actors;
using Runtime.Core.Physics;
using Runtime.Core.Physics.Components;
using Runtime.Source.Components;

namespace Runtime.Source.Actors
{
    public class ActorAsteroid : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentAsteroid componentAsteroid;
        [FoldoutGroup("Components", true)] public ComponentRigid componentRigid;
        [FoldoutGroup("Components", true)] public ComponentRandomRotatable componentRandomRotatable;
        [FoldoutGroup("Components", true)] public ComponentMove componentMove;
        [FoldoutGroup("Components", true)] public ComponentScaleTo componentScaleTo;
        [FoldoutGroup("Components", true)] public ComponentCanShatter componentCanShatter;
        [FoldoutGroup("Components", true)] public ComponentDamage componentDamage;
        [FoldoutGroup("Components", true)] public ComponentDestroyable componentDestroyable;
        [FoldoutGroup("Components", true)] public ComponentSphereCollider componentSphereCollider;


        protected override void Setup()
        {
            entity.Set(componentAsteroid);
            entity.Set(componentRigid);
            entity.Set(componentRandomRotatable);
            entity.Set(componentMove);
            entity.Set(componentScaleTo);
            entity.Set(componentCanShatter);
            entity.Set(componentDamage);
            entity.Set(componentDestroyable);
            entity.Set(componentSphereCollider);
        }

        private void OnDrawGizmosSelected()
        {
            CollidersVisuals.DrawSphereCollider(componentSphereCollider, transform.position);
        }
    }
}