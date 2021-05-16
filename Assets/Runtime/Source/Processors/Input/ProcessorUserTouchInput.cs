using System;
using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using Runtime.Source.Tools;
using UnityEngine;

namespace Runtime.Source.Processors.Input
{
    // Class represents a system which is handles user input on mobile devices
    sealed class ProcessorUserTouchInput : Processor, ITick
    {
        private Group<ComponentSpaceship> groupPlayers = default;
        private Group<ComponentMainCamera, ComponentCamera> groupMainCamera = default;

        // How far user need to touch from the player spaceship to create a user input event
        private const float DistanceToReact = 1.3f;

        public void Tick(float delta)
        {
            foreach (var entity in groupPlayers)
            {
                if (Camera.main != null)
                {
                    var direction = Vector3.zero;

                    if (UnityEngine.Input.GetMouseButton(0))
                    {
                        var mousePos = UnityEngine.Input.mousePosition;
                        mousePos.z = entity.transform.position.z;
                        var mainCamera = groupMainCamera[0].ComponentCamera().Camera;
                        var worldPosition = mainCamera.ScreenToWorldPoint(mousePos);
                        var playerX = entity.transform.position.x;

                        if (Math.Abs(worldPosition.x - playerX) > DistanceToReact)
                        {
                            if (worldPosition.x > playerX)
                            {
                                direction = Vector3.right;
                            }
                            else if (worldPosition.x < playerX)
                            {
                                direction = Vector3.left;
                            }
                        }
                    }

                    var userInputMarker = new ComponentUserInput {MoveDirection = direction};
                    OneFramesCore.Register(Layer, userInputMarker);
                }
            }
        }
    }
}