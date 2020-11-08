using Pixeye.Actors;
using Runtime.Source.Components.Tags;
using Runtime.Source.Data;
using UnityEngine;

namespace Runtime.Source.Processors
{
    sealed class ProcessorSpaceshipRespawn : Processor, ITick
    {
        private Group<ComponentSpaceship> groupSpaceships = default;

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
