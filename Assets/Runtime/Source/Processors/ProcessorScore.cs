using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;

namespace Runtime.Source.Processors
{
    // Class represents a system that controls score points in the game
    sealed class ProcessorScore : Processor
    {
        private readonly Group<ComponentSpaceship> groupSpaceships = default;
        private readonly Group<ComponentAsteroid> groupAsteroids = default;
        private readonly ent scoreCounterEntity;

        public ProcessorScore()
        {
            scoreCounterEntity = Entity.Create();
            scoreCounterEntity.Set<ComponentScore>();
        }

        public override void HandleEcsEvents()
        {
            foreach (var unused in groupSpaceships.added)
            {
                scoreCounterEntity.ComponentScore().Score = 0;
            }

            foreach (var unused in groupAsteroids.removed)
            {
                if (groupSpaceships.length > 0)
                {
                    scoreCounterEntity.ComponentScore().Score++;
                }
            }
        }
    }
}