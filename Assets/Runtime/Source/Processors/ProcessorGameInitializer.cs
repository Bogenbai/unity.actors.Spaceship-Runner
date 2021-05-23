using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    sealed class ProcessorGameInitializer : Processor
    {
        public ProcessorGameInitializer()
        {
            var entityGame = Entity.Create();
            var cGame = entityGame.Set<ComponentGameState>();
            var cScore = entityGame.Set<ComponentScore>();
            cGame.value = GameStates.StartMenu;
        }
    }
}