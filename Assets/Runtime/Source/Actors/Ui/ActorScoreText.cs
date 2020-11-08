using Pixeye.Actors;
using Runtime.Source.Components.Tags.Ui;
using Runtime.Source.Components.Ui;
using Sirenix.OdinInspector;

namespace Runtime.Source.Actors.Ui
{
    public class ActorScoreText : Actor
    {
        [FoldoutGroup("Components", true)]
        public ComponentScoreText componentScoreText;
        [FoldoutGroup("Components", true)]
        public ComponentText componentText;
            
        protected override void Setup()
        {
            entity.Set(componentScoreText);
            entity.Set(componentText);
        }
    }
}