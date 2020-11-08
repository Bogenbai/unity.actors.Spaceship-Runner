using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
    sealed class ProcessorUserInput : Processor, ITick
    {
        public void Tick(float delta)
        {
            var direction = Vector3.zero;
            var horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput == 1)
            {
                direction = Vector3.right;
            }
            else if (horizontalInput == -1)
            {
                direction = Vector3.left;
            }
            
            var entityInputEvent = Entity.Create(DB.Prefabs.EmptyObject, Vector3.zero, true);
            entityInputEvent.transform.gameObject.name = "UserInput";
            var userInputEvent = entityInputEvent.Set<ComponentUserInputEvent>();
            userInputEvent.MoveDirection = direction;
        }
    }
}