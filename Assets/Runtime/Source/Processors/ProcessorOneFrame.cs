using System.Collections.Generic;
using Pixeye.Actors;

namespace Runtime.Source.Processors
{
    // Class represents a system that manages OneFrames
    // OneFrame itself are an entities which are supposed to play a role of events in the ECS world
    // OneFrames have a lifetime. They live, surprisingly, only one frame
    // Also OneFrame can contain some data
    sealed class ProcessorOneFrame<T> : Processor, ITick
    {
        private Group<T> groupOneframes = default;
        private List<T> requests = new List<T>();

        public void Tick(float delta)
        {
            for (var i = 0; i < groupOneframes.length; i++)
            {
                ReleaseDeadOneFrame(groupOneframes[i]);
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
            var markerEntity = Layer.Entity.Create();
            markerEntity.Set(oneframeComponent);
        }

        private static void ReleaseDeadOneFrame(ent marker)
        {
            marker.Release();
        }
    }
}