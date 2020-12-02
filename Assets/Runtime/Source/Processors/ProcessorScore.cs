using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;

namespace Runtime.Source.Processors
{
    // Class represents a system that controls score points in the game
    sealed class ProcessorScore : Processor
    {
        private Group<ComponentSpaceship> groupSpaceships = default;
        private Group<ComponentAsteroid> groupAsteroids = default;
        private ent scoreCounterEntity;
        private RoutineCall scoreCounterRoutine;

        public ProcessorScore()
        {
            scoreCounterEntity = Entity.Create();
            scoreCounterEntity.Set<ComponentScore>();
        }

        public override void HandleEcsEvents()
        {
            // If player spaceship respawned then resets score
            foreach (var e in groupSpaceships.added)
            {
                scoreCounterEntity.ComponentScore().Score = 0;
            }
            
            foreach (var e in groupAsteroids.removed)
            {
                // If player spaceship exists then increases score
                if (groupSpaceships.length > 0)
                {
                    scoreCounterEntity.ComponentScore().Score++;
                }
            }
        }
    }
}