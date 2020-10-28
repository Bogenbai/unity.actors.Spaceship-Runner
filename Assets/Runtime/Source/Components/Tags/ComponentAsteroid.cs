using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
    [Serializable]
    public class ComponentAsteroid
    {
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Asteroid = "Game.Source.ComponentAsteroid";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentAsteroid ComponentAsteroid(in this ent entity) =>
            ref Storage<ComponentAsteroid>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentAsteroid : Storage<ComponentAsteroid>
    {
        public override ComponentAsteroid Create() => new ComponentAsteroid();

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