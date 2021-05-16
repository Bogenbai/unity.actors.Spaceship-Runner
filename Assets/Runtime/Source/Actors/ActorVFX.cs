using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Actors
{
    public class ActorVFX : Actor
    {
        [FoldoutGroup("Components", true)]
        public ComponentDestroyable componentDestroyable;
        [FoldoutGroup("Components", true)]
        public ComponentMove componentMove;

        protected override void Setup()
        {
            entity.Set(componentMove);
            entity.Set(componentDestroyable);
        }
    }
}
