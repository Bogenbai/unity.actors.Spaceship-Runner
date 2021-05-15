using Pixeye.Actors;
using Runtime.Source.Components;

namespace Runtime.Source.Processors
{
    // Class represents a system that controls the healths of the entities
    sealed class ProcessorHealth : Processor, ITick
    {
        private Group<ComponentHealthChanged> healthChangedSignals = default;
        
        public void Tick(float dt)
        {
            for (var i = 0; i < healthChangedSignals.length; i++)
            {
                var signal = healthChangedSignals[i].ComponentHealthChanged();
                var componentHealth = signal.componentHealth;

                ReduceHealth(componentHealth, signal.amount);
            }
        }
        
        private static void ReduceHealth(ComponentHealth health, int amount)
        {
            health.value -= amount;
        }

    }
}