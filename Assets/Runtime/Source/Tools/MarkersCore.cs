using Pixeye.Actors;
using Runtime.Source.Components.Markers;
using Runtime.Source.Processors;

namespace Runtime.Source.Tools
{
    public static class MarkersCore
    {
        public static bool IsExist<T>(Layer layer)
        {
            var marker = layer.Get<ProcessorMarkers>().GetMarker<T>();

            return marker != -1;
        }

        public static ent Get<T>(Layer layer)
        {
            var marker = layer.Get<ProcessorMarkers>().GetMarker<T>();

            return marker;
        }

        public static ent Create<T>(Layer layer, int lifetime = 1)
        {
            var marker = layer.Entity.Create();
            var cMarker = marker.Set<ComponentMarker>();
            cMarker.LifeTime = lifetime;

            marker.Set<T>();

            return marker;
        }
    }
}