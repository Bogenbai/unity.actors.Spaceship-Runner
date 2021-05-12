using System;
using System.Collections.Generic;
using Pixeye.Actors;
using Runtime.Source.Components.Markers;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class represents a system that manages markers
    // Markers itself are an entities which are supposed to play a role of events in the ECS world
    // Markers has a lifetime. Marker's lifetime decreases by one every frame
    // Also marker can contain some data
    sealed class ProcessorMarkers : Processor, ITick
    {
        private Group<ComponentMarker> groupMarkers = default;
        private List<Action> requests = new List<Action>();

        public void Tick(float delta)
        {
            for (var i = 0; i < groupMarkers.length; i++)
            {
                var marker = groupMarkers[i];

                ReleaseDeadMarker(marker);
            }

            HandleRequests();
        }

        private void HandleRequests()
        {
            for (var i = 0; i < requests.Count; i++)
            {
                requests[i].Invoke();
            }

            requests.Clear();
        }

        public void Request<T>(T markerComponent)
        {
            requests.Add(() => Create(Layer, markerComponent));
        }

        private static void Create<T>(Layer layer, T markerComponent)
        {
            var markerEntity = layer.Entity.Create();
            markerEntity.Set(markerComponent);
            markerEntity.Set<ComponentMarker>();
        }

        private static void ReleaseDeadMarker(ent marker)
        {
            marker.Release();
        }
    }
}