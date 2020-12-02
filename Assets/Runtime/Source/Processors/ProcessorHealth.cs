using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Signals;

namespace Runtime.Source.Processors
{
    // Class represents a system that controls the healths of the entities
    sealed class ProcessorHealth : Processor<SignalHealthChanged>
    {
        public override void ReceiveEcs(ref SignalHealthChanged signal, ref bool stopSignal)
        {
            ReduceHealth(signal.Health, signal.Amount);
        }
        
        private void ReduceHealth(ComponentHealth health, int amount)
        {
            health.value -= amount;
        }
    }
}