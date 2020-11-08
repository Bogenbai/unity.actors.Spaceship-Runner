using System.Runtime.CompilerServices;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;

namespace Runtime.Source.Components.Spawn
 {
   public class ComponentCanSpawn { }
 
   #region HELPERS
 
   [Il2CppSetOption(Option.NullChecks, false)]
   [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
   [Il2CppSetOption(Option.DivideByZeroChecks, false)]
   static partial class Component
   {
     public const string StartSpawnLoopEvent = "Game.Source.ComponentStartSpawnLoopEvent";
     [MethodImpl(MethodImplOptions.AggressiveInlining)]
     public static ref ComponentCanSpawn ComponentCanSpawn(in this ent entity) =>
       ref Storage<ComponentCanSpawn>.components[entity.id];
   }

   [Il2CppSetOption(Option.NullChecks, false)]
   [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
   [Il2CppSetOption(Option.DivideByZeroChecks, false)]
   sealed class StorageComponentStartSpawnLoopEvent : Storage<ComponentCanSpawn>
   {
     public override ComponentCanSpawn Create() => new ComponentCanSpawn();
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
 
