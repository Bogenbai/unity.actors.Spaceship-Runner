using System;
using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Markers;
using Runtime.Source.Components.Tags;
using Runtime.Source.Tools;
using UnityEngine;

namespace Runtime.Source.Processors.Controls
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
            for (int i = 0; i < groupPlayers.length; i++)
            {
                if (Camera.main != null)
                {
                    var direction = Vector3.zero;

                    if (Input.GetMouseButton(0))
                    {
                        var mousePos      = Input.mousePosition;
                        mousePos.z                = groupPlayers[i].transform.position.z;
                        var mainCamera            = groupMainCamera[0].ComponentCamera().Camera;
                        var worldPosition = mainCamera.ScreenToWorldPoint(mousePos);
                        var playerX         = groupPlayers[i].transform.position.x;

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

                    var userInputMarkerEntity = MarkersCore.Create<ComponentUserInputMarker>(Layer);

                    var userInputMarker = userInputMarkerEntity.ComponentUserInputMarker();
                    userInputMarker.MoveDirection = direction;
                }
            }
        }
    }
}