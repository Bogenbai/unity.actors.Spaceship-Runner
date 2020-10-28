using System.Collections.Generic;
using Game.Source;
using Pixeye.Actors;
using Random = Pixeye.Actors.Random;


namespace Runtime.Source.Tools.CameraShaker
{
    sealed class ProcessorCameraShake : Processor, ITick
    {
        private List<ShakeInstance> activeShakes = new List<ShakeInstance>();

        private Group<ComponentMainCamera> mainCameras = default;
        private Group<ComponentCameraShakeEvent> groupShakeEvents = default;

        public void Tick(float delta)
        {
            CameraShakesTick();

            for (int i = 0; i < groupShakeEvents.length; i++)
            {
                var shakeData = groupShakeEvents[i].ComponentCameraShakeEvent().shakeData;
                var shakeInstance = new ShakeInstance(shakeData, Random.Range(0, 100));
                AddShake(shakeInstance);
                groupShakeEvents[i].Release();
            }
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
    }
}