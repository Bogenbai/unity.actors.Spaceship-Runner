using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;


namespace Game.Source
{
    [Serializable]
    public class ComponentBraking
    {
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Braking = "Game.Source.ComponentBraking";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentBraking ComponentBraking(in this ent entity) =>
            ref Storage<ComponentBraking>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentBraking : Storage<ComponentBraking>
    {
        public override ComponentBraking Create() => new ComponentBraking();

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