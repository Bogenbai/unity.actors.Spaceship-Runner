using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Markers;
using Runtime.Source.Components.Tags;
using Runtime.Source.Processors;
using Runtime.Source.Tools;
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
            componentSpaceship.startPosition = transform.position;

            entity.Set(componentSpaceship);
            entity.Set(componentRigidbody);
            entity.Set(componentPlayerMovementData);
            entity.Set(componentHealth);
        }

        private void OnCollisionEnter(Collision other)
        {
            var collisionMarker = new ComponentCollisionMarker {Collision = other, ReceiverEntity = entity};
            MarkersCore.Register(Layer, collisionMarker);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            var speedX = componentPlayerMovementData.CurrentVelocityX;
            Gizmos.DrawRay(transform.position, new Vector3(speedX, 0, 0));
        }
    }
}