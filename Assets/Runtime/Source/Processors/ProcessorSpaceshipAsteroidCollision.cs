using Pixeye.Actors;
using Runtime.Source.Tools;
using Runtime.Source.Tools.CameraShaker;
using Random = UnityEngine.Random;
using Runtime.Source.Signals;

namespace Game.Source
{
    sealed class ProcessorSpaceshipAsteroidCollision : Processor, ITick
    {
        Group<ComponentCollisionEvent> groupCollisions = default;

        public void Tick(float delta)
        {
            for (var i = 0; i < groupCollisions.length; i++)
            {
                var componentCollision = groupCollisions[i].ComponentCollision();
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
                            ReduceHealth(componentHealth, damage);
                        }

                        Explosion(componentCollision);
                        CreateCameraShakeEvent();

                        collisionInitiator.Release();
                    }
                }

                groupCollisions[i].Release();
            }
        }

        private void Explosion(ComponentCollisionEvent componentCollisionEvent)
        {
            var collisionInitiator = componentCollisionEvent.Collision.gameObject.GetEntity();
            var componentShatter = collisionInitiator.ComponentCanShatter();
            var sparksPosition = componentCollisionEvent.Collision.contacts[0].point;
            var shardsCount = Random.Range(componentShatter.MinShards, componentShatter.MaxShards + 1);

            for (var j = 0; j < shardsCount; j++)
            {
                var shardPosition = collisionInitiator.transform.position + Toolbox.GetRandomVector3() / 3;
                var shard = Layer.Actor.Create(componentShatter.ShardPrefab, shardPosition, true);
                shard.transform.localScale = componentShatter.ShardScale;
            }

            Actor.Create(DB.Prefabs.VfxSparks, sparksPosition, true);
            Actor.Create(DB.Prefabs.VfxPlasmaExplosion, sparksPosition, true);
        }

        private void CreateCameraShakeEvent()
        {
            SignalCameraShake signal;

            var shakeData = DB.ScriptableObjects.CameraShakeOnAsteroidHit;

            signal.ShakeData = (ShakePreset) shakeData;

            Ecs.Send(signal);
        }

        private void ReduceHealth(ComponentHealth health, int amount)
        {
            health.value -= amount;
        }
    }
}