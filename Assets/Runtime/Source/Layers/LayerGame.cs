using Pixeye.Actors;
using Runtime.Source.Processors;
using Runtime.Source.Processors.Controls;
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
            // SPAWN AND DESTROY
            Add<ProcessorSpawnSignalSender>();
            Add<ProcessorSpawner>();
            Add<ProcessorDestroyDestroyable>();

            // SETTERS
            Add<ProcessorSpaceshipMoveStateSetter>();
            
            // ASTEROIDS
            Add<ProcessorRigidbodyRandomRotator>();
            Add<ProcessorScaleTo>();

            // PLAYER
            Add<ProcessorSpaceshipMove>();
            Add<ProcessorSpaceshipThrottling>();
            Add<ProcessorSpaceshipBraking>();
            Add<ProcessorSpaceshipRotation>();
            Add<ProcessorSpaceshipMoveBounds>();
            Add<ProcessorSpaceshipRespawn>();
            Add<ProcessorSpaceshipDeath>();
            Add<ProcessorScore>();

            // COLLISIONS
            Add<ProcessorSpaceshipAsteroidCollision>();

            // CAMERA
            Add<ProcessorCameraShake>();

            // COMMON
            Add<ProcessorHealth>();
            Add<ProcessorConstantMove>();
            
            // Ui
            Add<ProcessorScoreUi>();
        }

        // Use to clean up custom stuff before the layer gets destroyed.
        protected override void OnLayerDestroy()
        {
        }
    }
}