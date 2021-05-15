using UnityEngine;

namespace Runtime.Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New DestroyParameters Data", menuName = "SciptableObjects/DestroyParameters",
        order = 58)]
    public class DestroyData : ScriptableObject
    {
        [SerializeField] private float destroyAtCoordinate = -20;
        [SerializeField] private Axis destroyAtAxis = Axis.Z;
        [SerializeField] private ComparisonType comparisonType = ComparisonType.Below;

        public float DestroyAtCoordinate => destroyAtCoordinate;
        public Axis DestroyAtAxis => destroyAtAxis;
        public ComparisonType ComparisonType => comparisonType;
    }
}