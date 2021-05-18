using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Core.Physics.Components
 {
   public class ComponentCollisionStopped
   {
        public ent ReceiverEntity { get; set; }
        public ent SenderEntity { get; set; }
   }
 
   #region HELPERS
 
   [Il2CppSetOption(Option.NullChecks, false)]
   [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
   [Il2CppSetOption(Option.DivideByZeroChecks, false)]
   static partial class Component
   {
     public const string CollisionStopped = "Game.Source.ComponentCollisionStopped";
     [MethodImpl(MethodImplOptions.AggressiveInlining)]
     public static ref ComponentCollisionStopped ComponentCollisionStopped(in this ent entity) =>
       ref Storage<ComponentCollisionStopped>.components[entity.id];
   }

   [Il2CppSetOption(Option.NullChecks, false)]
   [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
   [Il2CppSetOption(Option.DivideByZeroChecks, false)]
   sealed class StorageComponentCollisionStopped : Storage<ComponentCollisionStopped>
   {
     public override ComponentCollisionStopped Create() => new ComponentCollisionStopped();
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
 
