using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components.Markers
{
    public class ComponentUserInputMarker
    {
        public Vector3 MoveDirection { get; set; }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string UserInputMarker = "Game.Source.ComponentUserInputMarker";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentUserInputMarker ComponentUserInputMarker(in this ent entity) =>
            ref Storage<ComponentUserInputMarker>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentUserInputMarker : Storage<ComponentUserInputMarker>
    {
        public override ComponentUserInputMarker Create() => new ComponentUserInputMarker();

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