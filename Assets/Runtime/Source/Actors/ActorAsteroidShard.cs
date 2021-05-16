﻿using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class ActorAsteroidShard : Actor
    {
        [FoldoutGroup("Components", true)]
        public ComponentDestroyable componentDestroyable;
        [FoldoutGroup("Components", true)]
        public ComponentRigidbody componentRigidbody;
        [FoldoutGroup("Components", true)]
        public ComponentMove componentMove;

        protected override void Setup()
        {
            componentRigidbody.SetRigidbody(GetComponent<Rigidbody>());
            
            entity.Set(componentRigidbody);
            entity.Set(componentMove);
            entity.Set(componentDestroyable);
        }
    }
}