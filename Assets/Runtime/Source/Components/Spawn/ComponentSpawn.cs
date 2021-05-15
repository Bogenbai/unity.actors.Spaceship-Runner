using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components.Spawn
{
    public class ComponentSpawn
    {
        public ent SpawnInitiator;
        public SpawnerData SpawnerData;
        public Vector3 SpawnPosition;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Spawn = "Game.Source.ComponentSpawn";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentSpawn ComponentSpawn(in this ent entity) =>
            ref Storage<ComponentSpawn>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentSpawn : Storage<ComponentSpawn>
    {
        public override ComponentSpawn Create() => new ComponentSpawn();

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