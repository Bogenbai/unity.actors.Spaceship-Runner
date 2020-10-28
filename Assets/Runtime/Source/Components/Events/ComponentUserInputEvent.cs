using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
    [Serializable]
    public class ComponentUserInputEvent
    {
        public Vector3 MoveDirection { get; set; }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string UserInputEvent = "Game.Source.ComponentUserInputEvent";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentUserInputEvent ComponentUserInputEvent(in this ent entity) =>
            ref Storage<ComponentUserInputEvent>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentUserInputEvent : Storage<ComponentUserInputEvent>
    {
        public override ComponentUserInputEvent Create() => new ComponentUserInputEvent();

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