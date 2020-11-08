using Pixeye.Actors;
using Runtime.Source.Signals;
using UnityEngine;


namespace Game.Source
{
    sealed class ProcessorSpaceshipMove : Processor, ITick
    {
        Group<ComponentSpaceship, ComponentPlayerMovementData> groupSpaceships = default;
        Group<ComponentUserInputEvent> groupInputEvents = default;

        public void Tick(float delta)
        {
            for (int i = 0; i < groupInputEvents.length; i++)
            {
                var direction = groupInputEvents[i].ComponentUserInputEvent().MoveDirection;
                
                for (int j = 0; j < groupSpaceships.length; j++)
                {
                    var spaceship = groupSpaceships[j];
                    var componentPlayerMovementData = spaceship.ComponentPlayerMovementData();
                    var velocityX = componentPlayerMovementData.CurrentVelocityX;
                    componentPlayerMovementData.CurrentMoveDirectionNormalized = direction;
                
                    direction = new Vector3(velocityX * delta, 0, 0);
                    spaceship.transform.position += direction;
                }
                
                groupInputEvents[i].Release();
            }
        }

        // public override void ReceiveEcs(ref SignalUserInput signal, ref bool stopSignal)
        // {
        //     var direction = signal.MoveDirection;
        //
        //     for (int j = 0; j < groupSpaceships.length; j++)
        //     {
        //         var spaceship = groupSpaceships[j];
        //         var componentPlayerMovementData = spaceship.ComponentPlayerMovementData();
        //         var velocityX = componentPlayerMovementData.CurrentVelocityX;
        //         componentPlayerMovementData.CurrentMoveDirectionNormalized = direction;
        //
        //         direction = new Vector3(velocityX * Time.deltaTime, 0, 0);
        //         spaceship.transform.position += direction;
        //     }
        // }
    }
}