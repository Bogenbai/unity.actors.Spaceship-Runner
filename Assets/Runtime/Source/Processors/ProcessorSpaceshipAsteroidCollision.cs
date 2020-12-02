using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Markers;
using Runtime.Source.Components.Tags;
using Runtime.Source.Data;
using Runtime.Source.Signals;
using Runtime.Source.Tools;
using Runtime.Source.Tools.CameraShaker;
using Runtime.Source.Tools.CameraShaker.Signals;
using Random = UnityEngine.Random;

namespace Runtime.Source.Processors
{
    sealed class ProcessorSpaceshipAsteroidCollision : Processor, ITick
    {
        private Group<ComponentCollisionMarker> groupCollisions = default;

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
                            CreateCameraShakeEvent();

                            collisionInitiator.Release();
                            groupCollisions[i].Release();
                        }
                    }
                }
            }
        }

        private void SendHealthChangeSignal(ComponentHealth cHealth, int amount)
        {
            SignalHealthChanged signal;
            signal.Health = cHealth;
            signal.Amount = amount;
            Ecs.Send(signal);
        }

        private void Explosion(ComponentCollisionMarker componentCollisionEvent)
        {
            CreateShards(componentCollisionEvent);
            CreateVFX(componentCollisionEvent);
        }

        private void CreateVFX(ComponentCollisionMarker componentCollisionEvent)
        {
            var sparksPosition = componentCollisionEvent.Collision.contacts[0].point;
            Actor.Create(DB.Prefabs.VfxSparks, sparksPosition, true);
            Actor.Create(DB.Prefabs.VfxPlasmaExplosion, sparksPosition, true);
        }

        private void CreateShards(ComponentCollisionMarker componentCollisionEvent)
        {
            var collisionInitiator = componentCollisionEvent.Collision.gameObject.GetEntity();
            var componentShatter = collisionInitiator.ComponentCanShatter();
            var shardsCount = Random.Range(componentShatter.MinShards, componentShatter.MaxShards + 1);

            for (var j = 0; j < shardsCount; j++)
            {
                var shardPosition = collisionInitiator.transform.position + Toolbox.GetRandomVector3() / 3;
                var shard = Layer.Actor.Create(componentShatter.ShardPrefab, shardPosition, true);
                shard.transform.localScale = componentShatter.ShardScale;
            }
        }

        private void CreateCameraShakeEvent()
        {
            SignalCameraShake signal;

            var shakeData = DB.ScriptableObjects.CameraShakeOnAsteroidHit;

            signal.ShakeData = (ShakePreset) shakeData;

            Ecs.Send(signal);
        }
    }
}