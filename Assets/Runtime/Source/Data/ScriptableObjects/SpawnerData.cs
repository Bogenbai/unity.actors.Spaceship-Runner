using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Spawn Data", menuName = "SciptableObjects/Spawn Data", order = 58)]
    public class SpawnerData : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float spawnDelay = 0.7f;
        [SerializeField] private List<Vector3> spawnPositions = new List<Vector3>();
        [SerializeField] private DestroyData destroyData;


        public float SpawnDelay => spawnDelay;
        public GameObject Prefab => prefab;
        public List<Vector3> SpawnPositions => spawnPositions;

        public DestroyData DestroyData => destroyData;
    }
}