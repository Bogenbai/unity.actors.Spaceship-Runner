using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class represents a system which is constantly moves entities which are has appropriate component
    sealed class ProcessorMove : Processor, ITickFixed
    {
        private readonly Group<ComponentMove, ComponentRigidbody> groupMovement = default;

        public void TickFixed(float delta)
        {
            foreach (var entity in groupMovement)
            {
                var cMove = entity.ComponentMove();
                var rigidbody = entity.ComponentRigidbody().Rigidbody;

                rigidbody.velocity = cMove.movementDirection * (cMove.speed * delta);
            }
        }
    }
}