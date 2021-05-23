using System.Collections;
using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class represents a system that controls score points in the game
    sealed class ProcessorScore : Processor
    {
        private readonly Group<ComponentGameState, ComponentScore> groupScore = default;
        private RoutineCall scoreCountingCoroutine;
        private ent observer;

        public override void HandleEcsEvents()
        {
            foreach (var entity in groupScore.added)
            {
                var cScore = entity.ComponentScore();
                var cGame = entity.ComponentGame();

                observer = Layer.Observer.Add(
                    cGame,
                    x => x.value,
                    x => HandleScoreCounting(x, cScore));

                break;
            }

            foreach (var unused in groupScore.removed)
            {
                observer.Release();
            }
        }

        private void HandleScoreCounting(GameStates state, ComponentScore componentScore)
        {
            switch (state)
            {
                case GameStates.Gameplay:
                    if (scoreCountingCoroutine.IsRunning == false)
                    {
                        componentScore.Score = 0;
                        scoreCountingCoroutine = Layer.Run(ScoreCounting());
                    }

                    break;
                default:
                    scoreCountingCoroutine.Stop();
                    break;
            }
        }

        IEnumerator ScoreCounting()
        {
            while (groupScore.length > 0)
            {
                var entityScore = groupScore[0];
                yield return Layer.Wait(1);
                entityScore.ComponentScore().Score++;
            }
        }
    }
}