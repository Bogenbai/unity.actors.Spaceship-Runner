using System.Collections;
using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class represents a system that controls score points in the game
    sealed class ProcessorScore : Processor
    {
        private readonly Group<ComponentSpaceship> groupSpaceships = default;
        private readonly ent scoreCounterEntity;
        private RoutineCall scoreCountingCoroutine;

        public ProcessorScore()
        {
            scoreCounterEntity = Entity.Create();
            scoreCounterEntity.Set<ComponentScore>();
        }

        public override void HandleEcsEvents()
        {
            foreach (var unused in groupSpaceships.added)
            {
                if (scoreCountingCoroutine.IsRunning == false)
                {
                    scoreCounterEntity.ComponentScore().Score = 0;
                    scoreCountingCoroutine = Layer.Run(ScoreCounting());
                }
            }

            foreach (var unused in groupSpaceships.removed)
            {
                if (groupSpaceships.length <= 0)
                {
                    scoreCountingCoroutine.Stop();
                }
            }
        }

        IEnumerator ScoreCounting()
        {
            while (true)
            {
                yield return Layer.Wait(1);
                scoreCounterEntity.ComponentScore().Score++;
            }
        }
    }
}