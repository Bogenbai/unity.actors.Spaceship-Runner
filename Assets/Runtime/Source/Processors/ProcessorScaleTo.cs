using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
    sealed class ProcessorScaleTo : Processor, ITick
    {
        private readonly Group<ComponentScaleTo> groupScalable = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupScalable.length; i++)
            {
                var entity = groupScalable[i];
                var transform = entity.transform;
                var componentScale = entity.ComponentScaleTo();
                var desirableScale = componentScale.FinalScale;
            
                if (transform.localScale != desirableScale)
                {
                     transform.localScale = Vector3.Lerp(transform.localScale, desirableScale,
                         delta * componentScale.ScaleSpeed);
                } else entity.Remove<ComponentScaleTo>();
            }
        }
    }
}