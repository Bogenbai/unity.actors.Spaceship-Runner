using Pixeye.Actors;
using Runtime.Core.Physics.Components;
using Runtime.Source.Components;
using Runtime.Source.Data;
using Runtime.Source.Tools;
using Runtime.Source.Tools.CameraShaker;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Source.Processors
{
    // Class represents a system that handles spaceships and asteroids collisions
    sealed class ProcessorSpaceshipAsteroidCollision : Processor, ITick
    {
        private readonly Group<ComponentCollision> groupCollisions = default;

        public void Tick(float delta)
        {
            foreach (var entity in groupCollisions)
            {
                if (entity.ComponentCollision().CollisionPoints != null)
                {
                    var collisionInitiator = entity.ComponentCollision().SenderEntity;

                    if (collisionInitiator.exist)
                    {
                        if (collisionInitiator.Has<ComponentAsteroid>() &&
                            entity.ComponentCollision().ReceiverEntity.Has<ComponentSpaceship>())
                        {
                            HandleCollision(entity.ComponentCollision(), collisionInitiator);
                            entity.Release();
                        }
                    }
                }
            }
        }

        private void HandleCollision(ComponentCollision componentCollision, ent collisionInitiator)
        {
            var spaceshipEntity = componentCollision.ReceiverEntity;
            var asteroidEntity = collisionInitiator;

            if (spaceshipEntity.Has<ComponentHealth>() &&
                asteroidEntity.Has<ComponentDamage>())
            {
                var componentHealth = spaceshipEntity.ComponentHealth();
                var damage = asteroidEntity.ComponentDamage().value;
                SendHealthChangeSignal(componentHealth, damage);
            }

            Explosion(componentCollision);
            CreateCameraShakeSignal();

            collisionInitiator.Release();
        }

        private void SendHealthChangeSignal(ComponentHealth cHealth, int amount)
        {
            var componentHealthChanged = new ComponentHealthChanged()
            {
                componentHealth = cHealth,
                amount = amount
            };

            OneFramesCore.Register(Layer, componentHealthChanged);
        }

        private void Explosion(ComponentCollision componentCollision)
        {
            CreateShards(componentCollision);
            CreateVFX(componentCollision);
        }

        private void CreateVFX(ComponentCollision componentCollision)
        {
            var sparksPosition = componentCollision.SenderEntity.transform.position;
            Actor.Create(DataBase.Prefabs.VfxSparks, sparksPosition, true);
            Actor.Create(DataBase.Prefabs.VfxPlasmaExplosion, sparksPosition, true);
        }

        private void CreateShards(ComponentCollision componentCollision)
        {
            var collisionInitiator = componentCollision.SenderEntity;

            if (collisionInitiator.Has<ComponentCanShatter>() == false) return;

            var componentShatter = collisionInitiator.ComponentCanShatter();
            var shardsCount = Random.Range(componentShatter.MinShards, componentShatter.MaxShards + 1);

            for (var j = 0; j < shardsCount; j++)
            {
                var shardPosition = collisionInitiator.transform.position + GetRandomVector3() / 3;
                var shard = Layer.Actor.Create(componentShatter.ShardPrefab, shardPosition, true);
                shard.transform.localScale = componentShatter.ShardScale;
            }
        }

        private void CreateCameraShakeSignal()
        {
            var shakeData = DataBase.ScriptableObjects.CameraShakeOnAsteroidHit;

            var cCameraShake = new ComponentCameraShake {ShakeData = (ShakePreset) shakeData};

            OneFramesCore.Register(Layer, cCameraShake);
        }

        private Vector3 GetRandomVector3()
        {
            return new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        }
    }
}