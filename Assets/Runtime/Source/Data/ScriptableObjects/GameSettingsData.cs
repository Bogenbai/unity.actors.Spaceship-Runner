using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New GameSettings Data", menuName = "SciptableObjects/GameSettings", order = 58)]
    [InlineEditor]
    public class GameSettingsData : ScriptableObject
    {
        [PropertyRange(0, 1000)]
        [ShowInInspector]
        public float ScoreScale { get; private set; } = 1;
    }
}