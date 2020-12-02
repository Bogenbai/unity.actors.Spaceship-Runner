using Pixeye.Actors;
using Runtime.Source.Components.Markers;

namespace Runtime.Source.Processors
{
    sealed class ProcessorMarkers : Processor, ITick
    {
        private Group<ComponentMarker> groupMarkers = default;

        public void Tick(float delta)
        {
            ReleaseDeadMarkers();
            MarkersLifeReduction();
        }

        private void ReleaseDeadMarkers()
        {
            for (var i = 0; i < groupMarkers.length; i++)
            {
                if (groupMarkers[i].ComponentMarker().LifeTime <= 0)
                {
                    groupMarkers[i].Release();
                }
            }
        }

        private void MarkersLifeReduction()
        {
            for (var i = 0; i < groupMarkers.length; i++)
            {
                groupMarkers[i].ComponentMarker().LifeTime--;
            }
        }

        public ent GetMarker<T>()
        {
            for (var i = 0; i < groupMarkers.length; i++)
            {
                if (groupMarkers[i].Has<T>())
                {
                    return groupMarkers[i];
                }
            }

            return -1;
        }
    }
}