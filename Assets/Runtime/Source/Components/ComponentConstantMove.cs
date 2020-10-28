using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
    [Serializable]
    public class ComponentConstantMove
    {
        [SerializeField] private Vector3 movementDirection;
        [SerializeField] private float speed;

        public Vector3 MovementDirection
        {
            get => movementDirection;
            set => movementDirection = value;
        }

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Speed = "Game.Source.SpeedComponent";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentConstantMove ComponentConstantMove(in this ent entity) =>
            ref Storage<ComponentConstantMove>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageSpeedComponent : Storage<ComponentConstantMove>
    {
        public override ComponentConstantMove Create() => new ComponentConstantMove();

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