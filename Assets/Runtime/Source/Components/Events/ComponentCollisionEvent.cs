using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components.Events
{
    public class ComponentCollisionEvent
    {
        public Collision Collision { get; set; }
        public ent ReceiverEntity { get; set; }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string PlayerAsteroidCollision = "Game.Source.ComponentPlayerAsteroidCollision";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentCollisionEvent ComponentCollision(in this ent entity) =>
            ref Storage<ComponentCollisionEvent>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentPlayerAsteroidCollision : Storage<ComponentCollisionEvent>
    {
        public override ComponentCollisionEvent Create() => new ComponentCollisionEvent();

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