using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Components;

namespace Runtime.Source.Actors
{
    public class ActorPlayerSpaceship : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentSpaceship componentSpaceship;
        [FoldoutGroup("Components", true)] public ComponentRigid componentRigid;
        [FoldoutGroup("Components", true)] public ComponentHealth componentHealth;
        [FoldoutGroup("Components", true)] public ComponentMove componentMove;
        [FoldoutGroup("Components", true)] public ComponentThrust componentThrust;
        [FoldoutGroup("Components", true)] public ComponentBounds componentBounds;
        [FoldoutGroup("Components", true)] public ComponentBoxCollider componentBoxCollider;

        protected override void Setup()
        {
            componentSpaceship.startPosition = transform.position;

            entity.Set(componentSpaceship);
            entity.Set(componentRigid);
            entity.Set(componentMove);
            entity.Set(componentHealth);
            entity.Set(componentThrust);
            entity.Set(componentBounds);
            entity.Set(componentBoxCollider);
        }

        private void OnDrawGizmosSelected()
        {
            CollidersVisuals.DrawBoxCollider(componentBoxCollider, transform.position);
        }
    }
}