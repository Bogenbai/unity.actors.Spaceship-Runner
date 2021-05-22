using System;
using Pixeye.Actors;
using TMPro;

namespace Runtime.Source.Components.Ui
{
    [Serializable]
    public class ComponentUiScore
    {
        public TMP_Text scoreText;
    }

    #region HELPERS

    public static partial class Component
    {
        public const string UiScore = "a.ComponentUiScore";

        internal static ref ComponentUiScore ComponentUiScore(in this ent entity)
            => ref Storage<ComponentUiScore>.components[entity.id];
    }

    sealed class StorageUiScore : Storage<ComponentUiScore>
    {
        public override ComponentUiScore Create() => new ComponentUiScore();

        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
                //dispose(reset) logic
            }
        }
    }

    #endregion
}