using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Core.Physics.Components
{
    [Serializable]
    public class ComponentBoxCollider
    {
        public float halfWidth = 0.5f;
        public float halfHeight = 0.5f;
        public float halfLength = 0.5f;
        public Vector3 center;

        public float Width
        {
            get { return halfWidth * 2; }
            set { halfWidth = value * 0.5f; }
        }

        public float Height
        {
            get { return halfHeight * 2; }
            set { halfHeight = value * 0.5f; }
        }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string BoxCollider = "Game.Source.ComponentBoxCollider";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentBoxCollider ComponentBoxCollider(in this ent entity) =>
            ref Storage<ComponentBoxCollider>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentBoxCollider : Storage<ComponentBoxCollider>
    {
        public override ComponentBoxCollider Create() => new ComponentBoxCollider();

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