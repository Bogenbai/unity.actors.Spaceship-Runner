using Pixeye.Actors;
using Runtime.Source.Components.Markers;
using Runtime.Source.Processors;

namespace Runtime.Source.Tools
{
    public static class MarkersCore
    {
        public static void Register<T>(Layer layer, T markerComponent)
        {
            layer.Get<ProcessorMarkers>().Request(markerComponent);
        }
    }
}