using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components.Spawn
{
    [Serializable]
    public class ComponentSpawner
    {
        [SerializeField] private SpawnerData spawnerData = null;

        public SpawnerData SpawnerData => spawnerData;

        public float SpawnAfter { get; set; } = 0;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Spawner = "Game.Source.ComponentSpawner";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentSpawner ComponentSpawner(in this ent entity) =>
            ref Storage<ComponentSpawner>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentSpawner : Storage<ComponentSpawner>
    {
        public override ComponentSpawner Create() => new ComponentSpawner();

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