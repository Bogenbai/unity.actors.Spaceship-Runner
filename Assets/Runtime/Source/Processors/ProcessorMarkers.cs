using Pixeye.Actors;
using Runtime.Source.Components.Markers;

namespace Runtime.Source.Processors
{
    // Class represents a system that manages markers
    // Markers itself are an entities which are supposed to play a role of events in the ECS world
    // Markers has a lifetime. Marker's lifetime decreases by one every frame
    // Also marker can contain some data
    sealed class ProcessorMarkers : Processor, ITick
    {
        private Group<ComponentMarker> groupMarkers = default;

        public void Tick(float delta)
        {
            ReleaseDeadMarkers();
            MarkersLifeReduction();
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
    }
}