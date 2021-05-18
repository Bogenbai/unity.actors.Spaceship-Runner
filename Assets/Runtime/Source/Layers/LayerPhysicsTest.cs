using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Core.Physics.Processors;
using Runtime.Source.Processors;

namespace Runtime.Source.Layers
{
    public class LayerPhysicsTest : Layer<LayerPhysicsTest>
    {
        protected override void Setup()
        {
            Add<ProcessorPhysics>();
            Add<ProcessorCollisionVisualizer>();
            Add<ProcessorOneFrame<ComponentCollision>>();
            Add<ProcessorOneFrame<ComponentCollisionStopped>>();
        }
    }
}