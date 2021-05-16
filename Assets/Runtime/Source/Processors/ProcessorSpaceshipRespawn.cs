using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using Runtime.Source.Data;

namespace Runtime.Source.Processors
{
    // Class is a system that allows player to respawn their spaceship after losing
    sealed class ProcessorSpaceshipRespawn : Processor, ITick
    {
        private Group<ComponentSpaceship> groupSpaceships = default;

        public void Tick(float delta)
        {
            if (groupSpaceships.length == 0 && UnityEngine.Input.GetMouseButtonDown(0))
            {
                var cSpaceship = groupSpaceships[0].ComponentSpaceship();
                Layer.Actor.Create(DataBase.Prefabs.ActorPlayerSpaceship, cSpaceship.startPosition);
            }
        }
    }
}