using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    sealed class ProcessorGameStates : Processor, ITick
    {
        private readonly Group<ComponentSpaceship> groupSpaceships = default;
        private readonly Group<ComponentGame> groupGame = default;

        public void Tick(float dt)
        {
            if (groupGame.length <= 0) return;

            var cGame = groupGame[0].ComponentGame();

            if (cGame.state == GameStates.StartMenu)
            {
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    cGame.state = GameStates.Gameplay;
                }
            }
            else if (cGame.state == GameStates.Gameplay)
            {
                if (groupSpaceships.length <= 0)
                {
                    cGame.state = GameStates.GameOver;
                }
            }
            else if (cGame.state == GameStates.GameOver)
            {
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    cGame.state = GameStates.Gameplay;
                }
            }
        }
    }
}