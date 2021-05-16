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
            foreach (var entity in groupScalable.added)
            {
                entity.transform.localScale = entity.ComponentScaleTo().startScale;
            }
        }

        public void Tick(float delta)
        {
            foreach (var entity in groupScalable)
            {
                var transform = entity.transform;
                var componentScale = entity.ComponentScaleTo();
                var desirableScale = componentScale.finalScale;

                if (transform.localScale != desirableScale)
                {
                    transform.localScale = Vector3.Lerp(
                        transform.localScale,
                        desirableScale,
                        delta * componentScale.scaleSpeed);
                }
                else entity.Remove<ComponentScaleTo>();
            }
        }
    }
}