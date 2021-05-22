using Pixeye.Actors;
using Runtime.Source.Components.Ui;
using UnityEngine;

namespace Runtime.Source.Actors.Ui
{
    public class ActorGameOverMenuUi : Actor
    {
        [FoldoutGroup("Components", true), SerializeField]
        private ComponentGameOverMenuUi componentGameOverMenuUi;

        [FoldoutGroup("Components", true), SerializeField]
        private ComponentUiScore componentUiScore;

        protected override void Setup()
        {
            entity.Set(componentGameOverMenuUi);
            entity.Set(componentUiScore);
        }
    }
}