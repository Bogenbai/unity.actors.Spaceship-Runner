using System;
using Pixeye.Actors;

namespace Runtime.Source.Components.Ui
{
    [Serializable]
    public class ComponentGameplayUi
    {
    }

    #region HELPERS

    public static partial class Component
    {
        public const string GameplayUi = "Runtime.Source.Components.Ui.ComponentGameplayUi";

        internal static ref ComponentGameplayUi ComponentGameplayUi(in this ent entity)
            => ref Storage<ComponentGameplayUi>.components[entity.id];
    }

    sealed class StorageGameplayUi : Storage<ComponentGameplayUi>
    {
        public override ComponentGameplayUi Create() => new ComponentGameplayUi();

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