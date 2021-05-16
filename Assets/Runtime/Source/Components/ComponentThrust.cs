using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentThrust
    {
        public float thrustRotationVelocity;
        public float thrustRotation;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Thrust = "Game.Source.ComponentThrust";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentThrust ComponentThrust(in this ent entity) =>
            ref Storage<ComponentThrust>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentThrust : Storage<ComponentThrust>
    {
        public override ComponentThrust Create() => new ComponentThrust();

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