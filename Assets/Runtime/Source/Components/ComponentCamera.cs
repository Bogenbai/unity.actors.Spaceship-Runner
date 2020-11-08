using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentCamera
    {
        [SerializeField, Sirenix.OdinInspector.ReadOnly]
        private Camera camera;

        public Camera Camera => camera;

        public void SetCamera(Camera camera)
        {
            this.camera = camera;
        }
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Camera = "Game.Source.ComponentCamera";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentCamera ComponentCamera(in this ent entity) =>
            ref Storage<ComponentCamera>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentCamera : Storage<ComponentCamera>
    {
        public override ComponentCamera Create() => new ComponentCamera();

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