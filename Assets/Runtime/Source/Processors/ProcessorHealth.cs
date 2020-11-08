using Pixeye.Actors;
using Runtime.Source.Components;
using Runtime.Source.Signals;

namespace Runtime.Source.Processors
{
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