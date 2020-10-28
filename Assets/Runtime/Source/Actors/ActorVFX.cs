using Pixeye.Actors;
using Sirenix.OdinInspector;

namespace Game.Source
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
