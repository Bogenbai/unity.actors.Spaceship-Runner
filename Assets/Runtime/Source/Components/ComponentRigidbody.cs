using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentRigidbody
    {
        [SerializeField, MyBox.ReadOnly]
        private Rigidbody rigidbody;
        public Rigidbody Rigidbody => rigidbody;

        public void SetRigidbody(Rigidbody unityRigidbodyComponent)
        {
            rigidbody = unityRigidbodyComponent;
        }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Rigidbody = "Game.Source.ComponentRigidbody";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentRigidbody ComponentRigidbody(in this ent entity) =>
            ref Storage<ComponentRigidbody>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentRigidbody : Storage<ComponentRigidbody>
    {
        public override ComponentRigidbody Create() => new ComponentRigidbody();

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