using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;


namespace Game.Source
{
    [Serializable]
    public class ComponentMainCamera
    {
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string MainCamera = "Game.Source.ComponentMainCamera";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentMainCamera ComponentMainCamera(in this ent entity) =>
            ref Storage<ComponentMainCamera>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentMainCamera : Storage<ComponentMainCamera>
    {
        public override ComponentMainCamera Create() => new ComponentMainCamera();

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