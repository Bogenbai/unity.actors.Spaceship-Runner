using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentThrottling { }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Throttling = "Game.Source.ComponentThrottling";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentThrottling ComponentThrottling(in this ent entity) =>
            ref Storage<ComponentThrottling>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentThrottling : Storage<ComponentThrottling>
    {
        public override ComponentThrottling Create() => new ComponentThrottling();

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