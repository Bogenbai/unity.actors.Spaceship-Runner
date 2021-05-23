using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    sealed class ProcessorGameStates : Processor, ITick
    {
        private readonly Group<ComponentSpaceship> groupSpaceships = default;
        private readonly Group<ComponentGameState> groupGame = default;

        public void Tick(float dt)
        {
            if (groupGame.length <= 0) return;

            var cGame = groupGame[0].ComponentGame();

            if (cGame.value == GameStates.StartMenu)
            {
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    cGame.value = GameStates.Gameplay;
                }
            }
            else if (cGame.value == GameStates.Gameplay)
            {
                if (groupSpaceships.length <= 0)
                {
                    cGame.value = GameStates.GameOver;
                }
            }
            else if (cGame.value == GameStates.GameOver)
            {
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    cGame.value = GameStates.Gameplay;
                }
            }
        }
    }
}