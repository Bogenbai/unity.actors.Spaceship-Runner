using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using UnityEngine;

namespace Runtime.Source.Signals
{
    public struct SignalSpawn
    {
        public ent SpawnInitiator;
        public SpawnerData SpawnerData;
        public Vector3 SpawnPosition;
    }
}