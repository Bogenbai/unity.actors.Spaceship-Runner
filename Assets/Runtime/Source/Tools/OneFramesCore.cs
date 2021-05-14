using System;
using Pixeye.Actors;
using Runtime.Source.Processors;

namespace Runtime.Source.Tools
{
    public static class OneFramesCore
    {
        public static void Register<T>(Layer layer, T markerComponent)
        {
            var processor = layer.Get<ProcessorOneFrame<T>>();
            if (processor != null)
            {
                processor.Request(markerComponent);
            }
            else throw new Exception("No such processor");
        }
    }
}