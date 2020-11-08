using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;

namespace Runtime.Source.Processors
{
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
            foreach (var e in groupSpaceships.added)
            {
                scoreCounterEntity.ComponentScore().Score = 0;
            }
            
            foreach (var e in groupAsteroids.removed)
            {
                if (groupSpaceships.length > 0)
                {
                    scoreCounterEntity.ComponentScore().Score++;
                }
            }
        }
    }
}