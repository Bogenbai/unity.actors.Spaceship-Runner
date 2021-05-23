using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Core.Physics.Processors;
using Runtime.Source.Comparers;
using Runtime.Source.Components;
using Runtime.Source.Components.Spawn;
using Runtime.Source.Processors;
using Runtime.Source.Processors.Input;
using Runtime.Source.Processors.Ui;
using Runtime.Source.Tools.CameraShaker;

namespace Runtime.Source.Layers
{
    public class LayerGame : Layer<LayerGame>
    {
        protected override void Setup()
        {
            Pixeye.Actors.Comparers.Add(EqualityGameStates.Default);

#if UNITY_IOS || UNITY_ANDROID
            Add<ProcessorUserTouchInput>();
#else
            Add<ProcessorUserInput>();
#endif
            Add<ProcessorGameInitializer>();
            Add<ProcessorGameStates>();
            Add<ProcessorSpawnTimer>();
            Add<ProcessorSpawner>();
            Add<ProcessorDestroyDestroyable>();
            Add<ProcessorRandomRotator>();
            Add<ProcessorScaleTo>();
            Add<ProcessorHealth>();
            Add<ProcessorScore>();
            Add<ProcessorUiToggler>();
            Add<ProcessorUiScore>();
            Add<ProcessorMove>();
            Add<ProcessorCameraShake>();
            Add<ProcessorSpaceshipMovementDirection>();
            Add<ProcessorSpaceshipMoveStateSetter>();
            Add<ProcessorSpaceshipThrottling>();
            Add<ProcessorSpaceshipBraking>();
            Add<ProcessorSpaceshipThrust>();
            Add<ProcessorSpaceshipMoveBounds>();
            Add<ProcessorSpaceshipSpawner>();
            Add<ProcessorSpaceshipAsteroidCollision>();
            Add<ProcessorSpaceshipDeath>();
            Add<ProcessorPhysics>();

            AddOneFramesProcessors();
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