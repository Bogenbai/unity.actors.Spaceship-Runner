using System;
using System.Runtime.CompilerServices;
using MyBox;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentPlayerMovementData
    {
        [SerializeField] private PlayerMovementData parameters = null;
        [ReadOnly]public float currentThrustRotationVelocity;
        [ReadOnly] public Vector3 currentMoveDirectionNormalized;
        [ReadOnly] public float currentVelocityX;
        [ReadOnly] public float currentThrustRotation;
        public PlayerMovementData Parameters => parameters;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string PlayerMovement = "Game.Source.ComponentPlayerMovement";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentPlayerMovementData ComponentPlayerMovementData(in this ent entity) =>
            ref Storage<ComponentPlayerMovementData>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentPlayerMovement : Storage<ComponentPlayerMovementData>
    {
        public override ComponentPlayerMovementData Create() => new ComponentPlayerMovementData();

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