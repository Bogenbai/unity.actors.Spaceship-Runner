using Pixeye.Actors;
using Runtime.Source.Components;
using UnityEngine;

namespace Runtime.Source.Actors
{
    [RequireComponent(typeof(Camera))]
    public class ActorCamera : Actor
    {
        [FoldoutGroup("Components", true)] public ComponentMainCamera componentMainCamera;
        [FoldoutGroup("Components", true)] public ComponentCamera componentCamera;
        
        protected override void Setup()
        {
            componentCamera.SetCamera(GetComponent<Camera>());
            
            entity.Set(componentMainCamera);
            entity.Set(componentCamera);
        }
    }
}