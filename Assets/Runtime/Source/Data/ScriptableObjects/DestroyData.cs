using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New DestroyParameters Data", menuName = "SciptableObjects/DestroyParameters", order = 58)]
    [InlineEditor]
    public class DestroyData : ScriptableObject
    {
        [FoldoutGroup("Destroy rules"), SerializeField]
        private bool destroyAfterDelay = true;

        [FoldoutGroup("Destroy rules"), ShowIf("destroyAfterDelay")] [SerializeField]
        private float destroyAfter = 0;

        [FoldoutGroup("Destroy rules"), HideIf("destroyAfterDelay")] [SerializeField]
        private float destroyAtCoordinate = -20;

        [FoldoutGroup("Destroy rules"), HideIf("destroyAfterDelay")] [SerializeField]
        private Axis destroyAtAxis = Axis.Z;

        [FoldoutGroup("Destroy rules"), HideIf("destroyAfterDelay")] [SerializeField]
        private ComparisonSign comparisonSign = ComparisonSign.Below;

        public bool DestroyAfterDelay => destroyAfterDelay;
        public float DestroyAfter => destroyAfter;
        public float DestroyAtCoordinate => destroyAtCoordinate;
        public Axis DestroyAtAxis => destroyAtAxis;
        public ComparisonSign ComparisonSign => comparisonSign;
    }
}