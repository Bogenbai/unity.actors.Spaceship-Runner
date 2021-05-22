using System;
using Pixeye.Actors;

namespace Runtime.Source.Components.Ui
{
    [Serializable]
    public class ComponentStartMenuUi
    {
    }

    #region HELPERS

    public static partial class Component
    {
        public const string StartMenuUi = "Runtime.Source.Components.Ui.ComponentStartMenuUi";

        internal static ref ComponentStartMenuUi ComponentStartMenuUi(in this ent entity)
            => ref Storage<ComponentStartMenuUi>.components[entity.id];
    }

    sealed class StorageStartMenuUi : Storage<ComponentStartMenuUi>
    {
        public override ComponentStartMenuUi Create() => new ComponentStartMenuUi();

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