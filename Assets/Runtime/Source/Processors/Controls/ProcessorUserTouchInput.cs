﻿using System;
using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Events;
using Runtime.Source.Components.Tags;
using Runtime.Source.Data;
using UnityEngine;

namespace Runtime.Source.Processors.Controls
{
    sealed class ProcessorUserTouchInput : Processor, ITick
    {
        private Group<ComponentSpaceship> groupPlayers = default;
        private Group<ComponentMainCamera, ComponentCamera> groupMainCamera = default;

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

                        if (Math.Abs(worldPosition.x - playerX) > 1.3f)
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

                    var entityInputEvent = Entity.Create(DB.Prefabs.EmptyObject, Vector3.zero, true);
                    entityInputEvent.transform.gameObject.name = "UserInput Event";
                    var userInputEvent = entityInputEvent.Set<ComponentUserInputEvent>();
                    userInputEvent.MoveDirection = direction;
                }
            }
        }
    }
}