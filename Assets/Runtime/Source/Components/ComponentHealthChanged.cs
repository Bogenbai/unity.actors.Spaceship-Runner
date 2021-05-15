using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components
{
    public class ComponentHealthChanged
    {
        public ComponentHealth componentHealth;
        public int amount;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string HealthChanged = "Game.Source.ComponentHealthChanged";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentHealthChanged ComponentHealthChanged(in this ent entity) =>
            ref Storage<ComponentHealthChanged>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentHealthChanged : Storage<ComponentHealthChanged>
    {
        public override ComponentHealthChanged Create() => new ComponentHealthChanged();

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