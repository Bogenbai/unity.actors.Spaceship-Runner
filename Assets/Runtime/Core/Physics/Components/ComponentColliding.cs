using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Core.Physics.Components
{
    public class ComponentColliding
    {
        public readonly List<ent> CollidingEntities = new List<ent>();
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Colliding = "Game.Source.ComponentColliding";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentColliding ComponentColliding(in this ent entity) =>
            ref Storage<ComponentColliding>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentColliding : Storage<ComponentColliding>
    {
        public override ComponentColliding Create() => new ComponentColliding();

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