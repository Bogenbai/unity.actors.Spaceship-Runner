using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Runtime.Source.Comparers
{
    public class EqualityGameStates : IEqualityComparer<GameStates>
    {
        internal static EqualityGameStates Default = new EqualityGameStates();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(GameStates x, GameStates y)
        {
            return x == y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(GameStates obj)
        {
            return obj.GetHashCode();
        }
    }
}