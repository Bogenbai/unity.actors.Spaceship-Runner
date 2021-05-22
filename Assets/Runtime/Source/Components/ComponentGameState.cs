using System;
using Pixeye.Actors;

namespace Runtime.Source.Components
{
    [Serializable]
    public class ComponentGameState
    {
        public GameStates state;
    }

    #region HELPERS

    public static partial class Component
    {
        public const string GameState = "Runtime.Source.Components.ComponentGameState";

        internal static ref ComponentGameState ComponentGameState(in this ent entity)
            => ref Storage<ComponentGameState>.components[entity.id];
    }

    sealed class StorageGameState : Storage<ComponentGameState>
    {
        public override ComponentGameState Create() => new ComponentGameState();

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