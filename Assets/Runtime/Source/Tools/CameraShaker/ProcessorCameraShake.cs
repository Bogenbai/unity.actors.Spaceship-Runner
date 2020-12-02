using System.Collections.Generic;
using Pixeye.Actors;
using Runtime.Source.Components.Tags;
using Runtime.Source.Tools.CameraShaker.Signals;
using Random = Pixeye.Actors.Random;


namespace Runtime.Source.Tools.CameraShaker
{
    // Based on plugin 'MilkShake Camera Shaker' 
    // Link to the Asset store page: https://assetstore.unity.com/packages/tools/camera/milkshake-camera-shaker-165604
    // Great thanks!
    
    // Class represents a system that shakes the main camera
    sealed class ProcessorCameraShake : Processor<SignalCameraShake>, ITick
    {
        private readonly List<ShakeInstance> activeShakes = new List<ShakeInstance>();
        private readonly Group<ComponentMainCamera> mainCameras = default;

        public void Tick(float delta)
        {
            CameraShakesTick();
        }

        private void CameraShakesTick()
        {
            var shake = new ShakeResult();

            for (var i = 0; i < activeShakes.Count; i++)
            {
                if (activeShakes[i].IsFinished)
                {
                    activeShakes.RemoveAt(i);
                    i--;
                    continue;
                }

                shake += activeShakes[i].UpdateShake(Time.deltaTime);
            }

            mainCameras[0].transform.localPosition = shake.PositionShake;
            mainCameras[0].transform.localEulerAngles = shake.RotationShake;
        }

        private void AddShake(ShakeInstance shakeInstance)
        {
            activeShakes.Add(shakeInstance);
        }

        public override void ReceiveEcs(ref SignalCameraShake signal, ref bool stopSignal)
        {
            var shakeData = signal.ShakeData;
            var shakeInstance = new ShakeInstance(shakeData, Random.Range(0, 100));
            AddShake(shakeInstance);
        }
    }
}