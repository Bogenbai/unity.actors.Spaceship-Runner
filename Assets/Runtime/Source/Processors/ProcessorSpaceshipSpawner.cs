using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Data;

namespace Runtime.Source.Processors
{
    // Class is a system that allows player to respawn their spaceship after losing
    sealed class ProcessorSpaceshipSpawner : Processor, ITick
    {
        private readonly Group<ComponentSpaceship> groupSpaceships = default;
        private readonly Group<ComponentGameState> groupGameState = default;

        public void Tick(float delta)
        {
            if (groupSpaceships.length > 0 || groupGameState.length <= 0) return;

            var cGameState = groupGameState[0].ComponentGame();

            if (cGameState.value == GameStates.Gameplay)
            {
                var entitySpaceship = Layer.Actor.Create(DataBase.Prefabs.PlayerSpaceship).entity;
                entitySpaceship.transform.position = entitySpaceship.ComponentSpaceship().startPosition;
            }
        }
    }
}