﻿using Pixeye.Actors;
using Runtime.Core.Physics.Components;

namespace Runtime.Core.Physics.Processors
{
    sealed class ProcessorPhysics : Processor, ITickFixed
    {
        private readonly Group<ComponentRigid> groupRigidbodies = default;
        private readonly Group<ComponentSphereCollider> groupSphereColliders = default;
        private readonly Group<ComponentBoxCollider> groupBoxColliders = default;

        public void TickFixed(float delta)
        {
            Dynamics.ResolveCollisions(groupSphereColliders);
            Dynamics.ResolveCollisions(groupBoxColliders);
            Dynamics.ResolveCollisions(groupBoxColliders, groupSphereColliders);
            Dynamics.Step(groupRigidbodies, delta);
        }
    }
}