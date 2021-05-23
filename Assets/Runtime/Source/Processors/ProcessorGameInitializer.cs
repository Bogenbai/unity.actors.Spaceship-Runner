using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    sealed class ProcessorGameInitializer : Processor
    {
        public ProcessorGameInitializer()
        {
            var entityGame = Entity.Create();
            var cGame = entityGame.Set<ComponentGame>();
            var cScore = entityGame.Set<ComponentScore>();
            cGame.state = GameStates.StartMenu;
        }
    }
}