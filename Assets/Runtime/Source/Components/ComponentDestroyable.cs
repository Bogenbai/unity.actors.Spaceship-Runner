using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using UnityEngine;


namespace Game.Source
{
    [Serializable]
    public class ComponentDestroyable
    {
        [SerializeField]
        private DestroyData destroyData;
        
        public DestroyData DestroyData { get => destroyData; set => destroyData = value; }
        public float Lifetime { get; set; }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string DestroySpawnedEntityEvent = "Game.Source.ComponentDestroySpawnedEntityEvent";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentDestroyable ComponentDestroyable(in this ent entity) =>
            ref Storage<ComponentDestroyable>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentDestroySpawnedEntityEvent : Storage<ComponentDestroyable>
    {
        public override ComponentDestroyable Create() => new ComponentDestroyable();

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