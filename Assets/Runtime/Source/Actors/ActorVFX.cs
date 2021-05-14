using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Actors
{
    public class ActorVFX : Actor
    {
        [FoldoutGroup("Components", true)]
        public ComponentDestroyable componentDestroyable;
        [FoldoutGroup("Components", true)]
        public ComponentConstantMove componentConstantMove;

        protected override void Setup()
        {
            entity.Set(componentConstantMove);
            entity.Set(componentDestroyable);
        }
    }
}
