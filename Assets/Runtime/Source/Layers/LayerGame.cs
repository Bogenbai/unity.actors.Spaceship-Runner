using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Spawn;
using Runtime.Source.Processors;
using Runtime.Source.Processors.Input;
using Runtime.Source.Tools.CameraShaker;

namespace Runtime.Source.Layers
{
    public class LayerGame : Layer<LayerGame>
    {
        protected override void Setup()
        {
#if UNITY_IOS || UNITY_ANDROID && !UNITY_EDITOR // Comment '&& !UNITY_EDITOR' to turn on mobile controls
            Add<ProcessorUserTouchInput>();
#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR
            Add<ProcessorUserInput>();
#endif
            Add<ProcessorSpawnTimer>();
            Add<ProcessorSpawner>();
            Add<ProcessorDestroyDestroyable>();
            Add<ProcessorRigidbodyRandomRotator>();
            Add<ProcessorScaleTo>();
            Add<ProcessorHealth>();
            Add<ProcessorScore>();
            Add<ProcessorCameraShake>();
            Add<ProcessorMove>();
            Add<ProcessorScoreUi>();
            AddSpaceshipProcessors();
            AddOneFramesProcessors();
        }

        private static void AddSpaceshipProcessors()
        {
            Add<ProcessorSpaceshipMoveStateSetter>();
            //Add<ProcessorSpaceshipMove>();
            Add<ProcessorThrottling>();
            Add<ProcessorSpaceshipBraking>();
            Add<ProcessorSpaceshipRotation>();
            Add<ProcessorSpaceshipMoveBounds>();
            Add<ProcessorSpaceshipRespawn>();
            Add<ProcessorSpaceshipAsteroidCollision>();
            //Add<ProcessorSpaceshipDeath>();
        }

        private static void AddOneFramesProcessors()
        {
            Add<ProcessorOneFrame<ComponentUserInput>>();
            Add<ProcessorOneFrame<ComponentCollision>>();
            Add<ProcessorOneFrame<ComponentSpawn>>();
            Add<ProcessorOneFrame<ComponentHealthChanged>>();
        }
    }
}