using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentMovementData
    {
        [SerializeField] private PlayerMovementData parameters = null;
        public float thrustRotationVelocity;
        public float thrustRotation;
        public float velocityX;
        public PlayerMovementData Parameters => parameters;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string MovementData = "Game.Source.ComponentMovementData";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentMovementData ComponentMovementData(in this ent entity) =>
            ref Storage<ComponentMovementData>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentMovementData : Storage<ComponentMovementData>
    {
        public override ComponentMovementData Create() => new ComponentMovementData();

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