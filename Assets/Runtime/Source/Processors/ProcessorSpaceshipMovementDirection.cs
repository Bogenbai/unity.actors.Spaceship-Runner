using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    sealed class ProcessorSpaceshipMovementDirection : Processor, ITick
    {
        private readonly Group<ComponentUserInput> groupUserInputs = default;
        private readonly Group<ComponentSpaceship, ComponentMove> groupMove = default;

        public void Tick(float delta)
        {
            if (groupUserInputs.length <= 0) return;

            var cUserInput = groupUserInputs[0].ComponentUserInput();

            foreach (var entity in groupMove)
            {
                var cSpaceship = entity.ComponentSpaceship();
                var cMove = entity.ComponentMove();
                cSpaceship.input = cUserInput.value;
                var moveDirection = cSpaceship.input;
                var speed = cMove.speed;

                if (moveDirection.x == 0 && speed != 0) return;

                cMove.moveDirection = moveDirection;
            }
        }
    }
}