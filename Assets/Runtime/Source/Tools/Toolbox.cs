using System;
using Pixeye.Actors;

namespace Runtime.Source.Tools
{
    public static class Toolbox
    {
        public const float Tolerance = 0.000001f;

        public static bool GroupContains<T>(Group<T> group, ent entity)
        {
            for (var i = 0; i < group.length; i++)
            {
                if (group[i] == entity) return true;
            }

            return false;
        }

        public static float InterpolateValueToZeroSmooth(float value, float t)
        {
            var result = value * Math.Abs(t);

            if (result < Tolerance)
            {
                result = 0;
            }

            return result;
        }
    }
}