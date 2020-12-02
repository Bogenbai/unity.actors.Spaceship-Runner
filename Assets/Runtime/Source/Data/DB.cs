using Pixeye.Actors;
using UnityEngine;

namespace Runtime.Source.Data
{
    public static class DB
    {
        public static class Prefabs
        {
            public const string PrefabsFolder = "Prefabs/";

            public static readonly GameObject ActorPlayerSpaceship = Box.Load<GameObject>(PrefabsFolder + "ActorPlayerSpaceship");
            public static readonly GameObject Asteroid = Box.Load<GameObject>(PrefabsFolder + "ActorAsteroid");
            public static readonly GameObject AsteroidShard = Box.Load<GameObject>(PrefabsFolder + "ActorAsteroidShard");
            public static readonly GameObject VfxSparks = Box.Load<GameObject>(PrefabsFolder + "ActorVfx Sparks");
            public static readonly GameObject VfxPlasmaExplosion = Box.Load<GameObject>(PrefabsFolder + "ActorVfx PlasmaExplosion");
            public static readonly GameObject VfxBluePlasmaExplosion = Box.Load<GameObject>(PrefabsFolder + "ActorVfx BluePlasmaExplosion");
        }

        public static class ScriptableObjects
        {
            public const string ScriptableObjectsFolder = "Data/";
            public static readonly ScriptableObject CameraShakeOnAsteroidHit = Box.Load<ScriptableObject>(ScriptableObjectsFolder + "CameraShakeOnAsteroidHit");
        }
    }
}