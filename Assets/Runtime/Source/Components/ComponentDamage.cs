using Pixeye.Actors;
using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;


namespace Game.Source
{
    [Serializable]
    public class ComponentDamage
    {
        public int value;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Damage = "Game.Source.ComponentDamage";
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentDamage ComponentDamage(in this ent entity) =>
          ref Storage<ComponentDamage>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentDamage : Storage<ComponentDamage>
    {
        public override ComponentDamage Create() => new ComponentDamage();
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

