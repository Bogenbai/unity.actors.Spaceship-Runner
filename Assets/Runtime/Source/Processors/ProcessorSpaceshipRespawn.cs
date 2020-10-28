using Pixeye.Actors;
using UnityEngine;

namespace Game.Source
{
    sealed class ProcessorSpaceshipRespawn : Processor, ITick
    {
        Group<ComponentSpaceship> groupSpaceships = default;

        public void Tick(float delta)
        {
            if(groupSpaceships.length == 0)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Layer.Actor.Create(DB.Prefabs.ActorPlayerSpaceship, new Vector3(0, 0, 15));
                }
            }
        }
    }
}
