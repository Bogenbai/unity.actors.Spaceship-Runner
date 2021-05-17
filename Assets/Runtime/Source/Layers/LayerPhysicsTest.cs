using Pixeye.Actors;
using Runtime.Core.Physics.Processors;

namespace Runtime.Source.Layers
{
    public class LayerPhysicsTest : Layer<LayerPhysicsTest>
    {
        // Use to add processors and set up a layer.
        protected override void Setup()
        {
            Add<ProcessorPhysics>();
        }

        // Use to clean up custom stuff before the layer gets destroyed.
        protected override void OnLayerDestroy()
        {
        }
    }
}