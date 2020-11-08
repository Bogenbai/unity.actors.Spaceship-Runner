using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentHealth
    {
        public int value;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Health = "Game.Source.ComponentHealth";
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentHealth ComponentHealth(in this ent entity) =>
          ref Storage<ComponentHealth>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentHealth : Storage<ComponentHealth>
    {
        public override ComponentHealth Create() => new ComponentHealth();
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

