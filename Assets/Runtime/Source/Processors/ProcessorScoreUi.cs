using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags.Ui;
using Runtime.Source.Components.Ui;
using UnityEngine;

namespace Runtime.Source.Processors
{
    sealed class ProcessorScoreUi : Processor
    {
        private Group<ComponentScore> groupScores = default;
        private Group<ComponentScoreText, ComponentText> groupScoreTexts = default;
        
        public override void HandleEcsEvents()
        {
            foreach (var e in groupScoreTexts.added)
            {
                var cText = e.ComponentText();
                var cScore = groupScores[0].ComponentScore();
                Layer.Observer.Add(cScore, x => cScore.Score, 
                    scoreNext => cText.Text.text = scoreNext.ToString());
            }
        }
    }
}