using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Core.Physics.Components
{
    [Serializable]
    public class ComponentRigid
    {
        public Vector3 velocity;
        public Vector3 force;
        public float mass;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Rigid = "Game.Source.ComponentRigid";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentRigid ComponentRigid(in this ent entity) =>
            ref Storage<ComponentRigid>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentRigid : Storage<ComponentRigid>
    {
        public override ComponentRigid Create() => new ComponentRigid();

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