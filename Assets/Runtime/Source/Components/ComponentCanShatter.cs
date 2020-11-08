using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentCanShatter
    {
        [SerializeField] private GameObject shardPrefab;
        [SerializeField] private Vector3 shardScale = Vector3.one;
        [SerializeField] private int minShards = 3;
        [SerializeField] private int maxShards = 4;

        public Vector3 ShardScale
        {
            get => shardScale;
            set => shardScale = value;
        }

        public int MinShards
        {
            get => minShards;
            set => minShards = value;
        }

        public int MaxShards
        {
            get => maxShards;
            set => maxShards = value;
        }

        public GameObject ShardPrefab
        {
            get => shardPrefab;
            set => shardPrefab = value;
        }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string CanShatter = "Game.Source.ComponentCanShatter";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentCanShatter ComponentCanShatter(in this ent entity) =>
            ref Storage<ComponentCanShatter>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentCanShatter : Storage<ComponentCanShatter>
    {
        public override ComponentCanShatter Create() => new ComponentCanShatter();

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