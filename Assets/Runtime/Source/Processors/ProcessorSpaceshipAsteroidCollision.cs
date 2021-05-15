using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using Runtime.Source.Data;
using Runtime.Source.Signals;
using Runtime.Source.Tools.CameraShaker;
using Runtime.Source.Tools.CameraShaker.Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Source.Processors
{
    // Class represents a system that handles spaceships and asteroids collisions
    sealed class ProcessorSpaceshipAsteroidCollision : Processor, ITick
    {
        private Group<ComponentCollision> groupCollisions = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupCollisions.length; i++)
            {
                var componentCollision = groupCollisions[i].ComponentCollisionMarker();

                if (componentCollision.Collision.collider != null)
                {
                    var collisionInitiator = componentCollision.Collision.gameObject.GetEntity();

                    if (collisionInitiator.exist)
                    {
                        if (collisionInitiator.Has<ComponentAsteroid>() &&
                            componentCollision.ReceiverEntity.Has<ComponentSpaceship>())
                        {
                            HandleCollision(componentCollision, collisionInitiator);
                            groupCollisions[i].Release();
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
            SignalHealthChanged signal;
            signal.Health = cHealth;
            signal.Amount = amount;
            Ecs.Send(signal);
        }

        private void Explosion(ComponentCollision componentCollisionEvent)
        {
            CreateShards(componentCollisionEvent);
            CreateVFX(componentCollisionEvent);
        }

        private void CreateVFX(ComponentCollision componentCollisionEvent)
        {
            var sparksPosition = componentCollisionEvent.Collision.contacts[0].point;
            Actor.Create(DataBase.Prefabs.VfxSparks, sparksPosition, true);
            Actor.Create(DataBase.Prefabs.VfxPlasmaExplosion, sparksPosition, true);
        }

        private void CreateShards(ComponentCollision componentCollisionEvent)
        {
            var collisionInitiator = componentCollisionEvent.Collision.gameObject.GetEntity();
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
            SignalCameraShake signal;

            var shakeData = DataBase.ScriptableObjects.CameraShakeOnAsteroidHit;

            signal.ShakeData = (ShakePreset) shakeData;

            Ecs.Send(signal);
        }

        private Vector3 GetRandomVector3()
        {
            return new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        }
    }
}