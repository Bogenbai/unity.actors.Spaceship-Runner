using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class represents a system that controls the healths of the entities
    sealed class ProcessorHealth : Processor, ITick
    {
        private readonly Group<ComponentHealthChanged> healthChangedSignals = default;
        
        public void Tick(float dt)
        {
            foreach (var entity in healthChangedSignals)
            {
                var cHealthChanged = entity.ComponentHealthChanged();
                var componentHealth = cHealthChanged.componentHealth;

                ReduceHealth(componentHealth, cHealthChanged.amount);
            }
        }
        
        private static void ReduceHealth(ComponentHealth health, int amount)
        {
            health.value -= amount;
        }

    }
}