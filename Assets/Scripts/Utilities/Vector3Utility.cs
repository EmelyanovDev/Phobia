using UnityEngine;

namespace Utilities
{
    public static class Vector3Utility
    {
        public static bool DistanceIsLess(this Vector3 value, Vector3 target, float requiredDistance)
        {
            float distance = Vector3.Distance(value, target);
            return distance < requiredDistance;
        }
    }
}