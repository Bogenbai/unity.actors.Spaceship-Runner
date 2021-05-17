using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Core.Physics.Components
{
    [Serializable]
    public class ComponentBoxCollider
    {
        public float HalfWidth = 0.5f;
        public float HalfHeight = 0.5f;
        public float HalfLength = 0.5f;

        public float Width
        {
            get { return HalfWidth * 2; }
            set { HalfWidth = value * 0.5f; }
        }

        public float Height
        {
            get { return HalfHeight * 2; }
            set { HalfHeight = value * 0.5f; }
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