using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Source.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New PlayerMovement Data", menuName = "My SciptableObjects/PlayerMovement Data", order = 58)]
    [InlineEditor]
    public class PlayerMovementData : ScriptableObject
    {
        [SerializeField] private float maxVelocityX = 20;
        [SerializeField] private float interpolationAcceleration = 5;
        [SerializeField] private float acceleration = 20;
        [SerializeField] private float accelerationBrakingScale = 2;
        [SerializeField] private float thrustRotationScale = 3;
        [SerializeField] private float thrustRotationSmooth = 0.05f;
        [SerializeField] private float leftMovementBoundX = -5;
        [SerializeField] private float rightMovementBoundX = 5;

        public float MaxVelocityX => maxVelocityX;
        public float InterpolationAcceleration => interpolationAcceleration;
        public float Acceleration => acceleration;
        public float AccelerationBrakingScale => accelerationBrakingScale;
        public float ThrustRotationScale => thrustRotationScale;
        public float ThrustRotationSmooth => thrustRotationSmooth;
        public float LeftMovementBoundX => leftMovementBoundX;
        public float RightMovementBoundX => rightMovementBoundX;
    }
}