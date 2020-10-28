using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using UnityEngine;


namespace Game.Source
{
    [Serializable]
    public class ComponentSpawnEvent
    {
        public ent SpawnInitiator { get; set; }
        public SpawnerData SpawnerData { get; set; }
        public Vector3 SpawnPosition { get; set; }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string SpawnEvent = "Game.Source.ComponentSpawnEvent";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentSpawnEvent ComponentSpawnEvent(in this ent entity) =>
            ref Storage<ComponentSpawnEvent>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentSpawnEvent : Storage<ComponentSpawnEvent>
    {
        public override ComponentSpawnEvent Create() => new ComponentSpawnEvent();

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