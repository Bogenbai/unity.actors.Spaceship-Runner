using Pixeye.Actors;
using UnityEngine;

namespace Runtime.Source.Data
{
    public static class DataBase
    {
        public static class Prefabs
        {
            private static string PrefabsPath => "Prefabs/";

            public static GameObject PlayerSpaceship =>
                Box.Load<GameObject>(PrefabsPath + "ActorPlayerSpaceship");

            public static GameObject Asteroid =>
                Box.Load<GameObject>(PrefabsPath + "ActorAsteroid");

            public static GameObject AsteroidShard =>
                Box.Load<GameObject>(PrefabsPath + "ActorAsteroidShard");

            public static GameObject VfxSparks =>
                Box.Load<GameObject>(PrefabsPath + "ActorVfx Sparks");

            public static GameObject VfxPlasmaExplosion =>
                Box.Load<GameObject>(PrefabsPath + "ActorVfx PlasmaExplosion");

            public static GameObject VfxBluePlasmaExplosion =>
                Box.Load<GameObject>(PrefabsPath + "ActorVfx BluePlasmaExplosion");

            public static GameObject EmptyGameObject = new GameObject();
        }

        public static class ScriptableObjects
        {
            private static string Path => "Data/";

            public static ScriptableObject CameraShakeOnAsteroidHit =>
                Box.Load<ScriptableObject>(Path + "CameraShakeOnAsteroidHit");
        }
    }
}