using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Ui;

namespace Runtime.Source.Processors.Ui
{
    sealed class ProcessorUiToggler : Processor
    {
        private readonly Group<ComponentStartMenuUi> groupStartMenuUi = default;
        private readonly Group<ComponentGameplayUi> groupGameplayUi = default;
        private readonly Group<ComponentGameOverMenuUi> groupGameOverMenuUi = default;
        private readonly Group<ComponentGameState> groupGame = default;
        private ent observer;

        public override void HandleEcsEvents()
        {
            foreach (var entity in groupGame.added)
            {
                var cGameState = entity.ComponentGame();

                observer = Layer.Observer.Add(
                    cGameState,
                    x => x.value,
                    HandleInUi);

                break;
            }

            foreach (var unused in groupGame.removed)
            {
                observer.Release();
            }
        }

        private void HandleInUi(GameStates state)
        {
            switch (state)
            {
                case GameStates.StartMenu:
                    SetActive(groupStartMenuUi, true);
                    SetActive(groupGameplayUi, false);
                    SetActive(groupGameOverMenuUi, false);
                    break;
                case GameStates.Gameplay:
                    SetActive(groupStartMenuUi, false);
                    SetActive(groupGameplayUi, true);
                    SetActive(groupGameOverMenuUi, false);
                    break;
                case GameStates.GameOver:
                    SetActive(groupStartMenuUi, false);
                    SetActive(groupGameplayUi, false);
                    SetActive(groupGameOverMenuUi, true);
                    break;
            }
        }

        private static void SetActive<T>(Group<T> group, bool state)
        {
            foreach (var entity in group)
            {
                entity.transform.gameObject.SetActive(state);
            }
        }
    }
}