using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;

namespace Runtime.Source.Processors
{
    // Class is a system that moves player spaceship depending on it's movement data
    sealed class ProcessorSpaceshipMove : Processor, ITickFixed
    {
        private Group<ComponentSpaceship, ComponentMovementData> groupSpaceships = default;

        public void TickFixed(float delta)
        {
            for (int j = 0; j < groupSpaceships.length; j++)
            {
                var spaceship = groupSpaceships[j];
                var cMove = spaceship.ComponentMove();
                var speed = cMove.speed;
                var direction = cMove.movementDirection;

                direction *= speed * delta;
                spaceship.transform.position += direction;
            }
        }
    }
}