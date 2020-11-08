using System;
using System.Runtime.CompilerServices;
using Pixeye.Actors;
using TMPro;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Runtime.Source.Components.Ui
{
    [Serializable]
    public class ComponentText
    {
        [SerializeField] private TMP_Text text = null;
        public TMP_Text Text => text;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Text = "Game.Source.ComponentText";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentText ComponentText(in this ent entity) =>
            ref Storage<ComponentText>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentText : Storage<ComponentText>
    {
        public override ComponentText Create() => new ComponentText();

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