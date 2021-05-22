using Pixeye.Actors;
using Runtime.Source.Components.Ui;
using UnityEngine;

namespace Runtime.Source.Actors.Ui
{
    public class ActorStartMenuUi : Actor
    {
        [FoldoutGroup("Components", true), SerializeField]
        private ComponentStartMenuUi componentStartMenuUi;

        protected override void Setup()
        {
            entity.Set(componentStartMenuUi);
        }
    }
}