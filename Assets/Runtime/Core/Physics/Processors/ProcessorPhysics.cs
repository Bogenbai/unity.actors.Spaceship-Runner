using Pixeye.Actors;
using Runtime.Core.Physics.Components;

namespace Runtime.Core.Physics.Processors
{
    sealed class ProcessorPhysics : Processor, ITickFixed
    {
        private readonly Group<ComponentRigid> groupRigidbodies = default;

        public void TickFixed(float delta)
        {
            Dynamics.Step(groupRigidbodies, delta);
        }
    }
}