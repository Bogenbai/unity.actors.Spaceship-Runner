using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    sealed class ProcessorGameStates : Processor, ITick
    {
        private readonly Group<ComponentSpaceship> groupSpaceships = default;
        private ent entityGame;


        public void Tick(float dt)
        {
            if (entityGame.exist == false)
            {
                entityGame = Entity.Create();
                var componentGameState = entityGame.Set<ComponentGameState>();

                componentGameState.state = GameStates.StartMenu;
            }
 
            var cGameState = entityGame.ComponentGameState();

            switch (cGameState.state)
            {
                case GameStates.StartMenu:
                    if (UnityEngine.Input.GetMouseButtonDown(0))
                    {
                        cGameState.state = GameStates.Gameplay;
                    }

                    break;
                case GameStates.Gameplay:
                    if (groupSpaceships.length <= 0)
                    {
                        cGameState.state = GameStates.GameOver;
                    }

                    break;
                case GameStates.GameOver:
                    if (UnityEngine.Input.GetMouseButtonDown(0))
                    {
                        cGameState.state = GameStates.Gameplay;
                    }

                    break;
            }
        }
    }
}