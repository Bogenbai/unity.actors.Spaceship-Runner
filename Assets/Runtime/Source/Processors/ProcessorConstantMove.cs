using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class represents a system which is constantly moves entities which are has appropriate component
    sealed class ProcessorConstantMove : Processor, ITick
    {
        private readonly Group<ComponentConstantMove> groupMovement = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupMovement.length; i++)
            {
                var entity = groupMovement[i];
                var componentMovement = entity.ComponentConstantMove();
                entity.transform.position += componentMovement.MovementDirection * (componentMovement.Speed * delta);
            }
        }
    }
}