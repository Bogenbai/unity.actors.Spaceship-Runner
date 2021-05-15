using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class is a system that scales entities to a specified scale in a specified time
    sealed class ProcessorScaleTo : Processor, ITick
    {
        private Group<ComponentScaleTo> groupScalable = default;

        public override void HandleEcsEvents()
        {
            for (var i = 0; i < groupScalable.added.length; i++)
            {
                var e = groupScalable.added[i];
                e.transform.localScale = e.ComponentScaleTo().startScale;
            }
        }

        public void Tick(float delta)
        {
            for (var i = 0; i < groupScalable.length; i++)
            {
                var entity = groupScalable[i];
                var transform = entity.transform;
                var componentScale = entity.ComponentScaleTo();
                var desirableScale = componentScale.finalScale;

                if (transform.localScale != desirableScale)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, desirableScale,
                        delta * componentScale.scaleSpeed);
                }
                else entity.Remove<ComponentScaleTo>();
            }
        }
    }
}