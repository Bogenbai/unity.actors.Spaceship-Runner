using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Tools.CameraShaker;


namespace Game.Source
{
    [Serializable]
    public class ComponentCameraShakeEvent
    {
        public ShakePreset shakeData;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string CameraShakeEvent = "Game.Source.ComponentCameraShakeEvent";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentCameraShakeEvent ComponentCameraShakeEvent(in this ent entity) =>
            ref Storage<ComponentCameraShakeEvent>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentCameraShakeEvent : Storage<ComponentCameraShakeEvent>
    {
        public override ComponentCameraShakeEvent Create() => new ComponentCameraShakeEvent();

        // Use for cleaning components that were removed at the current frame.
        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
            }
        }
    }

    #endregion
}