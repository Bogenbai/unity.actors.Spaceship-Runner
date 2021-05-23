using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Components;
using Component = Runtime.Source.Components.Component;

namespace Runtime.Source.Processors
{
    // Class represents a system which is constantly moves entities which are has appropriate component
    sealed class ProcessorMove : Processor, ITickFixed, ITick
    {
        [ExcludeBy(Runtime.Core.Physics.Components.Component.Rigid)]
        private readonly Group<ComponentMove> groupMovement = default;

        private readonly Group<ComponentMove, ComponentRigid> groupRigidMovement = default;

        public void TickFixed(float delta)
        {
            foreach (var entity in groupRigidMovement)
            {
                var cMove = entity.ComponentMove();
                var rigidbody = entity.ComponentRigid();

                rigidbody.velocity = cMove.moveDirection * (cMove.speed * delta);
            }
        }

        public void Tick(float delta)
        {
            foreach (var entity in groupMovement)
            {
                var cMove = entity.ComponentMove();

                entity.transform.position += cMove.moveDirection * (cMove.speed * delta);
            }
        }
    }
}