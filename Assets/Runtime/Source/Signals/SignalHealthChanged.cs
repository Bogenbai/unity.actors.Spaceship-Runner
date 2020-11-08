using Runtime.Source.Components;

namespace Runtime.Source.Signals
{
    public struct SignalHealthChanged
    {
        public ComponentHealth Health;
        public int Amount;
    }
}