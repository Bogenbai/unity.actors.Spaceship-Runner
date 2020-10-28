using System;
using Pixeye.Actors;
using UnityEngine;
using Random = UnityEngine.Random;

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

        public static float ConvertToRange(float val, float oldMin, float oldMax, float newMin, float newMax)
        {
            var oldRange = (oldMax - oldMin);

            if (oldRange == 0)
                val = newMin;
            else
            {
                var newRange = (newMax - newMin);
                val = (((val - oldMin) * newRange) / oldRange) + newMin;
            }

            return val;
        }

        public static Vector3 GetRandomVector3()
        {
            return new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        }
    }
}