using Pixeye.Actors;
using Runtime.Core.Physics.Components;

namespace Runtime.Core.Physics.Processors
{
    sealed class ProcessorPhysics : Processor, ITickFixed
    {
        private readonly Group<ComponentRigid> groupRigidbodies = default;
        private readonly Group<ComponentSphereCollider> groupSphereColliders = default;

        public void TickFixed(float delta)
        {
            Dynamics.Step(groupRigidbodies, groupSphereColliders, delta);
        }
    }
}