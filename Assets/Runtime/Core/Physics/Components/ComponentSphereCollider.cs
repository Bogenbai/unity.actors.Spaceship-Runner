using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Core.Physics.Components
{
    [Serializable]
    public class ComponentSphereCollider
    {
        public Vector3 center;
        public float Radius = 0.5f;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string SphereCollider = "Game.Source.ComponentSphereCollider";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentSphereCollider ComponentSphereCollider(in this ent entity) =>
            ref Storage<ComponentSphereCollider>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentSphereCollider : Storage<ComponentSphereCollider>
    {
        public override ComponentSphereCollider Create() => new ComponentSphereCollider();

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