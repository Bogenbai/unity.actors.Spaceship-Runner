using System;
using Pixeye.Actors;
using Runtime.Source.Components.Markers;
using Runtime.Source.Tools;
using UnityEngine;

namespace Runtime.Source.Processors.Controls
{
    // Class represents a system which is handles user input on PC, Mac or Linux devices
    sealed class ProcessorUserInput : Processor, ITick
    {
        public void Tick(float delta)
        {
            var direction = Vector3.zero;
            var horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Math.Abs(horizontalInput - 1) < Toolbox.Tolerance)
            {
                direction = Vector3.right;
            }
            else if (Math.Abs(horizontalInput + 1) < Toolbox.Tolerance)
            {
                direction = Vector3.left;
            }

            var userInputMarker = new ComponentUserInputMarker {MoveDirection = direction};
            MarkersCore.Register(Layer, userInputMarker);
        }
    }
}