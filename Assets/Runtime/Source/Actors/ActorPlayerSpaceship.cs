using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Components;
using Runtime.Source.Tools;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Rigidbody))]
    public class ActorPlayerSpaceship : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentSpaceship componentSpaceship;
        [FoldoutGroup("Components", true)] public ComponentRigidbody componentRigidbody;
        [FoldoutGroup("Components", true)] public ComponentHealth componentHealth;
        [FoldoutGroup("Components", true)] public ComponentMove componentMove;
        [FoldoutGroup("Components", true)] public ComponentThrust componentThrust;
        [FoldoutGroup("Components", true)] public ComponentBounds componentBounds;

        protected override void Setup()
        {
            componentRigidbody.SetRigidbody(GetComponent<Rigidbody>());
            componentSpaceship.startPosition = transform.position;

            entity.Set(componentSpaceship);
            entity.Set(componentRigidbody);
            entity.Set(componentMove);
            entity.Set(componentHealth);
            entity.Set(componentThrust);
            entity.Set(componentBounds);
        }

        private void OnCollisionEnter(Collision other)
        {
            var cCollision = new ComponentCollision {Collision = other, ReceiverEntity = entity};
            OneFramesCore.Register(Layer, cCollision);
        }
    }
}