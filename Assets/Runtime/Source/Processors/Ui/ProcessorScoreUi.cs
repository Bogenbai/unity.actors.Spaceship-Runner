using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Ui;

namespace Runtime.Source.Processors.Ui
{
    // Class represents a system that updates player's score in the ui
    sealed class ProcessorScoreUi : Processor
    {
        private readonly Group<ComponentScore> groupScores = default;
        private readonly Group<ComponentUiScore> groupScoreTexts = default;

        public override void HandleEcsEvents()
        {
            foreach (var e in groupScoreTexts.added)
            {
                var cUiScore = e.ComponentUiScore();
                var cScore = groupScores[0].ComponentScore();
                Layer.Observer.Add(
                    cScore,
                    x => cScore.Score,
                    scoreNext => cUiScore.scoreText.text = scoreNext.ToString());
            }
        }
    }
}