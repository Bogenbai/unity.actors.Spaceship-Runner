using System;
using Pixeye.Actors;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentGame
    {
        public GameStates state;
    }

    #region HELPERS

    public static partial class Component
    {
        public const string Game = "Runtime.Source.Components.ComponentGame";

        internal static ref ComponentGame ComponentGame(in this ent entity)
            => ref Storage<ComponentGame>.components[entity.id];
    }

    sealed class StorageGame : Storage<ComponentGame>
    {
        public override ComponentGame Create() => new ComponentGame();

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