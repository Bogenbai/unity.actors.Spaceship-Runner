using MyBox;
using Pixeye.Actors;
using Runtime.Source.Data.ScriptableObjects;
using UnityEngine;

namespace Runtime.Source
{
    public class GameSettings : MonoCached
    {
        public static GameSettings Instance;
        public GameSettingsData Data => data;

        [SerializeField] private GameSettingsData data = null;

        private void Awake()
        {
            InitSingleton();
        }

        private void InitSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogError(
                    $"There can be only one {typeof(GameSettings)} on the scene. Object {gameObject.name} deleted");
                Destroy(gameObject);
            }
        }
    }
}