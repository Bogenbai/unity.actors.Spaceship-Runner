using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Components.Tags;
using Runtime.Source.Data;
using UnityEngine;

namespace Runtime.Source.Processors
{
    // Class represents a system that destroys player's spaceship if it's health points gets below zero
    sealed class ProcessorSpaceshipDeath : Processor, ITick
    {
        private Group<ComponentSpaceship, ComponentHealth> groupSpaceships = default;

        public void Tick(float delta)
        {
            for (int i = 0; i < groupSpaceships.length; i++)
            {
                var spaceship = groupSpaceships[i];
                var health = spaceship.ComponentHealth().value;

                if (health <= 0)
                {
                    spaceship.Release();
                    Explosion(spaceship.transform.position);
                }
            }
        }

        private void Explosion(Vector3 position)
        {
            Layer.Actor.Create(DataBase.Prefabs.VfxSparks, position, true);
            Layer.Actor.Create(DataBase.Prefabs.VfxBluePlasmaExplosion, position, true);
        }
    }
}
