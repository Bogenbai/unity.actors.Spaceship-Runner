using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components.Markers
{
    public class ComponentMarker
    {
        public int LifeTime = 1;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Marker = "Game.Source.ComponentMarker";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentMarker ComponentMarker(in this ent entity) =>
            ref Storage<ComponentMarker>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentMarker : Storage<ComponentMarker>
    {
        public override ComponentMarker Create() => new ComponentMarker();

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