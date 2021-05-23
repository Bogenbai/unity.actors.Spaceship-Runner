using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Ui;

namespace Runtime.Source.Processors.Ui
{
    // Class represents a system that updates player's score in the ui
    sealed class ProcessorUiScore : Processor
    {
        private readonly Group<ComponentScore> groupScores = default;
        private readonly Group<ComponentUiScore> groupScoreTexts = default;

        public override void HandleEcsEvents()
        {
            foreach (var entityText in groupScoreTexts.added)
            {
                if (groupScores.length <= 0) return;

                var cScore = groupScores[0].ComponentScore();

                var cUiScore = entityText.ComponentUiScore();

                Layer.Observer.Add(
                    cScore,
                    x => cScore.Score,
                    scoreNext => cUiScore.scoreText.text = scoreNext.ToString());
            }
        }
    }
}