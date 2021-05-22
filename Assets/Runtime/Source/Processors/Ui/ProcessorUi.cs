using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Ui;
using UnityEngine;

namespace Runtime.Source.Processors.Ui
{
    sealed class ProcessorUi : Processor
    {
        private readonly Group<ComponentStartMenuUi> groupStartMenuUi = default;
        private readonly Group<ComponentGameplayUi> groupGameplayUi = default;
        private readonly Group<ComponentGameOverMenuUi> groupGameOverMenuUi = default;
        private readonly Group<ComponentGameState> groupGameStates = default;


        public override void HandleEcsEvents()
        {
            foreach (var entity in groupGameStates.added)
            {
                var cGameState = entity.ComponentGameState();

                Layer.Observer.Add(
                    cGameState,
                    x => x.state,
                    OpenUi);
            }
        }

        private void OpenUi(GameStates state)
        {
            switch (state)
            {
                case GameStates.StartMenu:
                    Debug.Log("StartMenu");
                    SetActive(groupStartMenuUi, true);
                    SetActive(groupGameplayUi, false);
                    SetActive(groupGameOverMenuUi, false);
                    break;
                case GameStates.Gameplay:
                    Debug.Log("Gameplay");
                    SetActive(groupStartMenuUi, false);
                    SetActive(groupGameplayUi, true);
                    SetActive(groupGameOverMenuUi, false);
                    break;
                case GameStates.GameOver:
                    Debug.Log("GameOver");
                    SetActive(groupStartMenuUi, false);
                    SetActive(groupGameplayUi, false);
                    SetActive(groupGameOverMenuUi, true);
                    break;
            }
        }

        private void SetActive<T>(Group<T> @group, bool state)
        {
            foreach (var entity in group)
            {
                entity.transform.gameObject.SetActive(state);
            }
        }
    }
}