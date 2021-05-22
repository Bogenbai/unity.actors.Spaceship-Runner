using System.Collections.Generic;
using Pixeye.Actors;

namespace Runtime.Source.Processors
{
    // Class represents a system that manages OneFrames.
    // OneFrame itself are an entities which are supposed to play a role of events in the ECS world.
    // OneFrames have a lifetime. They live, surprisingly, only one frame.
    // Also OneFrame can contain some data.
    // If you want oneframe to be captured by all processors on the layer then register it using OneFramesCore.Register.
    sealed class ProcessorOneFrame<T> : Processor, ITick
    {
        private readonly Group<T> groupOneframes = default;
        private readonly List<T> requests = new List<T>();

        public void Tick(float delta)
        {
            foreach (var entity in groupOneframes)
            {
                ReleaseDeadOneFrame(entity);
            }

            HandleRequests();
        }

        private void HandleRequests()
        {
            for (var i = 0; i < requests.Count; i++)
            {
                Create(requests[i]);
            }

            requests.Clear();
        }

        public void Request(T oneframeComponent)
        {
            requests.Add(oneframeComponent);
        }

        private void Create(T oneframeComponent)
        {
            var oneframeEntity = Layer.Entity.Create();
            oneframeEntity.Set(oneframeComponent);
        }

        private static void ReleaseDeadOneFrame(ent oneframe)
        {
            oneframe.Release();
        }
    }
}