using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Processors;
using Runtime.Source.Processors.Input;
using Runtime.Source.Tools.CameraShaker;

namespace Runtime.Source.Layers
{
    public class LayerGame : Layer<LayerGame>
    {
        // Use to add processors and set up a layer.
        protected override void Setup()
        {
            // USER INPUT
#if UNITY_IPHONE || UNITY_ANDROID && !UNITY_EDITOR // Comment '&& !UNITY_EDITOR' to turn on mobile controls
            // Mobile
            Add<ProcessorUserTouchInput>();
#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR
            // PC
            Add<ProcessorUserInput>();
#endif
            Add<ProcessorSpawnSignalSender>();
            Add<ProcessorSpawner>();
            Add<ProcessorDestroyDestroyable>();
            Add<ProcessorSpaceshipMoveStateSetter>();
            Add<ProcessorRigidbodyRandomRotator>();
            Add<ProcessorScaleTo>();
            Add<ProcessorSpaceshipMove>();
            Add<ProcessorSpaceshipThrottling>();
            Add<ProcessorSpaceshipBraking>();
            Add<ProcessorSpaceshipRotation>();
            Add<ProcessorSpaceshipMoveBounds>();
            Add<ProcessorSpaceshipRespawn>();
            Add<ProcessorSpaceshipDeath>();
            Add<ProcessorScore>();
            Add<ProcessorSpaceshipAsteroidCollision>();
            Add<ProcessorCameraShake>();
            Add<ProcessorHealth>();
            Add<ProcessorConstantMove>();
            Add<ProcessorScoreUi>();
            Add<ProcessorOneFrame<ComponentUserInput>>();
            Add<ProcessorOneFrame<ComponentCollision>>();
        }

        // Use to clean up custom stuff before the layer gets destroyed.
        protected override void OnLayerDestroy()
        {
        }
    }
}