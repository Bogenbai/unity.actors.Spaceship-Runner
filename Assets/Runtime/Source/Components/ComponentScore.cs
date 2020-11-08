using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components
{
    public class ComponentScore
    {
        public int Score;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Score = "Game.Source.ComponentScore";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentScore ComponentScore(in this ent entity) =>
            ref Storage<ComponentScore>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentScore : Storage<ComponentScore>
    {
        public override ComponentScore Create() => new ComponentScore();

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