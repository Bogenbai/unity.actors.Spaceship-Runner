using System;
using Pixeye.Actors;

namespace Runtime.Source.Components.Ui
{
    [Serializable]
    public class ComponentGameOverMenuUi
    {
    }

    #region HELPERS

    public static partial class Component
    {
        public const string GameOverMenuUi = "Runtime.Source.Components.Ui.ComponentGameOverMenuUi";

        internal static ref ComponentGameOverMenuUi ComponentGameOverMenuUi(in this ent entity)
            => ref Storage<ComponentGameOverMenuUi>.components[entity.id];
    }

    sealed class StorageGameOverMenuUi : Storage<ComponentGameOverMenuUi>
    {
        public override ComponentGameOverMenuUi Create() => new ComponentGameOverMenuUi();

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