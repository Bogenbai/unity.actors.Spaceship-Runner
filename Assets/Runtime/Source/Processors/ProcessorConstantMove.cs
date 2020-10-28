using Pixeye.Actors;


namespace Game.Source
{
    sealed class ProcessorConstantMove : Processor, ITick
    {
        private readonly Group<ComponentConstantMove> groupMovement = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupMovement.length; i++)
            {
                var entity = groupMovement[i];
                var componentMovement = entity.ComponentConstantMove();
                entity.transform.position +=
                    componentMovement.MovementDirection *
                    componentMovement.Speed *
                    delta;
            }
        }
    }
}