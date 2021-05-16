using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentSpaceship
    {
        [SerializeField] private PlayerMovementData parameters = null;
        public Vector3 startPosition;
        public PlayerMovementData Parameters => parameters;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Spaceship = "Game.Source.ComponentSpaceship";
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentSpaceship ComponentSpaceship(in this ent entity) =>
          ref Storage<ComponentSpaceship>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentSpaceship : Storage<ComponentSpaceship>
    {
        public override ComponentSpaceship Create() => new ComponentSpaceship();
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

