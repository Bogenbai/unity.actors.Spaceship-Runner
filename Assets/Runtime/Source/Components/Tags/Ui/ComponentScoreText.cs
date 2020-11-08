using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components.Tags.Ui
{
    [Serializable]
    public class ComponentScoreText
    {
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string ScoreText = "Game.Source.ComponentScoreText";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentScoreText ComponentScoreText(in this ent entity) =>
            ref Storage<ComponentScoreText>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentScoreText : Storage<ComponentScoreText>
    {
        public override ComponentScoreText Create() => new ComponentScoreText();

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