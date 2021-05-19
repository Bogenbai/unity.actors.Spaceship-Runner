using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Core.Physics.Processors;
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
#if UNITY_IOS || UNITY_ANDROID
            Add<ProcessorUserTouchInput>();
#else
            Add<ProcessorUserInput>();
#endif
            Add<ProcessorSpawnTimer>();
            Add<ProcessorSpawner>();
            Add<ProcessorDestroyDestroyable>();
            Add<ProcessorRandomRotator>();
            Add<ProcessorScaleTo>();
            Add<ProcessorHealth>();
            Add<ProcessorScore>();
            Add<ProcessorScoreUi>();
            Add<ProcessorMove>();
            Add<ProcessorCameraShake>();
            Add<ProcessorSpaceshipMovementDirection>();
            Add<ProcessorSpaceshipMoveStateSetter>();
            Add<ProcessorSpaceshipThrottling>();
            Add<ProcessorSpaceshipBraking>();
            Add<ProcessorSpaceshipThrust>();
            Add<ProcessorSpaceshipMoveBounds>();
            Add<ProcessorSpaceshipRespawn>();
            Add<ProcessorSpaceshipAsteroidCollision>();
            Add<ProcessorSpaceshipDeath>();

            AddOneFramesProcessors();
            Add<ProcessorPhysics>();
        }

        private static void AddOneFramesProcessors()
        {
            Add<ProcessorOneFrame<ComponentUserInput>>();
            Add<ProcessorOneFrame<ComponentCollision>>();
            Add<ProcessorOneFrame<ComponentSpawn>>();
            Add<ProcessorOneFrame<ComponentHealthChanged>>();
            Add<ProcessorOneFrame<ComponentCameraShake>>();
        }
    }
}