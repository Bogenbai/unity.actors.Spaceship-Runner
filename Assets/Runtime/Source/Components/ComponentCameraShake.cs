using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Tools.CameraShaker;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components
{
    public class ComponentCameraShake
    {
        public ShakePreset ShakeData;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string CameraShake = "Game.Source.ComponentCameraShake";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentCameraShake ComponentCameraShake(in this ent entity) =>
            ref Storage<ComponentCameraShake>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentCameraShake : Storage<ComponentCameraShake>
    {
        public override ComponentCameraShake Create() => new ComponentCameraShake();

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