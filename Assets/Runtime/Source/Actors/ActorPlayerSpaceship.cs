using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Events;
using Runtime.Source.Components.Tags;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class ActorPlayerSpaceship : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentSpaceship componentSpaceship;
        [FoldoutGroup("Components", true)] public ComponentRigidbody componentRigidbody;
        [FoldoutGroup("Components", true)] public ComponentPlayerMovementData componentPlayerMovementData;
        [FoldoutGroup("Components", true)] public ComponentHealth componentHealth;


        protected override void Setup()
        {
            componentRigidbody.SetRigidbody(GetComponent<Rigidbody>());

            entity.Set(componentSpaceship);
            entity.Set(componentRigidbody);
            entity.Set(componentPlayerMovementData);
            entity.Set(componentHealth);
        }

        private void OnCollisionEnter(Collision other)
        {
            var entityCollision = Entity.Create();

            entityCollision.Set<ComponentCollisionEvent>();
            var componentCollision = entityCollision.ComponentCollision();
            componentCollision.Collision = other;
            componentCollision.ReceiverEntity = entity;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            var speedX = componentPlayerMovementData.CurrentVelocityX;
            Gizmos.DrawRay(transform.position, new Vector3(speedX, 0, 0));
        }
    }
}