using Pixeye.Actors;
using Runtime.Source.Components.Ui;
using UnityEngine;

namespace Runtime.Source.Actors.Ui
{
    public class ActorGameplayUi : Actor
    {
        [FoldoutGroup("Components", true), SerializeField]
        private ComponentUiScore componentUiScore;

        protected override void Setup()
        {
            entity.Set(componentUiScore);
        }
    }
}