using Pixeye.Actors;
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
            PhysicsDynamics.ResolveCollisions(Layer, groupSphereColliders);
            PhysicsDynamics.ResolveCollisions(Layer, groupBoxColliders);
            PhysicsDynamics.ResolveCollisions(Layer, groupBoxColliders, groupSphereColliders);
            PhysicsDynamics.Step(groupRigidbodies, delta);
        }
    }
}